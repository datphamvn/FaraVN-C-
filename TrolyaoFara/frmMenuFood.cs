using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrolyaoFara
{
    public partial class frmMenuFood : Form
    {
        LoadData lData = new LoadData();
        Database databaseObject = new Database();
        LibFunction lib = new LibFunction();
        GAVer2 menu = new GAVer2();
        GACal calmenu = new GACal();
        SettingSever sSever = new SettingSever();

        string strmenu = "";
        int breakfast = 0, lunch = 0, dinner = 0;

        public frmMenuFood()
        {
            InitializeComponent();
        }

        private void frmMenuFood_Load(object sender, EventArgs e)
        {
            lib.HideAllTabsOnTabControl(tabControl1);
            LoadSettings();
            GetDataFromMenu();

        }

        #region TabSettings
        public void GetDataFormSettings()
        {
            string sql = string.Format("SELECT * FROM settings");
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                numBreakfast.Value = Convert.ToInt32(rd["breakfast"]);
                numLunch.Value = Convert.ToInt32(rd["lunch"]);
                numDinner.Value = Convert.ToInt32(rd["dinner"]);
                cbxMode.SelectedIndex = Convert.ToInt32(rd["mode"]);
            }
            command.Dispose();
            databaseObject.CloseConnection();
        }

        public void LoadSettings()
        {
            try
            {
                GetDataFormSettings();
            }
            catch (Exception)
            {
                CreateTable();
            }
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            string strUdpate = string.Format("UPDATE settings set breakfast='{0}', lunch='{1}', dinner='{2}', mode='{3}' where id > 0", numBreakfast.Value, numLunch.Value, numDinner.Value, cbxMode.SelectedIndex);
            databaseObject.RunSQL(strUdpate);
            alert.Show("Đã lưu thiết lập!", alert.AlertType.success);
        }

        private void btnResetSetting_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }
        #endregion

        public void GetDataFromMenu()
        {
            try
            {
                string today = DateTime.Today.ToString("dd/MM/yyyy");
                string day = "";
                string sql = string.Format("SELECT * FROM menu WHERE id=1");
                databaseObject.OpenConnection();
                SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
                SQLiteDataReader rd = command.ExecuteReader();
                while (rd.Read())
                {
                    strmenu = rd["recommend"].ToString();
                    breakfast = Convert.ToInt32(rd["breakfast"]);
                    lunch = Convert.ToInt32(rd["lunch"]);
                    dinner = Convert.ToInt32(rd["dinner"]);
                    day = rd["date"].ToString();
                }
                command.Dispose();
                databaseObject.CloseConnection();
                if (strmenu != "" && today == day)
                {
                    LoadMenuForUser();                }
                else
                {
                    SetMenu();
                }
            }
            catch (Exception)
            {
                tabControl1.SelectTab(1);
            }
        }

        // Khởi tạo thực đơn cơ sở
        public void CallGA()
        {
            try
            {
                string strUdpate = string.Format("UPDATE menu set recommend='{0}', date='{1}', breakfast='{2}', lunch='{3}', dinner='{4}'  where id=1", "", DateTime.Today.ToString("dd/MM/yyyy"), numBreakfast.Value, numLunch.Value, numDinner.Value);
                databaseObject.RunSQL(strUdpate);
            }
            catch(Exception) {
                menu.CreateTable();
                string strUdpate = string.Format("UPDATE menu set recommend='{0}', date='{1}', breakfast='{2}', lunch='{3}', dinner='{4}'  where id=1", "", DateTime.Today.ToString("dd/MM/yyyy"), numBreakfast.Value, numLunch.Value, numDinner.Value);
                databaseObject.RunSQL(strUdpate);
            }
            menu.GA1Day();
        }

        public void CalCalo()
        {
            int gender = 0, height = 0, weight = 0, old = 0, intensity=0;

            string sql = string.Format("SELECT * FROM info WHERE id=1");
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                gender = Convert.ToInt32(rd["gender"]);
                height = Convert.ToInt32(rd["height"]);
                weight = Convert.ToInt32(rd["weight"]);
                intensity = Convert.ToInt32(rd["intensity"]);

                DateTime now = DateTime.Today;
                int nyear = Convert.ToInt32(now.ToString("yyyy"));
                int birthday = Convert.ToDateTime(rd["birthday"].ToString()).Year;
                old = nyear - birthday;
            }
            command.Dispose();
            databaseObject.CloseConnection();

            double calo = 0;
            if (gender == 1) // Là Nam
            {
                calo = (13.397 * weight) + (4.799 * height) - (5.677 * old) + 88.362;
                calo = lib.CoefficientCalo(intensity, calo);
            }
            else // Là nữ
            {
                calo = (9.247 * weight) + (3.098 * height) - (4.330 * old) + 447.593;
                calo = lib.CoefficientCalo(intensity, calo);
            }

            int idxcbMode = cbxMode.SelectedIndex;
            if (idxcbMode == 1)
                calo = calo * 90 / 100;
            else if (idxcbMode == 2)
                calo = calo * 110 / 100;

            string strUdpate = string.Format("UPDATE menu set calo='{0}' where id=1", Math.Truncate(calo - 330));
            databaseObject.RunSQL(strUdpate);
        }

        private void RemoveControlInPanel()
        {
            plnLoadBreakfast.Controls.Clear();
            plnLoadLunch.Controls.Clear();
            plnLoadDinner.Controls.Clear();
        }

        private void SetMenu()
        {
            RemoveControlInPanel();
            CallGA();
            CalCalo();
            calmenu.RunGACal();
            GetDataFromMenu();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            SetMenu();
            tabControl1.SelectTab(0);
        }

        

        public void LoadItemToPanel(int begin, int end, int[] idmenu, double[] grmenu, FlowLayoutPanel plnPanel)
        {
            int id;
            string namefood;
            int timer;
            double calo;

            databaseObject.OpenConnection();
            for (int i = begin; i < end; i++)
            {
                id = idmenu[i]+1;
                string sql = string.Format("SELECT * FROM food_db WHERE id='{0}'", id);

                SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
                SQLiteDataReader rd = command.ExecuteReader();
                while (rd.Read())
                {
                    namefood = rd["name"].ToString();
                    timer = Convert.ToInt32(rd["timer"].ToString());
                    calo = Convert.ToDouble(rd["calo"].ToString());
                    plnPanel.Controls.Add(ItemFood.Add(id, namefood, timer, Convert.ToInt32(grmenu[i]*calo)));
                }
                command.Dispose();
            }
            databaseObject.CloseConnection();
        }

        public void LoadMenuForUser()
        {
            int[] idmenu = strmenu.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string grammenu = "";
            string sql = string.Format("SELECT * FROM menu WHERE id=2");
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                grammenu = rd["recommend"].ToString();
            }
            command.Dispose();
            databaseObject.CloseConnection();

            double[] grmenu = grammenu.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            LoadItemToPanel(0, breakfast, idmenu, grmenu, plnLoadBreakfast);
            LoadItemToPanel(breakfast, breakfast + lunch, idmenu, grmenu, plnLoadLunch);
            LoadItemToPanel(breakfast + lunch, breakfast + lunch + dinner, idmenu, grmenu, plnLoadDinner); 
        }


        /*
        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = this.gunaDataGridView1.CurrentCell.RowIndex;
                int c = this.gunaDataGridView1.CurrentCell.ColumnIndex;
                //textBox1.Text = gunaDataGridView1.Rows[r].Cells[c].Value.ToString();
            }
            catch
            { }
        }
        */

        private void LoadDataInCol(Stack StackMenu, int n, int idcol, Guna.UI.WinForms.GunaDataGridView gunaDataGridView)
        {
            for (int i=0; i<n; i++)
            {
                gunaDataGridView.Rows[i].Cells[idcol].Value = StackMenu.Pop();
            }
        }

        //Save TEstData Selection
        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Stack NewStack = new Stack();
            for (int i = gunaDataGridView2.Columns.Count - 1; i >= 0; i--)
            {
                for (int j = gunaDataGridView2.Rows.Count - 1; j >= 0; j--)
                {
                    string temp = "";
                    try
                    {
                        temp = gunaDataGridView2.Rows[j].Cells[i].Value.ToString();
                    }
                    catch (Exception) { }
                    if (!string.IsNullOrEmpty(temp))
                        NewStack.Push(gunaDataGridView2.Rows[j].Cells[i].Value);
                    else
                        continue;
                }
            }

            //Save Database
            strmenu = "";
            int Length = NewStack.Count;
            for (int i = 0; i < Length; i++)
            {
                strmenu += " " + NewStack.Pop();
            }
            string strUdpate = string.Format("UPDATE menu set recommend='{0}', date='{1}', breakfast='{2}', lunch='{3}', dinner='{4}'  where id=1", strmenu, DateTime.Today.ToString("dd/MM/yyyy"), breakfast, lunch, dinner);
            databaseObject.RunSQL(strUdpate);
        }


        #region CreateData
        /* Mode int
         * 0 => Bình thường
         * 1 => Giảm cân
         * 2 => Tăng cân
        */
        private void CreateTable()
        {
            string sql = "CREATE TABLE IF NOT EXISTS settings ([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, breakfast integer NOT NULL, lunch integer NOT NULL, dinner integer NOT NULL, mode integer NOT NULL)";
            databaseObject.RunSQL(sql);
            SetFirstLine();
        }

        private void SetFirstLine()
        {
            if (!lib.CheckExists("settings", "id", 1, ""))
            {
                string strInsert = string.Format("INSERT INTO settings(breakfast, lunch, dinner, mode) VALUES('{0}','{1}','{2}','{3}')", numBreakfast.Value, numLunch.Value, numDinner.Value, 0);
                databaseObject.RunSQL(strInsert);
            }
        }


        #endregion

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {/*
            string sql = "CREATE TABLE IF NOT EXISTS db_food([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, id_food INTEGER NOT NULL, id_purpose INTEGER NOT NULL, id_type INTEGER NOT NULL, id_method INTEGER NOT NULL, calo INTEGER NOT NULL)";
            databaseObject.RunSQL(sql);
            if (lib.CheckForInternetConnection())
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(sSever.linksever + "ai/api/food/");
                    List<Food> data = JsonConvert.DeserializeObject<List<Food>>(json);
                    foreach (var item in data)
                    {
                        string strInsert = string.Format("INSERT INTO db_food(id_food, id_purpose, id_type, id_method, calo) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", item.Id, lib.GetFirstValueinList(item.Purpose), lib.GetFirstValueinList(item.Type), lib.GetFirstValueinList(item.Method), item.Calo);
                        databaseObject.RunSQL(strInsert);
                    }
                }
            }
            else
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
                */
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //flowLayoutPanel1.Controls.Add(ItemFood.Instance);
        }
        
    }
}
