using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Data.SQLite;

namespace TrolyaoFara
{
    public partial class Form1 : Form
    {
        Database databaseObject = new Database();
        LibFunction lib = new LibFunction();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReLocation();

            GetFullName();
            GetDataFromMenu();
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
            lblNameUser.Text = lname + " " + fname;
        }
        #endregion

        #region FooterUI
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ReLocation();
            ReleaseRAM();
            this.Opacity = 1;
            gunaMetroTrackBar1.Value = 0;
        }

        classData lData = new classData();
        string username = "", email = "", userlogin = "";
        private void simpleButton2_Click(object sender, EventArgs e)
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
            //gunaCirclePictureBox1.Image = null;
            //gunaCirclePictureBox1.Update();

            this.Hide();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            this.Close();
            
        }

        private void gunaMetroTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (gunaMetroTrackBar1.Value > 30)
            {
                this.BackgroundImage = null;
                this.BackColor = Color.FromArgb(1, 4, 10);
                this.Opacity = gunaMetroTrackBar1.Value / 100.0;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.Message = "1";
            frm.Show();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region RunGA
        string strmenu = "";
        int breakfast = 0, lunch = 0, dinner = 0;

        public void GetDataFromMenu() // Update
        {
            try
            {
                lblGuide.Visible = false;
                string today = DateTime.Today.ToString("dd/MM/yyyy");
                string day = "";
                string sql = string.Format("SELECT * FROM menu WHERE id=1"); // Update line
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
                    LoadMenuForUser();
                else
                    SetMenu();
            }
            catch (Exception)
            {
                lblGuide.Visible = true;
                lblGuide.Top = this.Size.Width + 10;
                plnMenu.Visible = false;
                label2.Visible = false;
            }
        }
        GACal calmenu = new GACal();

        private void SetMenu()
        {
            plnLoadMenu.Controls.Clear();
            frmMenuFood frm = new frmMenuFood();
            calmenu.RunGACal();
            frm.getDataFromMenuTable(true);
        }

        private void LoadMenuForUser()
        {
            int[] idmenu = strmenu.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var date = DateTime.Now;
            int hour = date.Hour;

            if (hour <= 12)
            {
                lblNameOfMenu.Text = "Trưa";
                LoadItemToPanel(breakfast, breakfast + lunch, idmenu);
            }
            else if (12 < hour && hour <= 19)
            {
                lblNameOfMenu.Text = "Tối";
                LoadItemToPanel(breakfast + lunch, breakfast + lunch + dinner, idmenu);
            }
            else
            {
                lblNameOfMenu.Text = "Sáng";
                LoadItemToPanel(0, breakfast, idmenu);
            }
        }

        private void LoadItemToPanel(int begin, int end, int[] idmenu)
        {
            string namefood;

            databaseObject.OpenConnection();
            for (int i = begin; i < end; i++)
            {
                int idx = idmenu[i]+1;
                string sql = string.Format("SELECT * FROM food_db WHERE id='{0}'", idx);

                SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
                SQLiteDataReader rd = command.ExecuteReader();
                while (rd.Read())
                {
                    namefood = rd["name"].ToString();
                    plnLoadMenu.Controls.Add(ItemFoodMini.Add(namefood));
                }
                command.Dispose();
            }
            databaseObject.CloseConnection();
        }
        #endregion
    }
}
