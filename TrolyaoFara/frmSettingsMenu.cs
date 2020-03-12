using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
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
        CalculateMacro cMacro = new CalculateMacro();
        GAVer2 GA = new GAVer2();
        GACal gaCal = new GACal();

        int iduser, type, level;
        int old, weight, height, neck, waist, hip, gender;// Nam 1; Nữ 2

        double calo;

        public frmSettingsMenu()
        {
            InitializeComponent();
        }

        private void frmSettingsMenu_Load(object sender, EventArgs e)
        {
            //Setting TabControl
            metroTabControl.SelectedTab = tabSelection;
            metroTabControl.Height = 545;
            lib.HideAllTabsOnTabControl(metroTabControl);

            sql.createTableForDatabase();
            sql.SQLforMenuTable(Convert.ToInt32(numBreakfast.Value), Convert.ToInt32(numLunch.Value), Convert.ToInt32(numDinner.Value));
            iduser = lib.GetID();

            //Tab Personal
            DefaultSetPercentCalo();
            plnLevel.Hide();
        }

        #region TabSelection
        private void metroTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl.SelectedTab == tabSelection)
                metroTabControl.Height = 545;
        }

        private void btnGoTabPersonal_Click(object sender, EventArgs e)
        {
            metroTabControl.SelectedTab = tabPersonal;
            metroTabControl.Height = 240;
        }
        #endregion

        #region tabPersonal
        private void getDataForPersonal()
        {
            string sql = string.Format("SELECT * FROM info WHERE iduser='{0}'", iduser);
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
        }

        private void btnBacktabSelection_Click(object sender, EventArgs e)
        {
            metroTabControl.SelectedTab = tabSelection;
            metroTabControl.Height = 545;
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
                alert.Show("Tham khảo ý kiến của bác sĩ trước khi thực hiện chế độ này !", alert.AlertType.warning);
            }
            lblStrLevel.Text = strLevel;
        }
        #endregion

        private void btnRun_Click(object sender, EventArgs e)
        {
            //Tab personal
            type = cbxMode.SelectedIndex;
            if (type == 0)
                level = 0;
            else
                level = Convert.ToInt32(numLevel.Value);
            getDataForPersonal();
            calMacroNutriForPersonal();

            GA.MainGA();
            gaCal.RunGACal();
            alert.Show("Test OK !", alert.AlertType.success);
        }

        private void calMacroNutriForPersonal()
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
            TDEE = cMacro.TDEE(BMR, type);
            cMacro.macroCalo(BMR, TDEE, type, level, ref protein, ref lipid, ref carb, ref calo);

            string strUpdate = string.Format("UPDATE menu set calo='{0}', protein='{1}', lipid='{2}', carb='{3}' where id='{4}'", Convert.ToInt32(calo), protein, lipid, carb, 1);
            databaseObject.RunSQL(strUpdate);
        }

        #region Setting
        private void btnResetSetting_Click(object sender, EventArgs e)
        {
            //Chung
            numBreakfast.Value = 1;
            numLunch.Value = 4;
            numDinner.Value = 4;
            DefaultSetPercentCalo();

            //Tab Personal
            cbxMode.SelectedIndex = 0;
            plnLevel.Hide();
        }

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
        private void SetValue(int protein, int lipid, int carb)
        {
            trackbarProtein.Value = protein;
            trackbarLipid.Value = lipid;
            trackbarCarb.Value = carb;
            lblProteinPercent.Text = protein.ToString() + " %";
            lblLipidPercent.Text = lipid.ToString() + " %";
            lblCarbPercent.Text = carb.ToString() + " %";
            lblSumPercent.Text = "100 %";
        }

        private void DefaultSetPercentCalo()
        {
            if (old < 18)
                SetValue(18, 25, 57);
            else
                SetValue(14, 20, 66);
        }

        private void btnHightCarb_Click(object sender, EventArgs e)
        {
            SetValue(30, 15, 55);
        }

        private void btnMidCarb_Click(object sender, EventArgs e)
        {
            SetValue(35, 25, 40);
        }

        private void btnLowCarb_Click(object sender, EventArgs e)
        {
            SetValue(45, 35, 20);
        }

        private void btnCustomCarb_Click(object sender, EventArgs e)
        {
            DefaultSetPercentCalo();
        }

        private void trackbarProtein_ValueChanged(object sender, EventArgs e)
        {
            lblProteinPercent.Text = trackbarProtein.Value.ToString() + " %";
            sumPercent();
        }

        private void trackbarLipid_ValueChanged(object sender, EventArgs e)
        {
            lblLipidPercent.Text = trackbarLipid.Value.ToString() + " %";
            sumPercent();
        }

        private void trackbarCarb_ValueChanged(object sender, EventArgs e)
        {
            lblCarbPercent.Text = trackbarCarb.Value.ToString() + " %";
            sumPercent();
        }

        private void sumPercent()
        {
            lblSumPercent.Text = (trackbarProtein.Value + trackbarLipid.Value + trackbarCarb.Value).ToString() + " %";
        }
        #endregion
        #endregion

        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        GetData gd = new GetData();
        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            //frmIndexBody frm = new frmIndexBody();
            // frm.Show();
            //gd.MainGetData();
            //alert.Show("Download Data OK !", alert.AlertType.success);
            gd.MainGetData();
        }
        
        private void SaveSetting()
        {
            //Chung

        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {

        }


    
    }
}
