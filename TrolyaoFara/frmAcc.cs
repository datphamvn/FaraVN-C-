using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrolyaoFara
{
    public partial class frmAcc : Form
    {
        Database databaseObject = new Database();
        LibFunction lib = new LibFunction();
        LoadData lData = new LoadData();
        SettingSever sSever = new SettingSever();
        DataConfig datacf = new DataConfig();

        int maxHeight = 300;
        int maxWeight = 800;
        int maxTPdiung = 5;
        int maxRatings = 5;

        //Save Variable
        int grboxHeight = 0;

        public frmAcc()
        {
            InitializeComponent();
        }

        // 0: Nam; 1: Nữ
        private void LoadInfo()
        {
            string sql = string.Format("SELECT * FROM info WHERE iduser='{0}'", lib.GetID());
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                txtLname.Text = rd["lname"].ToString();
                txtFname.Text = rd["fname"].ToString();
                if ((bool)rd["gender"])
                    txtGender.SelectedIndex = 1;
                else
                    txtGender.SelectedIndex = 0;
                try
                { inputBirthday.Value = Convert.ToDateTime(rd["birthday"].ToString()); }
                catch
                { inputBirthday.Value = DateTime.Today; }
                
                if (!String.IsNullOrEmpty(rd["country"].ToString()))
                    txtCountry.SelectedIndex = txtCountry.FindStringExact(rd["country"].ToString());

                LoadCityData();
                LoadDistrictData();
                txtCity.Text = rd["city"].ToString();
                txtDistrict.Text = rd["district"].ToString();

                txtHeight.Text = rd["height"].ToString();
                txtWeight.Text = rd["weight"].ToString();
            }
            command.Dispose();
            databaseObject.CloseConnection();
        }

        string json = "";

        private void ReadJsonWorld()
        {
            using (StreamReader r = new StreamReader(lData.countryname))
            {
                json = r.ReadToEnd();
                List<WorldName> countryname = JsonConvert.DeserializeObject<List<WorldName>>(json);
                foreach(var country in countryname)
                {
                    txtCountry.Items.Add(country.Name);
                }
            }
        }

        private void Tabpage_Load()
        {
            //Tab1
            ReadJsonWorld();
            txtCity.Items.Add("");
            txtDistrict.Items.Add("");
            LoadInfo();
            //Tab2
            LoadDatatxtDiung();
            btnAdd1.Hide();
            btnSub2.Hide();
            grboxHeight = gunaGroupBox5.Height;
            lbl_update.Hide();
            createTable();
            LoadSetFood();
        }

        private void frmAcc_Load(object sender, EventArgs e)
        {
            Tabpage_Load();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }
        
        private void txtLname_Enter(object sender, EventArgs e)
        {
            if (txtLname.Text == "Họ")
            {
                txtLname.ResetText();
                txtLname.ForeColor = Color.FromArgb(165, 21, 80);
            }
        }

        private void txtLname_Leave(object sender, EventArgs e)
        {
            if (txtLname.Text == "")
            {
                txtLname.Text = "Họ";
                txtLname.ForeColor = Color.Gray;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime oldDateTime = today.AddYears(-150);

            if (txtFname.Text == "Tên" | txtLname.Text == "Họ")
            {
                alert.Show("Vui lòng điền đầy đủ họ tên !", alert.AlertType.error);
            }
            else if (DateTime.Compare(today, inputBirthday.Value) < 0)
            {
                // today sớm hơn inputBirthday.
                alert.Show("Ngày sinh không hợp lệ !", alert.AlertType.error);
            }
            else if (DateTime.Compare(inputBirthday.Value, oldDateTime) < 0)
            {
                alert.Show("Ngày sinh không hợp lệ !", alert.AlertType.error);
            }
            else if (Int32.Parse(txtHeight.Text) > maxHeight)
                alert.Show("Chiều cao không hợp lệ !", alert.AlertType.error);
            else if (Int32.Parse(txtWeight.Text) > maxWeight)
                alert.Show("Cân nặng không hợp lệ !", alert.AlertType.error);
            else if (txtCountry.Text == "")
                alert.Show("Vui lòng chọn vị trí hiện tại của bạn!", alert.AlertType.error);
            else
            {
                string strUpdate = string.Format("UPDATE info set lname='{0}', fname='{1}', gender='{2}', birthday='{3}', height='{4}', weight='{5}', country='{6}', city='{7}', district='{8}' where iduser='{9}'", txtLname.Text, txtFname.Text, txtGender.SelectedIndex, inputBirthday.Value.ToString(), txtHeight.Text, txtWeight.Text, txtCountry.Text, txtCity.Text, txtDistrict.Text, lib.GetID());
                databaseObject.RunSQL(strUpdate);
                alert.Show("Cập nhật thông tin thành công !", alert.AlertType.success);
            }
        }

        private void txtFname_Enter(object sender, EventArgs e)
        {
            if (txtFname.Text == "Tên")
            {
                txtFname.ResetText();
                txtFname.ForeColor = Color.FromArgb(165, 21, 80);
            }
        }

        private void txtFname_Leave(object sender, EventArgs e)
        {
            if (txtFname.Text == "")
            {
                txtFname.Text = "Tên";
                txtFname.ForeColor = Color.Gray;
            }
        }

        private void NumberOnly(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberOnly(sender, e);
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberOnly(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void LoadCityData()
        {
            txtCity.Items.Clear();
            int getId = txtCountry.SelectedIndex;
            List<WorldName> countryname = JsonConvert.DeserializeObject<List<WorldName>>(json);
            try
            {
                foreach (DictionaryEntry item in countryname[getId].States)
                {
                    txtCity.Items.Add(item.Key);
                }
            }
            catch (Exception)
            {
                txtCity.Items.Add("");
            }
        }

        private void gunaComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadCityData();
        }

        private void LoadDistrictData()
        {
            txtDistrict.Items.Clear();
            int getId = txtCountry.SelectedIndex;
            string getId2 = txtCity.Text;
            List<WorldName> countryname = JsonConvert.DeserializeObject<List<WorldName>>(json);
            try
            {
                foreach (DictionaryEntry item in countryname[getId].States)
                {
                    if (getId2 == item.Key.ToString())
                    {
                        string[] list = ((IEnumerable)item.Value).Cast<object>().Select(x => x.ToString()).ToArray();
                        foreach (var i in list)
                        {
                            txtDistrict.Items.Add(i);
                        }
                    }
                }
            }
            catch (Exception)
            {
                txtDistrict.Items.Add("");
            }
        }

        private void gunaComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDistrictData();
        }

        private async void gunaButton1_ClickAsync(object sender, EventArgs e)
        {
            if (lib.CheckForInternetConnection())
            {
                string MyIP = "";
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString("https://api.myip.com/");
                    var data = JsonConvert.DeserializeObject<GetIP>(json);
                    MyIP = data.Ip;
                }

                using (var client = new HttpClient())
                {
                    var req = new List<KeyValuePair<string, string>>();
                    req.Add(new KeyValuePair<string, string>("user-id", lData.userGetLocation));
                    req.Add(new KeyValuePair<string, string>("api-key", lData.keyGetLocation));
                    req.Add(new KeyValuePair<string, string>("ip", MyIP));

                    var content = new FormUrlEncodedContent(req);
                    var response = await client.PostAsync("https://neutrinoapi.net/ip-info", content);
                    var responseStr = await response.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<GetLocation>(responseStr);
                    //JsonObject result = (JsonObject)JsonValue.Parse(responseStr);
                    txtFname.Text = data.Country;
                }
            }
        }

        public void LoadDatatxtDiung()
        {
            listBox2.Items.Clear();
            listBox7.Items.Clear();
            if (lib.CheckForInternetConnection())
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(sSever.linksever + "ai/api/composition/?search=" + txtDiung.Text.ToUpper());
                    List<FoodComposition> data = JsonConvert.DeserializeObject<List<FoodComposition>>(json);
                    foreach (var item in data)
                    {
                        byte[] bytes = Encoding.Default.GetBytes(item.food_name.ToString());
                        string temp = Encoding.UTF8.GetString(bytes);
                        listBox2.Items.Add(temp);
                        listBox7.Items.Add(item.id.ToString());
                    }       
                }
            }
            else
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
        }

        private void txtDiung_KeyUp(object sender, KeyEventArgs e)
        {
            LoadDatatxtDiung();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            string itemsel = listBox2.GetItemText(listBox2.SelectedItem);
            if (string.IsNullOrEmpty(itemsel))
                return;
            if (listBox3.Items.Contains(itemsel))
            {
                alert.Show("Thành phần này đã có trong danh sách!", alert.AlertType.warning);
                return;
            }
            if (listBox3.Items.Count >= maxTPdiung)
                alert.Show("Dữ liệu đã đạt đến giới hạn!", alert.AlertType.error);
            else
            {
                listBox3.Items.Add(itemsel);
                listBox7.SelectedIndex = listBox2.Items.IndexOf(listBox2.SelectedItem);
                listBox8.Items.Add(listBox7.GetItemText(listBox7.SelectedItem));
                txtDiung.ResetText();
                txtDiung.Focus();
            } 
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox3.Items.Count > 0)
                {
                    listBox8.SelectedIndex = listBox3.Items.IndexOf(listBox3.SelectedItem);
                    listBox8.Items.RemoveAt(listBox8.SelectedIndex);
                    listBox3.Items.RemoveAt(listBox3.SelectedIndex);
                }
            }
            catch
            {
                alert.Show("Vui lòng chọn item cần xóa!", alert.AlertType.warning);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void gunaButton8_Click(object sender, EventArgs e)
        {
            gunaGroupBox5.Height = grboxHeight;
            btnAdd1.Hide();
            btnSub1.Show();
            this.gunaGroupBox4.Location = new Point(this.gunaGroupBox5.Location.X, this.gunaGroupBox5.Location.Y + gunaGroupBox5.Height + 5);
            if (gunaGroupBox4.Height > gunaGroupBox4.LineTop+1)
            {
                gunaGroupBox4.Height = gunaGroupBox4.LineTop + 1;
                btnSub2.Hide();
                btnAdd2.Show();
            }
        }

        private void btnSub1_Click(object sender, EventArgs e)
        {
            btnSub1.Hide();
            btnAdd1.Show();
            gunaGroupBox5.Height = gunaGroupBox5.LineTop + 1;
            this.gunaGroupBox4.Location = new Point(this.gunaGroupBox5.Location.X, this.gunaGroupBox5.Location.Y + gunaGroupBox5.LineTop + 5);
        }

        private void gunaButton9_Click(object sender, EventArgs e)
        {
            gunaGroupBox4.Height = grboxHeight;
            btnAdd2.Hide();
            btnSub2.Show();
            if(gunaGroupBox5.Height > gunaGroupBox5.LineTop+1)
            {
                gunaGroupBox5.Height = gunaGroupBox5.LineTop + 1;
                btnAdd1.Show();
                btnSub1.Hide();
            }
            this.gunaGroupBox4.Location = new Point(this.gunaGroupBox5.Location.X, this.gunaGroupBox5.Location.Y + gunaGroupBox5.LineTop + 5);
        }

        private void btnSub2_Click(object sender, EventArgs e)
        {
            btnSub2.Hide();
            btnAdd2.Show();
            gunaGroupBox4.Height = gunaGroupBox4.LineTop + 1;
            this.gunaGroupBox4.Location = new Point(this.gunaGroupBox5.Location.X, this.gunaGroupBox5.Location.Y + gunaGroupBox5.Height + 5);
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        public void LoadDataYeuthich()
        {
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            if (lib.CheckForInternetConnection())
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(sSever.linksever + "ai/api/food/" + txtFoodName.Text.ToLower());
                    List<Food> data = JsonConvert.DeserializeObject<List<Food>>(json);
                    foreach (var item in data)
                    {
                        byte[] bytes = Encoding.Default.GetBytes(item.Title.ToString());
                        string temp = Encoding.UTF8.GetString(bytes);
                        listBox4.Items.Add(temp);
                        listBox5.Items.Add(item.Id);
                    }
                }
            }
            else
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
        }

        private void txtFoodName_KeyUp(object sender, KeyEventArgs e)
        {
            LoadDataYeuthich();
            if (listBox4.Items.Count == 0)
                lbl_update.Show();
            else
                lbl_update.Hide();
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            string itemsel = listBox4.GetItemText(listBox4.SelectedItem);
            if (string.IsNullOrEmpty(itemsel))
                return;
            if (listBox1.Items.Contains(itemsel))
            {
                alert.Show("Món ăn này đã có trong danh sách!", alert.AlertType.warning);
            }
            else
            {
                listBox1.Items.Add(itemsel);
                listBox5.SelectedIndex = listBox4.Items.IndexOf(listBox4.SelectedItem);
                listBox6.Items.Add(listBox5.GetItemText(listBox5.SelectedItem));
                txtFoodName.ResetText();
                txtFoodName.Focus();
            }
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Items.Count > 0)
                {
                    listBox6.SelectedIndex = listBox1.Items.IndexOf(listBox1.SelectedItem);
                    listBox6.Items.RemoveAt(listBox6.SelectedIndex);
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            }
            catch
            {
                alert.Show("Vui lòng chọn item cần xóa!", alert.AlertType.warning);
            }
        }

        private void SendEmail(string _description)
        {
            string senderID = datacf.email;
            string senderPassword = datacf.e_password;

            string body = DateTime.Today.ToString() + ": Yêu cầu Update từ User có ID: " + lib.GetID();
            body += _description;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(senderID);
                mail.From = new MailAddress(senderID);
                mail.Subject = "Update dữ liệu món ăn !";
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential(senderID, senderPassword);
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception)
            {
                alert.Show("Yêu cầu gửi đi thất bại !", alert.AlertType.error);
            }
            alert.Show("Cảm ơn bạn đã gửi yêu cầu !", alert.AlertType.success);
        }

        private void lblUpdate_Click(object sender, EventArgs e)
        {
            if (lib.CheckForInternetConnection())
                SendEmail("\n Món ăn: \"" + txtFoodName.Text + "\" cần được thêm vào Database !");
            else
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
        }

        private void createTable()
        {
            string sql = "CREATE TABLE IF NOT EXISTS allergic([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, composition_id integer NOT NULL UNIQUE, name_composition varchar, stt bool)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS favorite([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, food_id integer NOT NULL UNIQUE, name_food varchar, stt bool)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS ratings([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, food_id integer NOT NULL UNIQUE, rate integer NOT NULL, stt bool)";
            databaseObject.RunSQL(sql);
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            string strUdpate = string.Format("UPDATE favorite set stt='{0}' WHERE id > 0", false);
            databaseObject.RunSQL(strUdpate);
            strUdpate = string.Format("UPDATE allergic set stt='{0}' WHERE id > 0", false);
            databaseObject.RunSQL(strUdpate);
            strUdpate = string.Format("UPDATE ratings set stt='{0}' WHERE id > 0", false);
            databaseObject.RunSQL(strUdpate);
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (lib.CheckExists("favorite", "food_id", Convert.ToInt32(listBox6.Items[i]), ""))
                {
                    strUdpate = string.Format("UPDATE favorite set stt='{0}' where food_id='{1}'", true, listBox6.Items[i]);
                    databaseObject.RunSQL(strUdpate);
                }
                else
                {
                    string strInsert = string.Format("INSERT INTO favorite(food_id, name_food, stt) VALUES('{0}', '{1}', '{2}')", listBox6.Items[i], listBox1.Items[i], true);
                    databaseObject.RunSQL(strInsert);
                }
                if (lib.CheckExists("ratings", "food_id", Convert.ToInt32(listBox6.Items[i]), ""))
                {
                    strUdpate = string.Format("UPDATE ratings set rate='{0}', stt='{1}' where food_id='{2}'", maxRatings, true, listBox6.Items[i]);
                    databaseObject.RunSQL(strUdpate);
                }
                else
                {
                    string strInsert = string.Format("INSERT INTO ratings(food_id, rate, stt) VALUES('{0}', '{1}', '{2}')", listBox6.Items[i], maxRatings, true);
                    databaseObject.RunSQL(strInsert);
                }
            }

            for (int i = listBox3.Items.Count - 1; i >= 0; i--)
            {
                if (lib.CheckExists("allergic", " composition_id", Convert.ToInt32(listBox8.Items[i]), ""))
                {
                    strUdpate = string.Format("UPDATE allergic set stt='{0}' where composition_id='{1}'", true, listBox8.Items[i]);
                    databaseObject.RunSQL(strUdpate);
                }
                else
                {
                    string strInsert = string.Format("INSERT INTO allergic(composition_id, name_composition, stt) VALUES('{0}', '{1}', '{2}')", listBox8.Items[i], listBox3.Items[i], true);
                    databaseObject.RunSQL(strInsert);
                }
            }

            string strDelete = string.Format("DELETE FROM favorite where stt='{0}'", false);
            databaseObject.RunSQL(strDelete);
            strDelete = string.Format("DELETE FROM ratings where stt='{0}'", false);
            databaseObject.RunSQL(strDelete);
            strDelete = string.Format("DELETE FROM allergic where stt='{0}'", false);
            databaseObject.RunSQL(strDelete);

            alert.Show("Cập nhật thông tin thành công!", alert.AlertType.success);
        }

        private void LoadSetFood()
        {
            string sql = string.Format("SELECT * FROM favorite");
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                listBox1.Items.Add(rd["name_food"].ToString());
                listBox6.Items.Add(rd["food_id"].ToString());
            }
            command.Dispose();
            databaseObject.CloseConnection();

            sql = string.Format("SELECT * FROM allergic");
            databaseObject.OpenConnection();
            command = new SQLiteCommand(sql, databaseObject.myConnection);
            rd = command.ExecuteReader();
            while (rd.Read())
            {
                listBox3.Items.Add(rd["name_composition"].ToString());
                listBox8.Items.Add(rd["composition_id"].ToString());
            }
            command.Dispose();
            databaseObject.CloseConnection();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox6.Items.Clear();
            listBox3.Items.Clear();
            listBox8.Items.Clear();
            LoadSetFood();
        }
    }
}
