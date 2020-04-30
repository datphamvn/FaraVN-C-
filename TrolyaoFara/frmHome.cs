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
    public partial class frmHome : Form
    {
        Database databaseObject = new Database();
        LibFunction lib = new LibFunction();
        CalculateMacro calMacro = new CalculateMacro();
        public delegate void GETDATA(string data);
        public GETDATA mydata;

        public frmHome()
        {
            InitializeComponent();
        }

        private void LoadInfoinForm()
        {
            //gunaCirclePictureBox1.Image = Image.FromFile(lData.loginimg);
            string sql = string.Format("SELECT * FROM info WHERE iduser='{0}'", lib.GetID());
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                
                // Giới tính  1-Nam ; 2-Nữ
                int gender = Convert.ToInt32(rd["gender"]);
                if (gender == 1)
                {
                    picMale.Show();
                    picFemale.Hide();
                }
                else
                {
                    picFemale.Show();
                    picMale.Hide();
                }

                //FullName
                lblHello.Text = "Hi, " + rd["fname"];
                int panelWidth = panel1.Width;
                lblHello.Left = (panelWidth - lblHello.Width) / 2;

                //Birday_User
                DateTime b_day = Convert.ToDateTime(rd["birthday"]);
                DateTime UTCNow = DateTime.UtcNow;
                int old = UTCNow.Year - b_day.Year;
                lblOld.Text = old.ToString();

                // Healthy Index
                int weight = Convert.ToInt32(rd["weight"]);
                int height = Convert.ToInt32(rd["height"]);
                panelWidth = bunifuGradientPanel1.Width;
                lblHeight.Text = height.ToString() + " cm";
                lblHeight.Left = panelWidth - (lblHeight.Width);

                lblWeight.Text = weight.ToString() + " kg";
                lblWeight.Left = panelWidth - (lblWeight.Width);

                double BMI = calMacro.BMI(weight,height);
                lblBMI.Text = String.Format("{0:0.00}", BMI);
                lblBMI.Left = panelWidth - (lblBMI.Width);

                string type = "", warning = "";
                calMacro.TypeOfBody(BMI, ref type, ref warning);
                lblType.Text = type;
                lblWarning.Text = warning;
                lblType.Left = panelWidth - (lblType.Width);
                lblWarning.Left = panelWidth - (lblWarning.Width);

                // Lượng nước
                lblWater.Text = String.Format("{0:0.00}", weight * 0.033) + " L";

                //% Mỡ
                int neck = Convert.ToInt32(rd["neck"]);
                if (neck != 0)
                {
                    plnTypeOfBody.Hide();
                    plnFatPercent.Show();
                    double BodyFat = calMacro.BodyFat(height, neck, Convert.ToInt32(rd["waist"]), Convert.ToInt32(rd["hip"]), gender);
                    lblFatPercent.Text = String.Format("{0:0.00}", BodyFat) + " %";

                    lblWarmingBodyFat.Text = calMacro.TypeOfBody2(BodyFat, gender);
                    lblWarmingBodyFat.Left = plnFatPercent.Width - (lblWarmingBodyFat.Width);
                }
                else
                    plnFatPercent.Hide();
            }
            command.Dispose();
            databaseObject.CloseConnection();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            LoadInfoinForm();
        }

        private void btnOpenIndexBody_Click(object sender, EventArgs e)
        {
            lblTab.Text = "2.2.2";
            mydata(lblTab.Text);
        }
    }
}
