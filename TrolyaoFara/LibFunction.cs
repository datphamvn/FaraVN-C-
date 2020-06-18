using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Drawing;
using System.Net.NetworkInformation;
using System.IO;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TrolyaoFara
{
    public class LibFunction
    {
        public bool CheckForInternetConnection()
        {
            bool con = NetworkInterface.GetIsNetworkAvailable();
            if (con == true)
                return true;
            else
                return false;
            //return true;
        }

        public void HideAllTabsOnTabControl(TabControl theTabControl)
        {
            theTabControl.Appearance = TabAppearance.FlatButtons;
            theTabControl.ItemSize = new Size(0, 1);
            theTabControl.SizeMode = TabSizeMode.Fixed;
        }

        public long GetID()
        {
            Database databaseObject = new Database();
            int id = -1;
            string sql = "SELECT * FROM account WHERE login=\"True\"";
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                id = Convert.ToInt32(rd["iduser"]);
            }
            command.Dispose();
            databaseObject.CloseConnection();
            return id;
        }

        public bool CheckExists(string nameTable, string nameCol, long data, string data1)
        {
            Database databaseObject = new Database();
            bool check = false;
            databaseObject.OpenConnection();

            string sql = "";
            if (data >= 0)
                sql = "SELECT count(*) FROM " + nameTable + " WHERE " + nameCol + "=" + data;
            else
                sql = "SELECT count(*) FROM " + nameTable + " WHERE " + nameCol + "= \"" + data1 + "\"";
            SQLiteCommand cmd = new SQLiteCommand(sql, databaseObject.myConnection);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count != 0)
                check = true;

            databaseObject.CloseConnection();
            return check;
        }

        public string getPathDataInPCUser(string extensionPath)
        {
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = Directory.GetParent(path).ToString() + extensionPath;
            }
            Directory.CreateDirectory(path);
            return path;
        }

        public string GetUsername()
        {
            Database databaseObject = new Database();
            string username = "";
            string sql = "SELECT * FROM account WHERE login=\"True\"";
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                username = rd["username"].ToString();
            }
            command.Dispose();
            databaseObject.CloseConnection();
            return username;
        }

        public void getUserLocal(List<string> listUserLocal, List<int> listIDUserLocal)
        {
            Database databaseObject = new Database();
            //List<string> listUserLocal = new List<string>();

            string sql = string.Format("SELECT * FROM info WHERE iduser < 0");
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                listUserLocal.Add(rd["fname"].ToString());
                listIDUserLocal.Add(Convert.ToInt32(rd["iduser"]));
            }
            command.Dispose();
            databaseObject.CloseConnection();
            //return listUserLocal;
        }

        public async void getImgForFoodItem(string idx, PictureBox picPreviewFood)
        {
            if (CheckForInternetConnection())
            {
                SettingSever sSever = new SettingSever();
                Food food = null;
                Action load = () =>
                {
                    if (CheckForInternetConnection())
                    {
                        using (WebClient wc = new WebClient())
                        {
                            var json = wc.DownloadString(sSever.linksever + "ai/api/food/" + idx);
                            food = JsonConvert.DeserializeObject<Food>(json);
                        }
                    }
                };
                Task task = new Task(load);
                task.Start();
                await task;
                picPreviewFood.Show();
                picPreviewFood.LoadAsync(sSever.linkimg + food.URLimg);
            }
        }

        public int countRow(string sql) 
        {
            int nRow = 0;
            Database databaseObject = new Database();
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                nRow++;
            }
            command.Dispose();
            databaseObject.CloseConnection();
            return nRow;
        }
    }
}
