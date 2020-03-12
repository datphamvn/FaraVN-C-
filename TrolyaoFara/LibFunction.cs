using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Drawing;
using System.Net.NetworkInformation;

namespace TrolyaoFara
{
    class LibFunction
    {
        Database databaseObject = new Database();

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

        public int GetID()
        {
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
            bool check = false;
            databaseObject.OpenConnection();

            string sql = "";
            if(data >= 0)
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

        public string GetUsername()
        {
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

        public void TypeOfBody(double BMI, ref string type, ref string warning)
        {
            if (BMI < 18.5)
            {
                type = "Gầy";
                warning = "Thấp";
            }
            else if (18.5 <= BMI && BMI <= 24.9)
            {
                type = "Bình thường";
                warning = "Trung bình";
            }
            else if (25.0 <= BMI && BMI <= 29.9)
            {
                type = "Hơi béo";
                warning = "Cao";
            }
            else if (30.0 <= BMI && BMI <= 34.9)
            {
                type = "Béo phì cấp độ 3";
                warning = "Cao";
            }
            else if (35.0 <= BMI && BMI <= 39.9)
            {
                type = "Béo phì cấp độ 2";
                warning = "Rất cao";
            }
            else
            {
                type = "Béo phì cấp độ 3";
                warning = "Nguy hiểm";
            }
        }

        public double CoefficientCalo(int idx, double calo)
        {
            switch (idx)
            {
                case 1:
                    calo *= 1.375;
                    break;
                case 2:
                    calo *= 1.55;
                    break;
                case 3:
                    calo *= 1.725;
                    break;
                case 4:
                    calo *= 1.9;
                    break;
                default:
                    calo *= 1.2;
                    break;
            }
            return calo;
        }
    }
}
