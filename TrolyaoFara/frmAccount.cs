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
    public partial class frmAccount : Form
    {
        Database databaseObject = new Database();
        LibFunction lib = new LibFunction();

        public frmAccount()
        {
            InitializeComponent();
        }

        public delegate void GETDATA(string data);
        public GETDATA mydata;

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            lblTab.Text = "2.1";
            mydata(lblTab.Text);
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            databaseObject.OpenConnection();

            //Load InfoBasic
            string sql = string.Format("SELECT * FROM info WHERE iduser='{0}'", lib.GetID());
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                lblFullName.Text = rd["lname"].ToString() + " " + rd["fname"].ToString();
                lblBirthday.Text = Convert.ToDateTime(rd["birthday"].ToString()).ToString("dd/MM/yyyy");
                if (Convert.ToInt32(rd["gender"]) == 2)
                    lblGender.Text = "NỮ";
                else if (Convert.ToInt32(rd["gender"]) == 1)
                    lblGender.Text = "NAM";

                lblCountry.Text = rd["country"].ToString();
                lblCity.Text = rd["city"].ToString();
                lblDistrict.Text = rd["district"].ToString();
            }
            command.Dispose();

            //Load Favourite Food
            sql = string.Format("SELECT * FROM favorite");
            command = new SQLiteCommand(sql, databaseObject.myConnection);
            rd = command.ExecuteReader();
            while (rd.Read())
            {
                gunaDataGridView1.Rows.Add(rd["name_food"].ToString());
            }
            command.Dispose();

            //Load allergic
            sql = string.Format("SELECT * FROM allergic");
            command = new SQLiteCommand(sql, databaseObject.myConnection);
            rd = command.ExecuteReader();
            while (rd.Read())
            {
                gunaDataGridView2.Rows.Add(rd["name_composition"].ToString());
            }
            command.Dispose();
            databaseObject.CloseConnection();
        }
    }
}
