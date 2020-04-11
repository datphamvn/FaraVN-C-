using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
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
        SQLquery sql = new SQLquery();
        SettingSever sSever = new SettingSever();
        CalculateMacro cMacro = new CalculateMacro();
        GAVer2 GA = new GAVer2();
        GACal gaCal = new GACal();

        public delegate void GETDATA(string data);
        public GETDATA mydata;

        long iduser;
        int mode, level;
        int old, weight, height, neck, waist, hip, gender, intensity;// Nam 1; Nữ 2
        double calo;

        //Tab family variable
        int sumProtein = 0, sumLipid = 0, sumCarb = 0, sumCalo = 0;
        string textUsername = "Nhập username";
        List<string> listUsername = new List<string>();
        List<long> listIDUsername = new List<long>();
        List<string> listUserLocal = new List<string>();

        public frmSettingsMenu()
        {
            InitializeComponent();
        }

        private void frmSettingsMenu_Load(object sender, EventArgs e)
        {
            sql.createTableForDatabase(); // Dev Line
            sql.SQLforMenuTable(Convert.ToInt32(numBreakfast.Value), Convert.ToInt32(numLunch.Value), Convert.ToInt32(numDinner.Value));
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

            datatableFamily.Rows.Add(iduser, lib.GetUsername());
            loadUserOnline();
            loadUserLocal();
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
        private void getDataForTabPersonal(long iduser)
        {
            string sql = string.Format("SELECT * FROM info WHERE iduser='{0}'", iduser);
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                DateTime b_day = Convert.ToDateTime(rd["birthday"]);
                DateTime UTCNow = DateTime.UtcNow;
                old = UTCNow.Year - b_day.Year;

                height = Convert.ToInt32(rd["height"]);
                weight = Convert.ToInt32(rd["weight"]);
                neck = Convert.ToInt32(rd["neck"]);
                waist = Convert.ToInt32(rd["waist"]);
                hip = Convert.ToInt32(rd["hip"]);
                gender = Convert.ToInt32(rd["gender"]);
                intensity = Convert.ToInt32(rd["gender"]);
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

        private void calMacroGeneral(int mod)
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

            if(mod == 1) //tab Personal
            {
                string strUpdate = string.Format("UPDATE menu set calo='{0}', protein='{1}', lipid='{2}', carb='{3}' where id='{4}'", Convert.ToInt32(calo), protein, lipid, carb, 1);
                databaseObject.RunSQL(strUpdate);
            }
            if(mod == 2) // Tab family
            {
                sumProtein += protein;
                sumLipid += lipid;
                sumCarb += carb;
                sumCalo += Convert.ToInt32(calo);
            }
        }

        private void calMacroNutriForPersonal()
        {
            getDataForTabPersonal(iduser);
            calMacroGeneral(1);
        }

        public void generateMenuForToday()
        {
            calMacroNutriForPersonal(); // Main Account
            GA.MainGA();
            gaCal.RunGACal();
        }

      

        private void btnRun_Click(object sender, EventArgs e)
        {
            //Save settings
            sql.SQLforSettingsMenu(Convert.ToInt32(numBreakfast.Value), Convert.ToInt32(numLunch.Value), Convert.ToInt32(numDinner.Value), cbxMode.SelectedIndex, Convert.ToInt32(numLevel.Value), trackbarProtein.Value, trackbarLipid.Value, trackbarCarb.Value, trackbarCaloBreakfast.Value, trackbarCaloLunch.Value, trackbarCaloDinner.Value);

            for (int i = 0; i < datatableFamily.Rows.Count - 1; i++)
            {
                string id = datatableFamily.Rows[i].Cells[0].Value.ToString();
                bool hide = Convert.ToBoolean(datatableFamily.Rows[i].Cells[3].Value);
                sql.SQLforMemberFamily(id, hide);
            }

            //Tab personal
            mode = cbxMode.SelectedIndex;
            if (mode == 0)
                level = 0;
            else
                level = Convert.ToInt32(numLevel.Value);


            //Code tạm
            string strUdpate = string.Format("UPDATE menu set calo='{0}' where id='{1}'", 1000, 1);
            databaseObject.RunSQL(strUdpate);



            generateMenuForToday();
            alert.Show("Test OK !", alert.AlertType.success);
        }

        #region TabFamily
        private async void loadUserOnline()
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
        
        private void loadUserLocal()
        {
            Action load = () => {
                listUserLocal = lib.getUserLocal();
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
            int subID = 1;
            foreach (var user in listUserLocal)
            {
                lstUsername.Items.Add(user + " ★");
                lstIDUsername.Items.Add(-subID);
                subID++;
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
                    this.datatableFamily.Rows.Add(idUser, itemsel);
                }
                else
                    alert.Show("Bạn đã thêm user này rồi!", alert.AlertType.error);
            }
        }

        private void datatableFamily_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datatableFamily.Columns[e.ColumnIndex].Name == "Delete" && datatableFamily.SelectedRows[0].Index != 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa user này khỏi dánh sách không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    datatableFamily.Rows.RemoveAt(datatableFamily.SelectedRows[0].Index);
            }
            if (datatableFamily.Columns[e.ColumnIndex].Name == "Hide" && datatableFamily.SelectedRows[0].Index == 0)
                alert.Show("Tick để tạo suất ăn cho thành viên đó!", alert.AlertType.info);
        }
        #endregion


        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            
        }
        //Btn tạo mới 

        private void gunaGradientButton5_Click(object sender, EventArgs e)
        {
            mydata("2.2.3");
        }



        private void getInfoUserLocal(string id)
        {
            id = id.Replace("A", "-");
            string sql = string.Format("SELECT * FROM info WHERE iduser = '{0}'", Convert.ToInt32(id));

            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                DateTime b_day = Convert.ToDateTime(rd["birthday"]);
                DateTime UTCNow = DateTime.UtcNow;
                int old = UTCNow.Year - b_day.Year;

                height = Convert.ToInt32(rd["height"]);
                weight = Convert.ToInt32(rd["weight"]);
                neck = Convert.ToInt32(rd["neck"]);
                waist = Convert.ToInt32(rd["waist"]);
                hip = Convert.ToInt32(rd["hip"]);
                gender = Convert.ToInt32(rd["gender"]);
            }
            command.Dispose();
            databaseObject.CloseConnection();

            calMacroGeneral(2);
        }

        private void calMacroNutriForFamily()
        {

            for(int i = 0; i < datatableFamily.Rows.Count - 1; i++)
            {
                string id = datatableFamily.Rows[i].Cells[0].Value.ToString();
                if(id[0] == 'A') // Ktra User local
                {
                    getInfoUserLocal(id);
                }
                else // Ktra user sever
                {
                    int idSubUser = Convert.ToInt32(id);
                    frmLogin frm = new frmLogin();
                    frm.getInfoUserFormServer(Convert.ToInt32(idSubUser));
                    getDataForTabPersonal(idSubUser);
                    calMacroGeneral(2);
                }
            }
            /*
            for (int i = 0; i < datatableFamily.Rows.Count - 1; i++)
            {
                for (int j = 0; j < datatableFamily.Columns.Count; j++)
                {
                    if()
                    worksheet.Cells[i + 2, j + 1] = gunaDataGridView2.Rows[i].Cells[j].Value.ToString();
                }
            }


            if (true) // id dòng 1 = id user chính -> Tính cal riêng
            {
                calMacroNutriForPersonal();
            }

            */


            // Update data into table menu
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
    }
}
