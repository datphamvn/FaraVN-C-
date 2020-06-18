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
    class downloadData
    {
        Database databaseObject = new Database();
        LibFunction lib = new LibFunction();
        SettingSever sSever = new SettingSever();
        SQLquery runSQL = new SQLquery();
        Variables var = new Variables();
        int count = 0;
        List<Food> food = new List<Food>();

        public void MainGetData()
        {
            runSQL.createTableForDatabase(); // Dev Line

            //GetFoodRecommend();
            string url = sSever.linksever + "ai/api/food/?search=1";
            DownloadData(url, var.nBreakfast - CountRow(1));
            url = sSever.linksever + "ai/api/food/?search=2&3";
            count = 0;
            DownloadData(url, var.nOther - CountRow(2));

            alert.Show("Đã tải xong dữ liệu!", alert.AlertType.success);
        }

        #region GetFoodFromRecommend
        public void GetFoodRecommend()
        {
            int id = Convert.ToInt32(lib.GetID()); // Edit lại kiểu dữ liệu long và int
            if (lib.CheckForInternetConnection())
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(sSever.linksever + "ai/kq");
                    List<FoodRecommend> data = JsonConvert.DeserializeObject<List<FoodRecommend>>(json);

                    foreach (var item in data[id].Items)
                    {
                        json = wc.DownloadString(sSever.linksever + "ai/api/food/" + item);
                        json = "[" + json + "]";
                        food = JsonConvert.DeserializeObject<List<Food>>(json); // Xử lý function
                        /*
                        foreach (var ifood in food)
                        {
                            getFoodProcess(ifood);
                        }*/
                    }
                }
            }
            else
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
        }
        
        private void getFoodProcess(Food ifood)
        {
            Random random = new Random();
            if (ifood.Draft == false && !lib.CheckExists("food_db", "id_food", ifood.Id, ""))
            {
                if (GetCompositionOfFood(ifood.Id)) // Kiểm tra tp món ăn thỏa mãn không -(True)-> Lưu vào bảng calforfood
                {
                    byte[] bytes = Encoding.Default.GetBytes(ifood.Title.ToString());
                    string foodname = Encoding.UTF8.GetString(bytes);

                    string strInsert = string.Format("INSERT INTO food_db(id_food, id_purpose, id_type, id_method, calo, name, timer) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", ifood.Id, ifood.Purpose[0], ifood.Type[0], ifood.Method[0], random.Next(330, 360), foodname, ifood.Timer);
                    databaseObject.RunSQL(strInsert);
                    count++;
                }
            }
        }

        private bool GetCompositionOfFood(long idFood)
        {
            if (lib.CheckForInternetConnection())
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(sSever.linksever + "ai/api/cal/?id=&foodname=" + idFood);
                    List<CalFood> data = JsonConvert.DeserializeObject<List<CalFood>>(json);
                    foreach (var item in data)
                    {
                        if (item.Main == true)
                        {
                            if (lib.CheckExists("allergic", "composition_id", item.id_Composition, ""))
                                return false;
                        }
                    }

                    foreach (var item in data)
                    {
                        if (item.Main == true)
                        {
                            if (!CheckExistsCalForFood(idFood, item.id_Composition))
                            {
                                string strInsert = string.Format("INSERT INTO calforfood(id_food, id_composition, amout, unit, main) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", item.id_Foodname, item.id_Composition, item.Amout, item.Unit, item.Main);
                                databaseObject.RunSQL(strInsert);
                            }
                        }
                    }
                }
            }
            else
            {
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
                return false;
            }
            return true;
        }

        public bool CheckExistsCalForFood(long idFood, long idComposition)
        {
            bool check = false;
            databaseObject.OpenConnection();

            string sql = "SELECT * FROM calforfood WHERE id_food = " + idFood + " AND id_composition = " + idComposition;
            SQLiteCommand cmd = new SQLiteCommand(sql, databaseObject.myConnection);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count != 0)
                check = true;

            databaseObject.CloseConnection();
            return check;
        }
        #endregion

     
        private int CountRow(int typeID)
        {
            string sql = "SELECT * FROM food_db WHERE id_purpose = " + typeID;
            int nRow = lib.countRow(sql);
            return nRow;
        }

        public void DownloadData(string url, int limit)
        {
            if (lib.CheckForInternetConnection())
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(url);
                    List<Food> food = JsonConvert.DeserializeObject<List<Food>>(json);
                    foreach (var ifood in food)
                    {
                        if (count == limit)
                            break;
                        getFoodProcess(ifood);
                        //i++;
                    }
                }
            }
            else
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
        }
    }
}
