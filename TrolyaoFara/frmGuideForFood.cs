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
    public partial class frmGuideForFood : Form
    {
        Database databaseObject = new Database();
        SettingSever sSever = new SettingSever();
        LibFunction lib = new LibFunction();

        public frmGuideForFood(int idFood, string nameFood)
        {
            InitializeComponent();

            this.Text = "Công thức món: " + nameFood;

            if (lib.CheckForInternetConnection())
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(sSever.linksever + "ai/api/food/content/" + idFood);
                    json = "[" + json + "]";
                    List<ContentFood> data = JsonConvert.DeserializeObject<List<ContentFood>>(json);
                    foreach (var item in data)
                    {
                        byte[] bytes = Encoding.Default.GetBytes(item.Content);
                        string content = Encoding.UTF8.GetString(bytes);
                        webBrowser1.DocumentText = content;
                    }
                }
            }
            else
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);

        }

        public static void Show(int idFood, string nameFood)
        {
            new frmGuideForFood(idFood, nameFood).Show();
        }
    }
}
