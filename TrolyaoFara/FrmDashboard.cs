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
    public partial class frmDashboard : Form
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

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            //openfrmRequireUpdateInfo(0); // Open home tab
            openChildForm(new frmSettingsMenu());
            if (strNhan == "1")
                openTabMenuFood();       
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
            lblTab.Text = "lblTab";
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
                if (String.IsNullOrEmpty(rd["fname"].ToString()) || String.IsNullOrEmpty(rd["birthday"].ToString()) || String.IsNullOrEmpty(rd["gender"].ToString()))
                    check = false;
            }
            command.Dispose();
            databaseObject.CloseConnection();
            return check;
        }

        private void openfrmRequireUpdateInfo(int idxTab)
        {
            if (CheckUpdateData())
            {
                if (idxTab == 0)
                    openTabHome();
                else if (idxTab == 1)
                    openTabMenuFood();
                else
                    openTabAccount();
            }
            else
                openTabUpdateInfo();
        }

        private void openTabHome()
        {
            frmHome frm = new frmHome();
            frm.mydata = new frmHome.GETDATA(GETVALUE);
            openChildForm(frm);
            lblButton.Text = "0";
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openfrmRequireUpdateInfo(0);
        }

        private void openTabMenuFood()
        {
            frmMenuFood frm = new frmMenuFood();
            frm.mydata = new frmMenuFood.GETDATA(GETVALUE);
            openChildForm(frm);
            lblButton.Text = "1";
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            openfrmRequireUpdateInfo(1);
        }

        private void openTabAccount()
        {
            frmAccount frm = new frmAccount();
            frm.mydata = new frmAccount.GETDATA(GETVALUE);
            openChildForm(frm);
            lblButton.Text = "2";
        }

        private void openTabUpdateInfo()
        {
            frmUpdateInfo frm = new frmUpdateInfo();
            frm.mydata = new frmUpdateInfo.GETDATA(GETVALUE);
            openChildForm(frm);
            lblButton.Text = "2";
        }

        private void openTabIndexBody()
        {
            frmIndexBody frm = new frmIndexBody();
            frm.mydata = new frmIndexBody.GETDATA(GETVALUE);
            frm.dataFromDashboard = lblTab.Text;
            openChildForm(frm);
            lblButton.Text = "2";
        }

        private void openTabSettingsMenu()
        {
            frmSettingsMenu frm = new frmSettingsMenu();
            frm.mydata = new frmSettingsMenu.GETDATA(GETVALUE);
            openChildForm(frm);
            lblButton.Text = "2";
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            openfrmRequireUpdateInfo(2);
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
        
        public void GETVALUE(string value)
        {
            lblTab.Text = value;
        }

        private void lblTab_TextChanged(object sender, EventArgs e)
        {
            if (lblTab.Text == "1")
                openTabMenuFood();
            if (lblTab.Text == "2")
                openTabAccount();
            if (lblTab.Text == "2.1")
                openTabUpdateInfo();
            if (lblTab.Text == "2.2.1" || lblTab.Text == "2.2.2" || lblTab.Text == "2.2.3")
                openTabIndexBody();
            if (lblTab.Text == "3")
                openTabSettingsMenu();
            if (lblTab.Text == "4")
                openTabHome();
        }
    }
}
