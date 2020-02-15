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

        void LoadInfoinForm()
        {
            //gunaCirclePictureBox1.Image = Image.FromFile(lData.loginimg);
            using (StreamReader sr = new StreamReader(lData.pathinfo))
            {
                string[] info = sr.ReadLine().Split(';');
                label1.Text = info[0] + " " + info[1];
                int formWidth = this.Width;
                int lblWidth = label1.Width;
                label1.Left = (formWidth - lblWidth) / 2;
            }
        }
        LibFunction libfun = new LibFunction();

        private void Form1_Load(object sender, EventArgs e)
        {
            ReLocation();
            //LoadInfoinForm();
            Optimal();
            label3.Visible = false;
        }

        private void Optimal()
        {
            string a = "", b = "", c = "";
            libfun.LoadMenu(ref a, ref b, ref c, lData.menupath);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ReLocation();
            ReleaseRAM();
            this.Opacity = 1;
            gunaMetroTrackBar1.Value = 0;
            //LoadMenu();
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
            System.IO.File.WriteAllText(lData.path, string.Empty);
            System.IO.File.WriteAllText(lData.pathinfo, string.Empty);
            System.IO.File.WriteAllText(lData.menupath, string.Empty);

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

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadMenu()
        {
            try
            {
                gunaDataGridView1.Visible = true;
                gunaDataGridView1.Rows.Clear();
                gunaDataGridView1.Refresh();
                string path = lData.menupath;
                if (System.IO.File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {

                        string[] row = sr.ReadToEnd().Split('\n');
                        string[] info = row[0].Split(';');
                        int maxrow = Convert.ToInt32(info[1]);
                        string[] sang = row[1].Split('|');
                        string[] trua = row[2].Split('|');
                        string[] toi = row[3].Split('|');

                        string[] menu = new string[3];
                        for (int i = 0; i < Convert.ToInt32(info[2]); i++)
                        { menu[0] = sang[i]; }

                        for (int i = 0; i < maxrow; i++)
                        {
                            if (i >= Convert.ToInt32(info[2]))
                                menu[0] = "";
                            menu[1] = trua[i];
                            menu[2] = toi[i];
                            int idx = gunaDataGridView1.Rows.Add();
                            gunaDataGridView1.Rows[idx].SetValues(menu);
                        }

                    }
                }
                label3.Visible = false;
            }
            catch (Exception)
            {
                gunaDataGridView1.Visible = false;
                label3.Visible = true;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            LoadMenu();
        }
    }
}
