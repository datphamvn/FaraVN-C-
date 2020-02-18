using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TrolyaoFara
{
    class GetData
    {
        Database databaseObject = new Database();
        LibFunction lib = new LibFunction();
        SettingSever sSever = new SettingSever();

        public void GetFoodDB()
        {
            string sql = "CREATE TABLE IF NOT EXISTS food_db([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, id_food INTEGER NOT NULL, id_purpose INTEGER NOT NULL, id_type INTEGER NOT NULL, id_method INTEGER NOT NULL, calo INTEGER NOT NULL, name varchar NOT NULL, timer INTEGER NOT NULL)";
            databaseObject.RunSQL(sql);
            if (!lib.CheckExists("food_db", "id", 1, ""))
            {
                string url = sSever.linksever + "ai/api/food/?search=1";
                DownloadData(url, 10);
                url = sSever.linksever + "ai/api/food/?search=2&3";
                DownloadData(url, 60);
            }
        }

        public void DownloadData(string url, int limit)
        {
            int i = 0;
            
            if (lib.CheckForInternetConnection())
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(url);
                    List<Food> data = JsonConvert.DeserializeObject<List<Food>>(json);
                    foreach (var item in data)
                    {
                        if (i == limit)
                            break;
                        byte[] bytes = Encoding.Default.GetBytes(item.Title.ToString());
                        string foodname = Encoding.UTF8.GetString(bytes);

                        string strInsert = string.Format("INSERT INTO food_db(id_food, id_purpose, id_type, id_method, calo, name, timer) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", item.Id, item.Purpose[0], item.Type[0], item.Method[0], item.Calo , foodname, item.Timer);
                        databaseObject.RunSQL(strInsert);
                        i++;
                    }
                }
            }
            else
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
        }

        //Bảng nguyên liệu
        public void Download2()
        {
            string sql = "CREATE TABLE IF NOT EXISTS calforfood([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, foodname INTEGER NOT NULL, composition INTEGER NOT NULL, amout FLOAT NOT NULL, unit INTEGER NOT NULL, main BOOL NOT NULL)";
            databaseObject.RunSQL(sql);
            if (!lib.CheckExists("calforfood", "id", 1, ""))
            {
                List<int> Database = new List<int>();

                sql = string.Format("SELECT * FROM food_db");
                databaseObject.OpenConnection();
                SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
                SQLiteDataReader rd = command.ExecuteReader();
                while (rd.Read())
                {
                    int idf = Convert.ToInt32(rd["id_food"]);
                    Database.Add(idf);
                }
                command.Dispose();
                databaseObject.CloseConnection();

                foreach (var getfood in Database)
                {
                    if (lib.CheckForInternetConnection())
                    {
                        using (WebClient wc = new WebClient())
                        {
                            var json = wc.DownloadString(sSever.linksever + "ai/api/cal/?id=&foodname=" + getfood);
                            List<CalFood> data = JsonConvert.DeserializeObject<List<CalFood>>(json);
                            foreach (var item in data)
                            {
                                string strInsert = string.Format("INSERT INTO calforfood(foodname, composition, amout, unit, main) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", item.Foodname, item.Composition, item.Amout, item.Unit, item.Main);
                                databaseObject.RunSQL(strInsert);
                            }
                        }
                    }
                    else
                        alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
                }
            }
        }
    }
}
