using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrolyaoFara
{
    public partial class frmSettingsMenu : Form
    {
        LibFunction lib = new LibFunction();
        Database databaseObject = new Database();
        SQLquery runSQL = new SQLquery();
        SettingSever sSever = new SettingSever();
        CalculateMacro cMacro = new CalculateMacro();
        GAVer2 GA = new GAVer2();
        GACal gaCal = new GACal();

        public delegate void GETDATA(string data);
        public GETDATA mydata;

        long iduser;
        int mode, level, mod;
        int old, weight, height, neck, waist, hip, gender, intensity;// Male 1; Female 2
        double calo;

        //Tab family variable
        int sumProtein = 0, sumLipid = 0, sumCarb = 0, sumCalo = 0;
        string textUsername = "Nhập username";
        List<string> listUsername = new List<string>();
        List<long> listIDUsername = new List<long>();
        List<string> listUserLocal = new List<string>();
        List<int> listIDUserLocal = new List<int>();

        public frmSettingsMenu()
        {
            InitializeComponent();
        }

        private void frmSettingsMenu_Load(object sender, EventArgs e)
        {
            runSQL.createTableForDatabase(); // Dev Line
            iduser = lib.GetID();

            //Setting TabControl
            metroTabControl.SelectedTab = tabSelection;
            metroTabControl.Height = 545;
            lib.HideAllTabsOnTabControl(metroTabControl);

            //Setting General
            tabcontrolAdvanced.SelectedTab = metroTabPage1;
            DefaultSetPercentNutri(); // Defaut value Tab1 of Adv settings
            SetValue(30, 40, 30, 2); // Defaut value Tab2 of Adv settings

            //Tab Personal
            plnLevel.Hide();

            //Tab Family
            txtUsername.Enabled = false;
            lstUsername.Hide();
            //Settings Datagridview tab Family
            datatableFamily.ReadOnly = false;
            datatableFamily.Columns[0].ReadOnly = true;
            datatableFamily.Columns[1].ReadOnly = true;
            datatableFamily.Columns[2].ReadOnly = true;

            datatableFamily.Rows.Add(iduser, lib.GetUsername());
            loadMemberFamilyToDGV();
            loadUserOnlineToTxtSearch();
            loadUserLocalToTxtSearch();
        }

        #region TabControlSettings
        private void metroTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl.SelectedTab == tabSelection)
                metroTabControl.Height = 545;
            else
                metroTabControl.Height = 260;
        }

        private void btnBacktabSelection_Click(object sender, EventArgs e)
        {
            metroTabControl.SelectedTab = tabSelection;
            metroTabControl.Height = 545;
        }

        private void btnGoTabPersonal_Click(object sender, EventArgs e)
        {
            metroTabControl.SelectedTab = tabPersonal;
        }

        private void btnTabFamily_Click(object sender, EventArgs e)
        {
            metroTabControl.SelectedTab = tabFamily;
        }
        #endregion

        #region Setting
        private void btnBack_Click(object sender, EventArgs e)
        {
            mydata("1");
        }

        private void btnResetSetting_Click(object sender, EventArgs e)
        {
            //Chung
            numBreakfast.Value = 1;
            numLunch.Value = 4;
            numDinner.Value = 4;
            DefaultSetPercentNutri();
            SetValue(30, 40, 30, 2); // DefaultSetPercentCaloinDay
            //Textbox
            txtUsername.Text = textUsername;
            txtUsername.ForeColor = Color.Gray;

            //Tab Personal
            cbxMode.SelectedIndex = 0;
            plnLevel.Hide();
        }

        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }
        #region SettingTextbox
        //TabFamily
        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = textUsername;
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == textUsername)
            {
                txtUsername.ResetText();
                txtUsername.ForeColor = Color.Black;
            }
        }
        #endregion
        #region Setting Numeric
        decimal prevLunchValue = 0;
        private void numLunch_ValueChanged(object sender, EventArgs e)
        {
            if (numLunch.Value < prevLunchValue && numLunch.Value == 2)
            {
                numLunch.Value = 0;
            }
            else if (numLunch.Value > prevLunchValue && numLunch.Value == 1)
            {
                numLunch.Value = 3;
            }
            prevLunchValue = numLunch.Value;
        }

        decimal prevDinnerLValue = 0;
        private void numDinner_ValueChanged(object sender, EventArgs e)
        {
            if (numDinner.Value < prevDinnerLValue && numDinner.Value == 2)
            {
                numDinner.Value = 0;
            }
            else if (numDinner.Value > prevDinnerLValue && numDinner.Value == 1)
            {
                numDinner.Value = 3;
            }
            prevDinnerLValue = numDinner.Value;
        }
        #endregion
        #region Setting_PercentBar
        //Tab1: Tỉ lệ dinh dưỡng
        //Tab2: Tỉ lệ NL trong ngày
        private void SetValue(int value1, int value2, int value3, int tab)
        {
            if (tab == 1)
            {
                trackbarProtein.Value = value1;
                trackbarLipid.Value = value2;
                trackbarCarb.Value = value3;
                lblProteinPercent.Text = value1.ToString() + " %";
                lblLipidPercent.Text = value2.ToString() + " %";
                lblCarbPercent.Text = value3.ToString() + " %";
                lblTotalPercent.Text = "100 %";
            }
            else
            {
                trackbarCaloBreakfast.Value = value1;
                trackbarCaloLunch.Value = value2;
                trackbarCaloDinner.Value = value3;
                lblCaloBreakfast.Text = value1.ToString() + " %";
                lblCaloLunch.Text = value2.ToString() + " %";
                lblCaloDinner.Text = value3.ToString() + " %";
                lblSumCaloPercent.Text = "100 %";
            }
        }

        private void sumPercent(int tab)
        {
            if(tab == 1)
                lblTotalPercent.Text = (trackbarProtein.Value + trackbarLipid.Value + trackbarCarb.Value).ToString() + " %";
            else
                lblSumCaloPercent.Text = (trackbarCaloBreakfast.Value + trackbarCaloLunch.Value + trackbarCaloDinner.Value).ToString() + " %";
        }
        #endregion
        #region PercentMacronutri
        private void DefaultSetPercentNutri()
        {
            if (old < 18)
                SetValue(18, 25, 57, 1);
            else
                SetValue(14, 20, 66, 1);
        }

        private void btnHightCarb_Click(object sender, EventArgs e)
        {
            SetValue(30, 15, 55, 1);
        }

        private void btnMidCarb_Click(object sender, EventArgs e)
        {
            SetValue(35, 25, 40, 1);
        }

        private void btnLowCarb_Click(object sender, EventArgs e)
        {
            SetValue(45, 35, 20, 1);
        }

        private void btnCustomCarb_Click(object sender, EventArgs e)
        {
            DefaultSetPercentNutri();
        }

        private void trackbarProtein_ValueChanged(object sender, EventArgs e)
        {
            lblProteinPercent.Text = trackbarProtein.Value.ToString() + " %";
            sumPercent(1);
        }

        private void trackbarLipid_ValueChanged(object sender, EventArgs e)
        {
            lblLipidPercent.Text = trackbarLipid.Value.ToString() + " %";
            sumPercent(1);
        }

        private void trackbarCarb_ValueChanged(object sender, EventArgs e)
        {
            lblCarbPercent.Text = trackbarCarb.Value.ToString() + " %";
            sumPercent(1);
        }
        #endregion
        #region PercentCaloOfDay
        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            SetValue(30, 40, 30, 2);
        }

        private void trackbarCaloBreakfast_ValueChanged(object sender, EventArgs e)
        {
            lblCaloBreakfast.Text = trackbarCaloBreakfast.Value.ToString() + " %";
            sumPercent(2);
        }

        private void trackbarCaloLunch_ValueChanged(object sender, EventArgs e)
        {
            lblCaloLunch.Text = trackbarCaloLunch.Value.ToString() + " %";
            sumPercent(2);
        }

        private void trackbarCaloDinner_ValueChanged(object sender, EventArgs e)
        {
            lblCaloDinner.Text = trackbarCaloDinner.Value.ToString() + " %";
            sumPercent(2);
        }
        #endregion
        #endregion

        #region tabPersonal
        private void getDataPersonal(long iduser)
        {
            string sql = string.Format("SELECT * FROM info WHERE iduser='{0}'", iduser);
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                DateTime b_day;
                try
                {
                    b_day = DateTime.Parse(rd["birthday"].ToString());
                }
                catch (Exception)
                {
                    b_day = DateTime.ParseExact(rd["birthday"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                DateTime UTCNow = DateTime.UtcNow;
                old = UTCNow.Year - b_day.Year;

                height = Convert.ToInt32(rd["height"]);
                weight = Convert.ToInt32(rd["weight"]);
                neck = Convert.ToInt32(rd["neck"]);
                waist = Convert.ToInt32(rd["waist"]);
                hip = Convert.ToInt32(rd["hip"]);
                gender = Convert.ToInt32(rd["gender"]);
                intensity = Convert.ToInt32(rd["intensity"]);
            }
            command.Dispose();
            databaseObject.CloseConnection();
        }

        private void cbxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idxSelect = cbxMode.SelectedIndex;
            if (idxSelect == 0)
                plnLevel.Hide();
            else
            {
                plnLevel.Show();
                numLevel.Value = 1;
                if (idxSelect == 1)
                    lblStrLevel.Text = "Giảm 0,25 kg/tuần";
                else
                    lblStrLevel.Text = "Tăng 0,25 kg/tuần";
            }
        }

        private void numLevel_ValueChanged(object sender, EventArgs e)
        {
            string strLevel = "";
            if (cbxMode.SelectedIndex == 1)
                strLevel += "Giảm ";
            else
                strLevel += "Tăng ";

            if (numLevel.Value == 1)
                strLevel += "0,25 kg/tuần";
            else if (numLevel.Value == 2)
                strLevel += "0,5 kg/tuần";
            else
            {
                strLevel += "1 kg/tuần";
                alert.Show("Tham khảo ý kiến của bác sĩ trước khi \n thực hiện chế độ này !", alert.AlertType.warning, 86);
            }
            lblStrLevel.Text = strLevel;
        }
        #endregion

        public void calMacroGeneral()
        {
            int protein = trackbarProtein.Value;
            int lipid = trackbarLipid.Value;
            int carb = trackbarCarb.Value;
            double BMR, TDEE;

            if (neck == 0)
                BMR = cMacro.Miffin_St_jeor(weight, height, old, gender);
            else
            {
                double bodyFat = cMacro.BodyFat(height, neck, waist, hip, gender);
                BMR = cMacro.Katch_McArdle(weight, bodyFat);
            }
            TDEE = cMacro.TDEE(BMR, intensity);
            cMacro.macroCalo(BMR, TDEE, mode, level, ref protein, ref lipid, ref carb, ref calo);

            if (mod == 1) //tab Personal
            {
                runSQL.SQLforMenuTable(Convert.ToInt32(numBreakfast.Value), Convert.ToInt32(numLunch.Value), Convert.ToInt32(numDinner.Value), Convert.ToInt32(calo), protein, lipid, carb, mod);
            }
            if(mod == 2) // Tab family
            {
                sumProtein += protein;
                sumLipid += lipid;
                sumCarb += carb;
                sumCalo += Convert.ToInt32(calo);
            }
        }

        public void generateMenuForToday(int mod)// Update function
        {
            if(mod == 1)
            {
                getDataPersonal(iduser);
                calMacroGeneral();
            }
            if(mod == 2)
                calMacroNutriForFamily();

            GA.MainGA();
            gaCal.RunGACal();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (metroTabControl.SelectedTab == metroTabControl.TabPages["tabPersonal"])
            {
                mod = 1;
                //Get level tab personal
                mode = cbxMode.SelectedIndex;
                if (mode == 0)
                    level = 0;
                else
                    level = Convert.ToInt32(numLevel.Value);
            }

            if (metroTabControl.SelectedTab == metroTabControl.TabPages["tabFamily"])
            {
                mod = 2;
                //Save data member family
                for (int i = 0; i < datatableFamily.Rows.Count; i++)
                {
                    string id = datatableFamily.Rows[i].Cells[0].Value.ToString();
                    string username = datatableFamily.Rows[i].Cells[1].Value.ToString();
                    bool hide = Convert.ToBoolean(datatableFamily.Rows[i].Cells[3].Value);
                    runSQL.SQLforMemberFamily(id, username, hide);
                }
            }
            //Save settings
            runSQL.SQLforSettingsMenu(Convert.ToInt32(numBreakfast.Value), Convert.ToInt32(numLunch.Value), Convert.ToInt32(numDinner.Value), cbxMode.SelectedIndex, Convert.ToInt32(numLevel.Value), trackbarProtein.Value, trackbarLipid.Value, trackbarCarb.Value, trackbarCaloBreakfast.Value, trackbarCaloLunch.Value, trackbarCaloDinner.Value, mod);

            generateMenuForToday(mod);
            alert.Show("Test OK !", alert.AlertType.success);
        }

        public void calMacroNutriForFamily()
        {
            for (int i = 0; i < datatableFamily.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(datatableFamily.Rows[i].Cells[3].Value)) // User không bị ẩn
                {
                    string id = datatableFamily.Rows[i].Cells[0].Value.ToString();
                    if(i == 0) // Main account
                    {
                        getDataPersonal(Convert.ToInt32(id));
                        calMacroGeneral();
                    }
                    else if (id[0] == 'A') // Ktra User local
                    {
                        id = id.Replace("A", "-");
                        getDataPersonal(Convert.ToInt32(id));
                        calMacroGeneral();
                    }
                    else // Ktra user sever
                    {
                        int idSubUser = Convert.ToInt32(id);
                        frmLogin frm = new frmLogin();
                        frm.getInfoUserFormServer(Convert.ToInt32(idSubUser));
                        getDataPersonal(idSubUser);
                        calMacroGeneral();
                    }
                }
            }
            runSQL.SQLforMenuTable(Convert.ToInt32(numBreakfast.Value), Convert.ToInt32(numLunch.Value), Convert.ToInt32(numDinner.Value), sumCalo, sumProtein, sumLipid, sumCarb, mod);
        }

        #region TabFamily
        private void loadMemberFamilyToDGV()
        {
            int idx = 0;
            string sql = string.Format("SELECT * FROM family_member");
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                if (idx == 0)
                {
                    idx++;
                    continue;
                }
                string idStr = rd["id_member"].ToString();
                string username = rd["username"].ToString();
                bool hide = Convert.ToBoolean(rd["hide"]);
                datatableFamily.Rows.Add(idStr, username);
                datatableFamily.Rows[idx].Cells[3].Value = hide;
                idx++;
            }
            command.Dispose();
            databaseObject.CloseConnection();

        }

        private async void loadUserOnlineToTxtSearch()
        {
            Action load = () => {
                if (lib.CheckForInternetConnection())
                {
                    using (WebClient wc = new WebClient())
                    {
                        var json = wc.DownloadString(sSever.linksever + "dashboard/api/user/");
                        List<DetailUser> data = JsonConvert.DeserializeObject<List<DetailUser>>(json);
                        foreach (var item in data)
                        {
                            byte[] bytes = Encoding.Default.GetBytes(item.Username.ToString());
                            string temp = Encoding.UTF8.GetString(bytes);
                            listUsername.Add(temp);
                            listIDUsername.Add(item.Id);
                        }
                    }
                }
                else
                    alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
            };
            Task task = new Task(load);
            task.Start();
            await task;

            txtUsername.Enabled = true;
            loadUsername.Hide();
        }

        private void loadUserLocalToTxtSearch()
        {
            Action load = () => {
                //listUserLocal = lib.getUserLocal();
                lib.getUserLocal(listUserLocal, listIDUserLocal);
            };
            Task task = new Task(load);
            task.Start();
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            lstUsername.Items.Clear();
            lstIDUsername.Items.Clear();
            txtUsername.ForeColor = Color.Black;

            if (!(string.IsNullOrEmpty(txtUsername.Text.Trim()) || txtUsername.Text == textUsername))
            {
                int idx = 0;
                foreach (string str in listUsername)
                {
                    if (str.ToUpper().Contains(txtUsername.Text.ToUpper()))
                    {
                        lstUsername.Items.Add(str);
                        lstIDUsername.Items.Add(listIDUsername[idx]);
                    }
                    idx++;
                }
            }
            else
                lstUsername.Hide();
            lstUsername.Show();
            // Add user local
            int idUser = 0;
            foreach (var user in listUserLocal)
            {
                lstUsername.Items.Add(user + " ★");
                lstIDUsername.Items.Add(listIDUserLocal[idUser]);
                idUser++;
            }
        }

        private void btnAddtabFamily_Click(object sender, EventArgs e)
        {
            string itemsel = lstUsername.GetItemText(lstUsername.SelectedItem);
            if (string.IsNullOrEmpty(itemsel))
                return;

            bool found = false;

            if (datatableFamily != null)
            {
                foreach (DataGridViewRow item in datatableFamily.Rows)
                {
                    if (item.Cells["Username"].Value.ToString() == itemsel)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    lstIDUsername.SelectedIndex = lstUsername.Items.IndexOf(lstUsername.SelectedItem);
                    string idUser = lstIDUsername.GetItemText(lstIDUsername.SelectedItem);
                    datatableFamily.Rows.Add(idUser.Replace("-", "A"), itemsel);
                }
                else
                    alert.Show("Bạn đã thêm user này rồi!", alert.AlertType.error);
            }
        }
        private void datatableFamily_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datatableFamily.Columns[e.ColumnIndex].Name == "Delete" && datatableFamily.SelectedRows[0].Index > 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa '" + datatableFamily.SelectedRows[0].Cells[1].Value.ToString() + "' khỏi dánh sách không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strDelete = string.Format("DELETE FROM family_member where id_member='{0}'", datatableFamily.SelectedRows[0].Cells[0].Value.ToString());
                    databaseObject.RunSQL(strDelete);
                    datatableFamily.Rows.RemoveAt(datatableFamily.SelectedRows[0].Index);
                }
            }
        }

        private void datatableFamily_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (datatableFamily.Columns[e.ColumnIndex].Name == "Hide")
                alert.Show("Tick để hủy suất ăn của thành viên đó!", alert.AlertType.info);
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            mydata("2.2.3");
        }
        #endregion
    }
}
