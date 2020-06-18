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
    public partial class frmInfoMenu : Form
    {
        Database databaseObject = new Database();
        LibFunction lib = new LibFunction();

        public frmInfoMenu()
        {
            InitializeComponent();
        }

        private void frmInfoMenu_Load(object sender, EventArgs e)
        {
            int protein, lipid, carb, mod, calo;
            mod = calo = protein = lipid = carb = 0;
            string strmod = "";

            string day = DateTime.Today.ToString("dd/MM/yyyy");
            string mainSQL = string.Format("SELECT * FROM menu WHERE date ='{0}'", day);
            if (lib.countRow(mainSQL) > 0)
            {
                databaseObject.OpenConnection();
                SQLiteCommand command = new SQLiteCommand(mainSQL, databaseObject.myConnection);
                SQLiteDataReader rd = command.ExecuteReader();
                while (rd.Read())
                {
                    calo = Convert.ToInt32(rd["calo"]);
                    mod = Convert.ToInt32(rd["mod"]);
                    protein = Convert.ToInt32(rd["protein"]);
                    lipid = Convert.ToInt32(rd["lipid"]);
                    carb = Convert.ToInt32(rd["carb"]);
                }
                command.Dispose();
                databaseObject.CloseConnection();

                switch (mod)
                {
                    case 1:
                        strmod = "Cá nhân";
                        break;
                    case 2:
                        strmod = "Gia đình";
                        break;
                    case 3:
                        strmod = "Tập thể";
                        break;
                }

                dataMenu.Rows.Add("Loại thực đơn", strmod.ToString());
                dataMenu.Rows.Add("Tổng Calo", calo.ToString() + " KCal");
                dataMenu.Rows.Add("Protein", protein.ToString() + " g");
                dataMenu.Rows.Add("Lipid", lipid.ToString() + " g");
                dataMenu.Rows.Add("Carb", carb.ToString() + " g");
                double pProtein, pLipid, pCarb;
                pProtein = Math.Round((protein * 4.0 / calo * 100), 2);
                pLipid = Math.Round((lipid * 9.0 / calo * 100), 2);
                pCarb = Math.Round((carb * 4.0 / calo * 100), 2);


                dataMenu.Rows.Add("Tỉ lệ Protein trong menu", pProtein.ToString() + " %");
                dataMenu.Rows.Add("Tỉ lệ Lipid trong menu", pLipid.ToString() + " %");
                dataMenu.Rows.Add("Tỉ lệ Carb trong menu", pCarb.ToString() + " %");
                dataMenu.Rows.Add("Tỉ lệ vi chất trong menu", (Math.Round((100 - pProtein - pLipid - pCarb), 2)).ToString() + " %");
            }
            else
            {
                alert.Show("Thực đơn không tồn tại!", alert.AlertType.info);
            }
        }
    }
}
