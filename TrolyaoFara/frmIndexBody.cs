using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace TrolyaoFara
{
    public partial class frmIndexBody : Form
    {
        LibFunction lib = new LibFunction();
        checkInputValue check = new checkInputValue();
        Database databaseObject = new Database();
        public delegate void GETDATA(string data);
        public GETDATA mydata;

        private string _message;
        public string dataFromDashboard
        {
            get { return _message; }
            set { _message = value; }
        }

        int weight, height, neck, waist, hip, intensity;
        long iduser;
        int currentIDSelect = 0;

        public frmIndexBody()
        {
            InitializeComponent();
        }

        private void frmIndexBody_Load(object sender, EventArgs e)
        {
            getAllInfoRow();
            chooseDataLoadToForm();

            grboxInfoBasic.Enabled = false;
            btnDelete.Enabled = false;
            if (_message == "2.2.1") // Gọi từ Account Settings
                plnCustom.Hide();
        }

        private void chooseMainUser()
        {
            currentIDSelect = 0;
            cbxListUser.SelectedIndex = currentIDSelect;
            chooseDataLoadToForm();
        }

        #region LoadInfo
        private void getAllInfoRow()
        {
            cbxListUser.Items.Clear();
            cbxListUser.Items.Add(lib.GetUsername());
            //List<string> listUserLocal = lib.getUserLocal();
            List<string> listUserLocal = new List<string>();
            List<int> listIDUserLocal = new List<int>();
            lib.getUserLocal(listUserLocal, listIDUserLocal);
            foreach (var user in listUserLocal)
            {
                cbxListUser.Items.Add(user);
            }
            cbxListUser.StartIndex = 0;
        }

        private void getDataFromInfoTable(string sql, bool adv = false) // adv = true -> Load thêm info basic
        {
            neck = waist = hip = 0; // Reset data
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                iduser = Convert.ToInt32(rd["iduser"]);
                if (adv)
                {
                    grboxInfoBasic.Enabled = true;
                    btnDelete.Enabled = true;
                    txtFullname.Text = cbxListUser.Text;
                    try
                    {
                        DateTime b_day = Convert.ToDateTime(rd["birthday"]);
                        DateTime UTCNow = DateTime.UtcNow;
                        int old = UTCNow.Year - b_day.Year;
                        txtOld.Text = old.ToString();
                    }
                    catch(Exception)
                    {
                        txtOld.Text = "";
                    }

                    cbxGender.SelectedIndex = Convert.ToInt32(rd["gender"]) - 1;
                }
                height = Convert.ToInt32(rd["height"]);
                weight = Convert.ToInt32(rd["weight"]);
                try
                {
                    neck = Convert.ToInt32(rd["neck"]);
                    waist = Convert.ToInt32(rd["waist"]);
                    hip = Convert.ToInt32(rd["hip"]);
                    intensity = Convert.ToInt32(rd["intensity"]);
                }
                catch(Exception) { }
            }
            command.Dispose();
            databaseObject.CloseConnection();

            //Load Data in textbox
            if (height > 0)
                txtHeight.Text = height.ToString();
            if (weight > 0)
                txtWeight.Text = weight.ToString();
            if (neck > 0)
            {
                txtNeck.Text = neck.ToString();
                checkSkip.Checked = false;
                pnlIndexbody.Enabled = true;
            }
            else
            {
                checkSkip.Checked = true;
                pnlIndexbody.Enabled = false;
            }
            if (waist > 0)
                txtWaist.Text = waist.ToString();
            if (hip > 0)
                txtHip.Text = hip.ToString();
            if (intensity != -1)
                cbxIntensity.SelectedIndex = intensity;
        }
        #endregion

        #region BtnLoadData_and_BtnReset
        private void chooseDataLoadToForm()
        {
            if (currentIDSelect == -1)
            {
                resetDataAndBtn();
                grboxInfoBasic.Enabled = true;
                btnCreateInfo.Enabled = false;
                btnDelete.Enabled = true;
                txtFullname.Focus();
            }
            else if (currentIDSelect > 0)
            {
                string sql = string.Format("SELECT * FROM info WHERE fname = '{0}'", cbxListUser.Text);
                getDataFromInfoTable(sql, true);
            }
            else
            {
                string sql = string.Format("SELECT * FROM info WHERE iduser='{0}'", lib.GetID());
                getDataFromInfoTable(sql);
            }
        }

        private void resetDataAndBtn()
        {
            grboxInfoBasic.Enabled = false;
            btnDelete.Enabled = false;
            btnCreateInfo.Enabled = true;
            txtFullname.ResetText();
            txtOld.ResetText();
            cbxGender.SelectedIndex = -1;
            txtHeight.ResetText();
            txtWeight.ResetText();
            cbxIntensity.SelectedIndex = -1;
            txtNeck.ResetText();
            txtWaist.ResetText();
            txtHip.ResetText();
        }

        private void btnLoadInfoUser_Click(object sender, EventArgs e)
        {
            resetDataAndBtn();
            currentIDSelect = cbxListUser.SelectedIndex;
            chooseDataLoadToForm();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbxListUser.SelectedIndex = currentIDSelect;
            chooseDataLoadToForm();
        }
        #endregion

        #region CreateAndUpdateInfo
        private void btnCreateInfo_Click(object sender, EventArgs e)
        {
            resetDataAndBtn();
            btnLoadInfoUser.Enabled = false;
            currentIDSelect = -1;
            cbxListUser.SelectedIndex = currentIDSelect;
            grboxInfoBasic.Enabled = true;
            btnCreateInfo.Enabled = false;
            txtFullname.Focus();
            btnDelete.Text = "Hủy";
            btnDelete.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentIDSelect != -1)
                checkInput(false);
            else // Add new info
                checkInput(true);
        }

        private void checkInput(bool action) // 'action' using in 'createOrUpdateInfo' function
        {
            bool grBasicInfo = true;

            if (currentIDSelect != 0)
            {
                if (string.IsNullOrEmpty(txtFullname.Text))
                {
                    alert.Show("Vui lòng nhập tên!", alert.AlertType.error);
                    grBasicInfo = false;
                }
                else if (!check.validateOld(txtOld.Text))
                    grBasicInfo = false;
                else if (cbxGender.SelectedIndex == -1)
                {
                    alert.Show("Vui lòng lựa chọn giới tính!", alert.AlertType.error);
                    grBasicInfo = false;
                }
            }

            if (grBasicInfo)
            {
                if (!check.validateHeight(txtHeight.Text)) { }
                else if (!check.validateWeight(txtWeight.Text)) { }
                else if (cbxIntensity.SelectedIndex == -1)
                    alert.Show("Vui lòng lựa chọn cường độ vận động \ncủa bạn!", alert.AlertType.error, 88);
                else if (checkSkip.Checked == false)
                {
                    if (!check.validateNeck(txtNeck.Text)) { }
                    else if (!check.validateWaist(txtWaist.Text)) { }
                    else if (!check.validateHip(txtHip.Text)) { }
                    else
                        createOrUpdateInfo(action);
                }
                else if (checkSkip.Checked == true)
                {
                    txtNeck.ResetText();
                    txtWaist.ResetText();
                    txtHip.ResetText();
                    createOrUpdateInfo(action);
                }
            }
        }

        private int setIDForNewUser()
        {
            databaseObject.OpenConnection();
            string sql = "SELECT MIN(iduser) FROM info";
            SQLiteCommand cmd = new SQLiteCommand(sql, databaseObject.myConnection);
            return Convert.ToInt32(cmd.ExecuteScalar()) - 1;
        }

        private string setBirthdayForSubInfo() 
        {
            var UTCNow = DateTime.Now;
            var birthday = UTCNow.AddYears(-Convert.ToInt32(txtOld.Text));
            return birthday.ToString();
        }

        //action: True => create
        private void createOrUpdateInfo(bool action)
        {
            if (action)
            {
                string strInsert = string.Format("INSERT INTO info(iduser, fname, gender, birthday, height, weight, intensity, neck, waist, hip) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", setIDForNewUser(), txtFullname.Text, cbxGender.SelectedIndex + 1, setBirthdayForSubInfo(), txtHeight.Text, txtWeight.Text, cbxIntensity.SelectedIndex, txtNeck.Text, txtWaist.Text, txtHip.Text);
                databaseObject.RunSQL(strInsert);
                alert.Show("Đã thêm thông tin!", alert.AlertType.success);
                btnDelete.Text = "Xóa";
                btnCreateInfo.Enabled = true;
                getAllInfoRow();
                currentIDSelect = cbxListUser.Items.Count - 1;
                cbxListUser.SelectedIndex = currentIDSelect;
                chooseDataLoadToForm();
            }
            else
            {
                string strUpdate;
                if (currentIDSelect == 0)
                    strUpdate = string.Format("UPDATE info set height='{0}', weight='{1}', intensity='{2}', neck='{3}', waist='{4}', hip='{5}' where iduser='{6}'", txtHeight.Text, txtWeight.Text, cbxIntensity.SelectedIndex, txtNeck.Text, txtWaist.Text, txtHip.Text, iduser);
                else
                {
                    string idUser = iduser.ToString().Replace("-", "A");
                    if (lib.CheckExists("family_member", "id_member", -1, idUser))
                    {
                        string strUdpate = string.Format("UPDATE family_member set username='{0}' where id_member='{1}'", txtFullname.Text +" ★", idUser);
                        databaseObject.RunSQL(strUdpate);
                    }
                    strUpdate = string.Format("UPDATE info set fname='{0}', gender='{1}', birthday='{2}', height='{3}', weight='{4}', intensity='{5}', neck='{6}', waist='{7}', hip='{8}' where iduser='{9}'", txtFullname.Text, cbxGender.SelectedIndex + 1, setBirthdayForSubInfo(), txtHeight.Text, txtWeight.Text, cbxIntensity.SelectedIndex, txtNeck.Text, txtWaist.Text, txtHip.Text, iduser);
                }
                databaseObject.RunSQL(strUpdate);
                alert.Show("Cập nhật thông tin thành công!", alert.AlertType.success);
                if (_message == "2.2.1")
                    mydata("2");
            }
            btnLoadInfoUser.Enabled = true;
        }
        #endregion
       
        //Btn Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Text == "Hủy")
            {
                resetDataAndBtn();
                btnDelete.Text = "Xóa";
                chooseMainUser();
                btnLoadInfoUser.Enabled = true;
            }
            else
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.No) { }
                else
                {
                    string strDelete = string.Format("DELETE FROM info WHERE iduser = '{0}'", iduser);
                    databaseObject.RunSQL(strDelete);
                    alert.Show("Đã xóa!", alert.AlertType.success);
                    btnCreateInfo.Enabled = true;
                    getAllInfoRow();
                    chooseMainUser();
                }
            }
        }

        #region SettingForm
        private void checkSkip_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSkip.Checked == true)
                pnlIndexbody.Enabled = false;
            else
                pnlIndexbody.Enabled = true;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_message == "2.2.1") // Gọi từ Account Settings
            {
                lblTab.Text = "2.1";
                mydata(lblTab.Text);
            }
            if (_message == "2.2.2") // Gọi từ tabHome
            {
                lblTab.Text = "4";
                mydata(lblTab.Text);
            }
            if (_message == "2.2.3") // Gọi từ SettingMenu
            {
                lblTab.Text = "3";
                mydata(lblTab.Text);
            }
        }

        private void txtOld_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtNeck_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtWaist_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void txtHip_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }
        #endregion
    }
}
