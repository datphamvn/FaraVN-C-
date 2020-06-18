using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace TrolyaoFara
{
    public partial class Form1 : Form
    {
        Database databaseObject = new Database();
        LibFunction lib = new LibFunction();
        SettingSever sSever = new SettingSever();
        Variables var = new Variables();
        SQLquery runSQL = new SQLquery();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Main();

            if (lib.countRow("SELECT * FROM food_db") < (var.nBreakfast + var.nOther) || lib.countRow("SELECT * FROM calforfood") == 0)
            {
                alert.Show("Đang tải dữ liệu... \nVui lòng không đóng phần mềm!", alert.AlertType.warning, 96);

                Action load = () =>
                { 
                    downloadData downDT = new downloadData();
                    downDT.MainGetData();
                };
                Task task = new Task(load);
                task.Start();
            }
        }

        private void Main()
        {
            ReLocation();
            ReleaseRAM();

            panel1.BackColor = Color.FromArgb(0, Color.Black);
            gunaMetroTrackBar1.Value = 0;

            GetFullName();
            // imgAvatar.LoadAsync(link image); // Update link avatar

            frmDashboard frm = new frmDashboard();
            bool checkData = frm.CheckUpdateData();

            if (checkData && lib.CheckExists("settings", "id", 1, ""))
            {
                plnMenu.Visible = true;
                lblTitle.Visible = true;
                btnViewMore.Enabled = true;
                lblGuide.Visible = false;
                showMenu();
            }
            else
            {
                plnMenu.Visible = false;
                lblTitle.Visible = false;
                btnViewMore.Visible = false;

                lblGuide.Visible = true;
                lblGuide.Top = this.Size.Width + 10;
            }
        }

        #region UI
        [DllImport("KERNEL32.DLL", EntryPoint = "SetProcessWorkingSetSize", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool SetProcessWorkingSetSize(IntPtr pProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);
        [DllImport("KERNEL32.DLL", EntryPoint = "GetCurrentProcess", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr GetCurrentProcess();
        public void ReleaseRAM()
        {
            IntPtr pHandle = GetCurrentProcess();
            SetProcessWorkingSetSize(pHandle, -1, -1);
        }

        private void ReLocation()
        {
            this.Hide();
            this.SetDesktopLocation(Screen.PrimaryScreen.WorkingArea.Width - this.Width, 0);
            this.Size = new Size(320, Screen.PrimaryScreen.WorkingArea.Height);
            Bitmap bm = new Bitmap(this.Width, this.Height);
            Graphics gp = Graphics.FromImage(bm);
            gp.CopyFromScreen(this.DesktopLocation.X + Screen.PrimaryScreen.WorkingArea.X, 0, 0, 0, this.Size);
            this.BackgroundImage = bm;
            this.Show();
        }
        #endregion

        #region DataUser
        private void GetFullName()
        {
            string lname = "", fname = "";
            string sql = string.Format("SELECT * FROM info WHERE iduser='{0}'", lib.GetID());
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                fname = rd["fname"].ToString();
                lname = rd["lname"].ToString();
            }
            command.Dispose();
            databaseObject.CloseConnection();

            if (lname == "" && fname == "")
                lblNameUser.Text = "FaraVN";
            else
                lblNameUser.Text = lname + " " + fname;
        }
        #endregion

        #region FooterUI
        private void btnOpenDashboard_Click(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.Show();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            Main();
        }

        classData lData = new classData();
        string username = "", email = "", userlogin = "";
        private void btnLogout_Click(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT * FROM account WHERE iduser='{0}'", lib.GetID());
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                username = rd["username"].ToString();
                email = rd["email"].ToString();
            }
            command.Dispose();
            databaseObject.CloseConnection();

            if (username == "")
                userlogin = email;
            else
                userlogin = username;
                  
            string strUpdate = string.Format("UPDATE account set login=\"False\" where username='{0}' or email='{0}'", userlogin);
            databaseObject.RunSQL(strUpdate);

            this.Hide();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            this.Close();
        }

        private void gunaMetroTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(gunaMetroTrackBar1.Value, Color.Black);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.Message = "1";
            frm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region LoadMenu
        string strmenu = "";
        int breakfast = 0, lunch = 0, dinner = 0;

        private void getMenuData(string day)
        {
            string today = DateTime.Today.ToString("dd/MM/yyyy");
            string sql = string.Format("SELECT * FROM menu WHERE date ='{0}'", today);

            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                strmenu = rd["recommend"].ToString();
                breakfast = Convert.ToInt32(rd["breakfast"]);
                lunch = Convert.ToInt32(rd["lunch"]);
                dinner = Convert.ToInt32(rd["dinner"]);
            }
            command.Dispose();
            databaseObject.CloseConnection();
        }

        public void showMenu() // Update
        {
            plnLoadMenu.Controls.Clear();

            var date = DateTime.Now;
            int hour = date.Hour;

            //if(hour <= 19)
            if(true)
            {
                string today = DateTime.Today.ToString("dd/MM/yyyy");
                getMenuData(today);

                if (strmenu != "")
                {
                    int[] idmenu = strmenu.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    if (0 <= hour && hour <= 7)
                    {
                        lblNameOfMenu.Text = "Sáng";
                        LoadItemToPanel(0, breakfast, idmenu);
                    }
                    else if (7 < hour && hour <= 12)
                    {
                        lblNameOfMenu.Text = "Trưa";
                        LoadItemToPanel(breakfast, breakfast + lunch, idmenu);
                    }
                    else //if (12 < hour && hour <= 19)
                    {
                        lblNameOfMenu.Text = "Tối";
                        LoadItemToPanel(breakfast + lunch, breakfast + lunch + dinner, idmenu);
                    }
                }
                else
                {
                    Action load = () => {
                        createNewMenu(true);
                    };
                    Task task = new Task(load);
                    task.Start();
                    //createNewMenu(true); // Show
                }
            }
            else
            {
                Action load = () => {
                    createNewMenu(false);
                };
                Task task = new Task(load);
                task.Start();
                //createNewMenu(false); // Show
            }
        }

        private void LoadItemToPanel(int begin, int end, int[] idmenu)
        {
            string namefood;

            databaseObject.OpenConnection();
            for (int i = begin; i < end; i++)
            {
                long idFood;
                int idx = idmenu[i]+1;
                string sql = string.Format("SELECT * FROM food_db WHERE id='{0}'", idx);

                SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
                SQLiteDataReader rd = command.ExecuteReader();
                while (rd.Read())
                {
                    idFood = Convert.ToInt64(rd["id_food"].ToString());
                    namefood = rd["name"].ToString();
                    plnLoadMenu.Controls.Add(ItemFoodMini.Add(idFood, namefood));
                }
                command.Dispose();
            }
            databaseObject.CloseConnection();
        }

        private void createNewMenu(bool today)
        {
            int subtractDay = 0;
            string recentDay = DateTime.Today.AddDays(subtractDay).ToString("dd/MM/yyyy");
            string mainSQL = string.Format("SELECT * FROM menu WHERE date ='{0}'", recentDay);
            while (lib.countRow(mainSQL) <= 0)
            {
                subtractDay--;
                recentDay = DateTime.Today.AddDays(subtractDay).ToString("dd/MM/yyyy");
                mainSQL = string.Format("SELECT * FROM menu WHERE date ='{0}'", recentDay);
            }

            int mod = 0, protein = 0, lipid = 0, carb = 0, p_breakfast = 0, p_lunch = 0, p_dinner = 0, calo = 0;
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(mainSQL, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                breakfast = Convert.ToInt32(rd["breakfast"]);
                lunch = Convert.ToInt32(rd["lunch"]);
                dinner = Convert.ToInt32(rd["dinner"]);
                protein = Convert.ToInt32(rd["protein"]);
                lipid = Convert.ToInt32(rd["lipid"]);
                carb = Convert.ToInt32(rd["carb"]);
                p_breakfast = Convert.ToInt32(rd["p_breakfast"]);
                p_lunch = Convert.ToInt32(rd["p_lunch"]);
                p_dinner = Convert.ToInt32(rd["p_dinner"]);
                mod = Convert.ToInt32(rd["mod"]);
                calo = Convert.ToInt32(rd["calo"]);
            }
            command.Dispose();
            databaseObject.CloseConnection();
            string day = "";
            if(today)
                day = DateTime.Today.ToString("dd/MM/yyyy");
            else
                day = DateTime.Today.AddDays(1).ToString("dd/MM/yyyy");

            runSQL.SQLforMenuTable(breakfast, lunch, dinner, calo, protein, lipid, carb, p_breakfast, p_lunch, p_dinner, mod, day);

            frmSettingsMenu frm = new frmSettingsMenu();
            frm.generateMenuForToday(mod, day);
        }
        #endregion
    }
}
