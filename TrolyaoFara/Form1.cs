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

        private void Form1_Load(object sender, EventArgs e)
        {
            ReLocation();

            GetDataFromMenu();
            GetFullName();
            
        }

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


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ReLocation();
            ReleaseRAM();
            this.Opacity = 1;
            gunaMetroTrackBar1.Value = 0;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
        }

        LoadData lData = new LoadData();
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
                  
            string strUpdate = string.Format("UPDATE account set login=false where username='{0}' or email='{0}'", userlogin);
            databaseObject.RunSQL(strUpdate);
            //gunaCirclePictureBox1.Image = null;
            //gunaCirclePictureBox1.Update();

            this.Hide();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            this.Close();
            try
            {
                File.Delete(lData.loginimg);
            }
            catch(Exception)
            {
                Console.Write("Warning");
            }
        }

        private void gunaMetroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
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
        
        string strmenu = "";
        int breakfast = 0, lunch = 0, dinner = 0;

        public void GetDataFromMenu()
        {
            try
            {
                lblGuide.Visible = false;
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

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Message = "1";
            frm.Show();
        }

        private void SetMenu()
        {
            plnLoadMenu.Controls.Clear();
            frmMenuFood frm = new frmMenuFood();
            frm.CallGA();
            frm.CalCalo();
            calmenu.RunGACal();
            frm.GetDataFromMenu();
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

        private void Form1_Shown(object sender, EventArgs e)
        {
            //LoadMenu();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
