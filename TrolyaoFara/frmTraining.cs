using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrolyaoFara
{
    public partial class frmTraining : Form
    {
        string txtfood = "Nhập tên món ăn";
        Database databaseObject = new Database();
        LibFunction lib = new LibFunction();
        SettingSever sSever = new SettingSever();
        private static readonly HttpClient client = new HttpClient();

        public frmTraining()
        {
            InitializeComponent();
        }

        private void txtFoodName_Enter(object sender, EventArgs e)
        {
            if (txtFoodName.Text == txtfood)
            {
                txtFoodName.ResetText();
                txtFoodName.ForeColor = Color.FromArgb(165, 21, 80);
            }
        }

        private void txtFoodName_Leave(object sender, EventArgs e)
        {
            if (txtFoodName.Text == "")
            {
                txtFoodName.Text = txtfood;
                txtFoodName.ForeColor = Color.Gray;
            }
        }

        public string GetNameFoodFromSever(int id)
        {
            string namefood = "";
            if (lib.CheckForInternetConnection())
            {

                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(sSever.linksever + "ai/api/food/" + id.ToString());
                    json = "[" + json + "]";
                    List<Food> data = JsonConvert.DeserializeObject<List<Food>>(json);
                    foreach (var item in data)
                    {
                        byte[] bytes = Encoding.Default.GetBytes(item.Title.ToString());
                        string temp = Encoding.UTF8.GetString(bytes);
                        namefood = temp;
                    }
                }
            }
            else
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
            return namefood;
        }

        private void GetFavoriteFormData()
        {
            gunaDataGridView1.Rows.Clear();
            gunaDataGridView1.Refresh();
            txtFoodName.Text = txtfood;
            txtFoodName.ForeColor = Color.Gray;

            string sql = string.Format("SELECT * FROM ratings");
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                int idf = Convert.ToInt32(rd["food_id"]);
                gunaDataGridView1.Rows.Add(idf, GetNameFoodFromSever(idf), rd["rate"].ToString());
            }
            command.Dispose();
            databaseObject.CloseConnection();
        }

        public void LoadFoodFavourite()
        {
            lstFoodName.Items.Clear();
            lstIdFoodName.Items.Clear();
            if (lib.CheckForInternetConnection())
            {
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        var json = wc.DownloadString(sSever.linksever + "ai/api/food/?search=" + txtFoodName.Text.ToLower());
                        List<Food> data = JsonConvert.DeserializeObject<List<Food>>(json);
                        foreach (var item in data)
                        {
                            byte[] bytes = Encoding.Default.GetBytes(item.Title.ToString());
                            string temp = Encoding.UTF8.GetString(bytes);
                            lstFoodName.Items.Add(temp);
                            lstIdFoodName.Items.Add(item.Id);
                        }
                    }
                }
                catch (Exception)
                {
                    alert.Show("Lỗi Server !", alert.AlertType.error);
                }
            }
            else
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
        }

        private void txtFoodName_KeyUp(object sender, KeyEventArgs e)
        {
            txtFoodName.ForeColor = Color.FromArgb(165, 21, 80);
            if (!string.IsNullOrEmpty(txtFoodName.Text.Trim()) && txtFoodName.Text != txtfood)
                LoadFoodFavourite();
            if (lstFoodName.Items.Count == 0)
            {
                //picPreviewFood.Hide();
                alert.Show("Hiện chưa có món ăn này!", alert.AlertType.error);
            }
            else
            {
                //picPreviewFood.Show();
            }
        }

        private void lstFoodName_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (lib.CheckForInternetConnection())
            {
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        int index = lstFoodName.Items.IndexOf(lstFoodName.SelectedItem);
                        var json = wc.DownloadString(sSever.linksever + "ai/api/food/?search=" + lstFoodName.Items[index].ToString());
                        List<Food> data = JsonConvert.DeserializeObject<List<Food>>(json);
                        foreach (var item in data)
                        {
                            picPreviewFood.Show();
                            picPreviewFood.LoadAsync(item.URLimg);
                        }
                    }
                }
                catch (Exception)
                {
                    alert.Show("Lỗi Server !", alert.AlertType.error);
                }
            }
            else
                picPreviewFood.Hide();
                */
        }

        private void frmTraining_Load(object sender, EventArgs e)
        {
            GetFavoriteFormData();

            lstIdFoodName.Visible = false;

            string path = Environment.CurrentDirectory + "/" + "FoodUpload.txt";
            if (!File.Exists(path))
            {
                FirstUpload();
            }
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtNamefood.Text = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtRating.Value = Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Cells[2].Value);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int IdSeclect = lstFoodName.Items.IndexOf(lstFoodName.GetItemText(lstFoodName.SelectedItem));
            int idfoodname = Convert.ToInt32(lstIdFoodName.Items[IdSeclect]);
            if (lib.CheckExists("ratings", "food_id", idfoodname, ""))
            {
                string strUdpate = string.Format("UPDATE ratings set rate='{0}' where food_id='{1}'", numRaing.Value, idfoodname);
                databaseObject.RunSQL(strUdpate);
            }
            else
            {
                string strInsert = string.Format("INSERT INTO ratings(food_id, rate, stt) VALUES('{0}', '{1}', '{2}')", idfoodname, numRaing.Value, true);
                databaseObject.RunSQL(strInsert);
            }

            alert.Show("Cập nhật thông tin thành công!", alert.AlertType.success);
            string link = "ai/api/ratings/create/";
            RatingSeverAsync(lib.GetID().ToString(), idfoodname.ToString(), numRaing.Value.ToString(), link);
            GetFavoriteFormData();
        }

        private async void RatingSeverAsync(string user, string food, string rate, string link)
        {
            var values = new Dictionary<string, string>
            {
                {"user", user},
                {"food", food },
                {"ratings", rate},
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(sSever.linksever + link, content);
            var responseString = await response.Content.ReadAsStringAsync();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int idfoodname = Convert.ToInt32(txtID.Text);
            string strUdpate = string.Format("UPDATE ratings set rate='{0}' where food_id='{1}'", txtRating.Value, idfoodname);
            databaseObject.RunSQL(strUdpate);
            string link = "ai/api/ratings/edit/";
            RatingSeverAsync(lib.GetID().ToString(), idfoodname.ToString(), txtRating.Value.ToString(), link);
            GetFavoriteFormData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int idfoodname = Convert.ToInt32(txtID.Text);
            string strDelete = string.Format("DELETE FROM ratings where food_id='{0}'", idfoodname);
            databaseObject.RunSQL(strDelete);
            int rate = -1;
            string link = "ai/api/ratings/edit/";
            RatingSeverAsync(lib.GetID().ToString(), idfoodname.ToString(), rate.ToString(), link);
            GetFavoriteFormData();
            txtID.ResetText();
            txtNamefood.ResetText();
            txtRating.Value = 5;
        }

        private void FirstUpload()
        {
            string path = Environment.CurrentDirectory + "/" + "FoodUpload.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {

                sw.Write("True");
            }

            string link = "ai/api/ratings/create/";
            string sql = string.Format("SELECT * FROM ratings");
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {

                string idf = rd["food_id"].ToString();
                string rate = rd["rate"].ToString();

                RatingSeverAsync(lib.GetID().ToString(), idf, rate, link);
            }
            command.Dispose();
            databaseObject.CloseConnection();
        }
    }
}
