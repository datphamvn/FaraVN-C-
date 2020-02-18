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

        public frmHome()
        {
            InitializeComponent();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        LibFunction libfun = new LibFunction();
        void LoadInfoinForm()
        {
            gunaCirclePictureBox1.Image = Image.FromFile(lData.loginimg);
            string sql = string.Format("SELECT * FROM info WHERE iduser='{0}'", lib.GetID());
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                //FullName
                lblHello.Text = "Xin chào, " + rd["fname"];
                int panelWidth = panel1.Width;
                lblHello.Left = (panelWidth - lblHello.Width) / 2;

                //Birday_User
                DateTime b_day = Convert.ToDateTime(rd["birthday"]);
                DateTime UTCNow = DateTime.UtcNow;
                int old = UTCNow.Year - b_day.Year;
                lblOld.Text = old.ToString();

                // Healthy Index
                panelWidth = bunifuGradientPanel1.Width;
                lblHeight.Text = rd["height"] + " cm";
                lblHeight.Left = panelWidth - (lblHeight.Width);

                lblWeight.Text = rd["weight"] + " kg";
                lblWeight.Left = panelWidth - (lblWeight.Width);

                double BMI = Convert.ToInt32(rd["weight"]) / ((Convert.ToInt32(rd["height"]) * Convert.ToInt32(rd["height"])) / 10000.0);
                lblBMI.Text = String.Format("{0:0.00}", BMI);
                lblBMI.Left = panelWidth - (lblBMI.Width);

                string type = "", warning = "";
                libfun.TypeOfBody(BMI, ref type, ref warning);
                lblType.Text = type;
                lblWarning.Text = warning;
                lblType.Left = panelWidth - (lblType.Width);
                lblWarning.Left = panelWidth - (lblWarning.Width);

            }
            command.Dispose();
            databaseObject.CloseConnection();
           
        }
        static Random rd = new Random();
        LoadData lData = new LoadData();
        private void frmHome_Load(object sender, EventArgs e)
        {
            LoadInfoinForm();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
