using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Runtime;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Data.SQLite;

namespace TrolyaoFara
{
    class LibFunction
    {
        public bool CheckForInternetConnection()
        {
            /*
            bool con = NetworkInterface.GetIsNetworkAvailable();
            if (con == true)
                return true;
            else
                return false;
                */
            return true;
        }

        Database databaseObject = new Database();
        public int GetID()
        {
            int id = -1;
            string sql = "SELECT * FROM account WHERE login = 1";
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

        public bool CheckExists(string nameTable, string nameCol, int data, string data1)
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

        /*
static Random rd = new Random();
public int GetFirstValueinList(List<int> Data)
{
    int value = rd.Next(11);
    return value;
}
*/

        //Code test 
        public void LoadMenu(ref string a,ref string b,ref string c, string path)
        {
            a = b = c = "";
            //int[] getdata = new int[nInfo];
            if (System.IO.File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string[] words = sr.ReadToEnd().Split('\n');
                    int k = 0;
                    foreach (string i in words)
                    {
                        if (i == "")
                            break;
                        string[] getline = i.Split(',');
                        foreach (string d in getline)
                        {
                            if (k == 0)
                            {
                                a += d + "\n";
                            }
                            else if (k == 1)
                            {
                                b += d + "\n";
                            }
                            else
                                c += d + "\n";
                        }
                        k++;
                    }
                }
            }
            else
                Console.WriteLine("File does not exist");
        }
        
        /*
        LoadData lData = new LoadData();
        public void LoadInfoinForm()
        {
            string img = lData.loginimg;
            using (StreamReader sr = new StreamReader(lData.pathinfo))
            {
                string data = sr.ReadLine();
                string[] birthday = data.Split('-');
                DateTime UTCNow = DateTime.UtcNow;
                int old = UTCNow.Year - Convert.ToInt32(birthday[0]);
                lblOld.Text = old.ToString();

                data = sr.ReadLine();
                lblHello.Text = "Xin chào, " + data;

                string height = sr.ReadLine();
                lblHeight.Text = height;

                string weight = sr.ReadLine();
                lblWeight.Text = weight;
                int i = -1;
                //int BMI = Int32.TryParse(weight, out i);
            }
        }*/
    }
}
