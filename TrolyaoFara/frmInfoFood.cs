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
    public partial class frmInfoFood : Form
    {
        Database databaseObject = new Database();
        SettingSever sSever = new SettingSever();
        LibFunction lib = new LibFunction();

        public frmInfoFood(int idFood, string nameFood)
        {
            InitializeComponent();

            lblTitle.Text = "Công thức món: " + nameFood;

            if (lib.CheckForInternetConnection())
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(sSever.linksever + "ai/api/food/content/" + idFood);
                    json = "[" + json + "]";
                    List <ContentFood> data = JsonConvert.DeserializeObject<List<ContentFood>>(json);
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

            /*
            string sql = string.Format("SELECT * FROM food_db WHERE id='{0}'", idFood);
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                webBrowser1.DocumentText = rd["content"].ToString();
            }
            command.Dispose();
            databaseObject.CloseConnection();
            */
        }

        public static void Show(int idFood, string nameFood)
        {
            new frmInfoFood(idFood, nameFood).Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
