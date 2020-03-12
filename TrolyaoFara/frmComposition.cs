using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrolyaoFara
{
    public partial class frmComposition : Form
    {
        SettingSever sSever = new SettingSever();
        LibFunction lib = new LibFunction();

        public frmComposition(int idFood, string nameFood, double factor)
        {
            InitializeComponent();

            this.Text = "Nguyên liệu món: " + nameFood;
            List<string> lstUnit = new List<string>();
            getUnit(lstUnit);

            if (lib.CheckForInternetConnection())
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(sSever.linksever + "ai/api/cal/?id=&foodname=" + idFood);
                    List<CalFood> data = JsonConvert.DeserializeObject<List<CalFood>>(json);
                    foreach (var item in data)
                    {
                        gunaDataGridView2.Rows.Add(getNameCompostion(item.id_Composition), Math.Round(item.Amout * factor, 1), lstUnit[Convert.ToInt32(item.Unit)-1]);
                    }
                }
            }
            else
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);

        }

        public static void Show(int idFood, string nameFood, double factor)
        {
            new frmComposition(idFood, nameFood, factor).Show();
        }

        private void frmComposition_Load(object sender, EventArgs e)
        {

        }

        private string getNameCompostion(long idComposition)
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(sSever.linksever + "ai/api/composition/?food_id=" + idComposition);
                List<Composition> data = JsonConvert.DeserializeObject<List<Composition>>(json);
                byte[] bytes = Encoding.Default.GetBytes(data[0].FoodName.ToString());
                string nameCp = Encoding.UTF8.GetString(bytes);
                return nameCp;
            }
        }

        public void getUnit(List<string> lstUnit)
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(sSever.linksever + "ai/api/unit");
                List<Unit> data = JsonConvert.DeserializeObject<List<Unit>>(json);

                foreach(var item in data)
                {
                    byte[] bytes = Encoding.Default.GetBytes(item.NameUnit.ToString());
                    string nUnit = Encoding.UTF8.GetString(bytes);
                    lstUnit.Add(nUnit);
                }
            }
        }
        
    }
}
