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
        int widthSidebar;

        public frmGuideForFood(int idFood, string nameFood, double factor)
        {
            InitializeComponent();

            //Settings Form
            this.Text = nameFood;
            widthSidebar = pnlSidebar.Width;
            btnShowSidebar.Hide();

            if (lib.CheckForInternetConnection())
            {
                getDataUsingAsync(idFood, factor, panelLoad, gunaDataGridView2);
            }
            else
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
        }

        public static void Show(int idFood, string nameFood, double factor)
        {
            new frmGuideForFood(idFood, nameFood, factor).Show();
        }

        public async void getDataUsingAsync(int idFood, double factor, Panel pnlWaitingLoad, DataGridView tableData)
        {
            List<string> lstUnit = new List<string>();
            List<string> lstCompositionName = new List<string>();
            List<CalFood> compostion = new List<CalFood>();
            
            getContent(idFood);

            Action getUnit = () => {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(sSever.linksever + "ai/api/unit");
                    List<Unit> data = JsonConvert.DeserializeObject<List<Unit>>(json);

                    foreach (var item in data)
                    {
                        byte[] bytes = Encoding.Default.GetBytes(item.NameUnit.ToString());
                        string nUnit = Encoding.UTF8.GetString(bytes);
                        lstUnit.Add(nUnit);
                    }
                }
            };

            Action getComposition = () => {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(sSever.linksever + "ai/api/cal/?id=&foodname=" + idFood);
                    compostion = JsonConvert.DeserializeObject<List<CalFood>>(json);
                    foreach (var item in compostion)
                    {
                        lstCompositionName.Add(getNameCompostion(item.id_Composition));
                    }
                }
            };

            Task task1 = new Task(getUnit);
            Task task2 = new Task(getComposition);
            task1.Start();
            task2.Start();

            await task2;
            int idx = 0;
            foreach (var item in compostion)
            {
                if (tableData != null)
                {
                    bool found = false;
                    foreach (DataGridViewRow row in tableData.Rows)
                    {
                        if (row.Cells["nameCompostion"].Value.ToString() == lstCompositionName[idx])
                        {
                            row.Cells["nameCompostion"].Value += " +1";
                            found = true;
                            break;
                        }
                    }
                    if (!found) // Item không tồn tại tồn tại
                    {
                        tableData.Rows.Add(lstCompositionName[idx], Math.Round(item.Amout * factor, 1), lstUnit[Convert.ToInt32(item.Unit) - 1]);
                    }
                }

                //tableData.Rows.Add(lstCompositionName[idx++], Math.Round(item.Amout * factor, 1), lstUnit[Convert.ToInt32(item.Unit) - 1]);
                idx++;
            }

            pnlWaitingLoad.Hide();
        }

        public async void getContent(int idFood)
        {
            string content = "";
            Action getContent = () => {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(sSever.linksever + "ai/api/food/content/" + idFood);
                    json = "[" + json + "]";
                    List<ContentFood> data = JsonConvert.DeserializeObject<List<ContentFood>>(json);
                    foreach (var item in data)
                    {
                        byte[] bytes = Encoding.Default.GetBytes(item.Content);
                        content = Encoding.UTF8.GetString(bytes);
                    }
                }
            };

            Task task1 = new Task(getContent);
            task1.Start();
            await task1;
            webBrowser1.DocumentText = content;
        }

        public string getNameCompostion(long idComposition)
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

        private void btnHideSidebar_Click(object sender, EventArgs e)
        {
            AnimationFooterBack.HideSync(pnlComposition);
            btnHideSidebar.Hide();
            pnlSidebar.Width = btnShowSidebar.Width;
            btnShowSidebar.Show();
        }

        private void btnShowSidebar_Click(object sender, EventArgs e)
        {
            pnlSidebar.Width = widthSidebar;
            AnimationFooterBack.ShowSync(pnlComposition);
            btnShowSidebar.Hide();
            btnHideSidebar.Show();
        }
    }
}
