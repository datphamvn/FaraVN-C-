using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrolyaoFara
{
    public partial class FrmDashboard : Form
    {
        Database databaseObject = new Database();
        LibFunction lib = new LibFunction();
        private const int cGrip = 16;

        string strNhan = "";
        public string Message
        {
            get { return strNhan; }
            set { strNhan = value; }
        }

        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            OpenFrmHome();

            if(strNhan == "1")
            {
                openChildForm(new frmMenuFood());
                lblButton.Text = "1";
            }
            if (strNhan == "0")
            {
                openChildForm(new frmHome());
                lblButton.Text = "0";
            }
        }


        #region Setup_Form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnRestore_down_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            btnRestore_down.Visible = false;
            btnFullScreen.Visible = true;
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            btnFullScreen.Visible = false;
            btnRestore_down.Visible = true;
        }

        private void imgCustomSidebar_Click(object sender, EventArgs e)
        {
            if(Sidebar.Width > 150)
            {
                Sidebar.Visible = false;
                Sidebar.Width = 60;
                SidebarWapper.Width = 75;
                LinearSidebar.Width = 40;
                AnimationSidebar.Show(Sidebar);
                ptLogo2.Visible = true;
            }
            else
            {
                Sidebar.Visible = false;
                Sidebar.Width = 200;
                SidebarWapper.Width = 212;
                LinearSidebar.Width = 180;
                AnimationSidebarBack.Show(Sidebar);
                ptLogo2.Visible = false;
            }
        }
        #endregion

        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelOpenform.Controls.Add(childForm);
            panelOpenform.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        void SetcurrentTab(int index)
        {
            switch (Int32.Parse(lblButton.Text))
            {
                case 0:
                    indicator.Top = btnHome.Top + 10;
                    break;
                case 1:
                    indicator.Top = btnMenu.Top + 10;
                    break;
                case 2:
                    indicator.Top = btnAccount.Top + 10;
                    break;
                case 3:
                    indicator.Top = btnSetting.Top + 10;
                    break;
                case 4:
                    indicator.Top = btnAbout.Top + 10;
                    break;
            }
        }

        #region OpenForm
        private void lblButton_TextChanged(object sender, EventArgs e)
        {
            SetcurrentTab(Int32.Parse(lblButton.Text));
        }

        private bool CheckUpdateData()
        {
            bool check = true;
            string sql = string.Format("SELECT * FROM info WHERE iduser='{0}'", lib.GetID());
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {

                if (String.IsNullOrEmpty(rd["fname"].ToString()) || String.IsNullOrEmpty(rd["birthday"].ToString()) || String.IsNullOrEmpty(rd["height"].ToString()) || String.IsNullOrEmpty(rd["weight"].ToString()))
                    check = false;
            }
            command.Dispose();
            databaseObject.CloseConnection();
            return check;
        }

        private void OpenFrmHome()
        {
            if (CheckUpdateData())
            {
                openChildForm(new frmHome());
                lblButton.Text = "0";
            }
            else
            {
                openChildForm(new frmAccount());
                lblButton.Text = "2";
                alert.Show("Vui lòng cập nhật đầy đủ thông tin cá nhân!", alert.AlertType.warning);
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            openChildForm(new frmMenuFood());
            lblButton.Text = "1";
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenFrmHome();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAccount());
            lblButton.Text = "2";
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            openChildForm(new frmSettings());
            lblButton.Text = "3";
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAbout());
            lblButton.Text = "4";
        }
        #endregion

        private void lblGetDataFromForm_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
