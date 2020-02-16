using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TrolyaoFara
{
    public partial class frmAccount : Form
    {
        Database databaseObject = new Database();
        LibFunction lib = new LibFunction();
        SettingSever sSever = new SettingSever();
        DataConfig datacf = new DataConfig();
        LoadData lData = new LoadData();
        private static readonly HttpClient client = new HttpClient();

        int maxHeight = 300;
        int maxWeight = 800;
        int maxTPdiung = 5;
        int maxRatings = 5;
        int id = 0;
        int nTab = 3;
        bool[] load = new bool[3];

        string txtfood = "Nhập tên món ăn";
        string txtcomposition = "Nhập tên thành phần bạn bị dị ứng";
        string txtfname = "Tên";
        string txtlname = "Họ";

        public frmAccount()
        {
            InitializeComponent();
        }

        private void CreateTable()
        {
            string sql = "CREATE TABLE IF NOT EXISTS allergic([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, composition_id integer NOT NULL UNIQUE, name_composition varchar, stt bool)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS favorite([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, food_id integer NOT NULL UNIQUE, name_food varchar, stt bool)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS ratings([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, food_id integer NOT NULL UNIQUE, rate integer NOT NULL, stt bool)";
            databaseObject.RunSQL(sql);
        }

        private void NextPage()
        {
            int index = tabControl1.SelectedIndex;
            tabControl1.SelectedIndex = index + 1;
        }

        private void PrePage()
        {
            int index = tabControl1.SelectedIndex;
            tabControl1.SelectedIndex = index - 1;
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            id = lib.GetID();
            for(int i=0; i<nTab; i++)
            {
                load[i] = false;
            }

            //TabInfo
            LoadSomeInfo();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabFood"] && load[0] == false)
            {
                GetFavoriteFormData();
                load[0] = true;
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabComposition"] && load[1] == false)
            {
                GetDataAllergic();
                load[1] = true;
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabLocation"] && load[2] == false)
            {
                ReadJsonWorld();
                txtCity.Items.Add("");
                txtDistrict.Items.Add("");
                LoadLocation();
                load[2] = true;
            }
        }

        #region TabInfo
        //Data Load: gender, fname, lname, birthday, weight, weight-target, height, 
        private void LoadSomeInfo()
        {
            string sql = string.Format("SELECT * FROM info WHERE iduser='{0}'", id);
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                if (!string.IsNullOrEmpty(rd["lname"].ToString()))
                {
                    txtLname.Text = rd["lname"].ToString();
                    txtLname.ForeColor = Color.FromArgb(165, 21, 80);
                }
                else
                {
                    txtLname.Text = txtlname;
                    txtLname.ForeColor = Color.Gray;
                }


                if (!string.IsNullOrEmpty(rd["fname"].ToString()))
                {
                    txtFname.Text = rd["fname"].ToString();
                    txtFname.ForeColor = Color.FromArgb(165, 21, 80);
                }
                else
                {
                    txtFname.Text = txtfname;
                    txtFname.ForeColor = Color.Gray;
                }

                if (Convert.ToInt32(rd["gender"]) == 2)
                    lblGender.Text = "NỮ";
                else if (Convert.ToInt32(rd["gender"]) == 1)
                    lblGender.Text = "NAM";
                else
                    lblGender.Text = "?";

                cmbIntensity.StartIndex = Convert.ToInt32(rd["intensity"]);

                try
                { inputBirthday.Value = Convert.ToDateTime(rd["birthday"].ToString()); }
                catch
                { inputBirthday.Value = DateTime.Today; }
                txtHeight.Text = rd["height"].ToString();
                txtWeight.Text = rd["weight"].ToString();
                txtWeightTarget.Text = rd["weight_target"].ToString();
            }
            command.Dispose();
            databaseObject.CloseConnection();
        }

        private void txtLname_Enter(object sender, EventArgs e)
        {
            if (txtLname.Text == txtlname)
            {
                txtLname.ResetText();
                txtLname.ForeColor = Color.FromArgb(165, 21, 80);
            }
        }

        private void txtLname_Leave(object sender, EventArgs e)
        {
            if (txtLname.Text == "")
            {
                txtLname.Text = txtlname;
                txtLname.ForeColor = Color.Gray;
            }
        }

        private void txtFname_Enter(object sender, EventArgs e)
        {
            if (txtFname.Text == txtfname)
            {
                txtFname.ResetText();
                txtFname.ForeColor = Color.FromArgb(165, 21, 80);
            }
        }

        private void txtFname_Leave(object sender, EventArgs e)
        {
            if (txtFname.Text == "")
            {
                txtFname.Text = txtfname;
                txtFname.ForeColor = Color.Gray;
            }
        }

        private void btnMale_Click(object sender, EventArgs e)
        {
            lblGender.Text = "NAM";
        }

        private void btnFemale_Click(object sender, EventArgs e)
        {
            lblGender.Text = "NỮ";
        }

        private int ConvertGender()
        {
            if (lblGender.Text == "NAM")
                return 1;
            else
                return 2;
        }

        private void NumberOnly(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberOnly(sender, e);
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberOnly(sender, e);
        }

        private void txtWeightTarget_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberOnly(sender, e);
        }

        public string standardString(string strSource)
        {
            string[] strDestination = strSource.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string Result = "";
            foreach (string pStr in strDestination)
            {
                Result += pStr + " ";
            }
            return Result.Trim();
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime oldDateTime = today.AddYears(-150);
            txtFname.Text = standardString(txtFname.Text);
            txtLname.Text = standardString(txtLname.Text);

            if (txtFname.Text == txtfname || txtLname.Text == txtlname || string.IsNullOrEmpty(txtLname.Text) || string.IsNullOrEmpty(txtFname.Text))
            {
                alert.Show("Vui lòng điền đầy đủ họ tên !", alert.AlertType.error);
            }
            else if (lblGender.Text == "?")
                alert.Show("Hãy lựa chọn giới tính của bạn !", alert.AlertType.error);
            else if (DateTime.Compare(today, inputBirthday.Value) <= 0)
            {
                // today sớm hơn inputBirthday.
                alert.Show("Ngày sinh không hợp lệ !", alert.AlertType.error);
            }
            else if (DateTime.Compare(inputBirthday.Value, oldDateTime) < 0)
                alert.Show("Ngày sinh không hợp lệ !", alert.AlertType.error);
            else if (Int32.Parse(txtHeight.Text) > maxHeight || Int32.Parse(txtHeight.Text) <= 0)
                alert.Show("Chiều cao không hợp lệ !", alert.AlertType.error);
            else if (Int32.Parse(txtWeight.Text) > maxWeight || Int32.Parse(txtWeight.Text) <= 0)
                alert.Show("Cân nặng không hợp lệ !", alert.AlertType.error);
            else if (Int32.Parse(txtWeightTarget.Text) > maxWeight || Int32.Parse(txtWeightTarget.Text) <= 0)
                alert.Show("Cân nặng mục tiêu không hợp lệ !", alert.AlertType.error);
            else
            {
                string strUpdate = string.Format("UPDATE info set lname='{0}', fname='{1}', gender='{2}', birthday='{3}', height='{4}', weight='{5}', weight_target='{6}', intensity='{7}' where iduser='{8}'", txtLname.Text, txtFname.Text, ConvertGender(), inputBirthday.Value.ToString(), txtHeight.Text, txtWeight.Text, txtWeightTarget.Text, cmbIntensity.SelectedIndex, id);
                databaseObject.RunSQL(strUpdate);
                UpdateInfoSeverAsync(txtHeight.Text, txtWeight.Text, cmbIntensity.SelectedIndex.ToString());
                alert.Show("Cập nhật thông tin thành công !", alert.AlertType.success);
                NextPage();
            }
        }

        private async void UpdateInfoSeverAsync(string height, string weight, string intensity)
        {
            var values = new Dictionary<string, string>
            {
                {"user", lib.GetUsername()},
                {"height", height},
                {"weight", weight},
                {"intensity", intensity}
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(sSever.linksever + "dashboard/api/user/update-info/", content);
            var responseString = await response.Content.ReadAsStringAsync();
        }

        private void btnReset1_Click(object sender, EventArgs e)
        {
            LoadSomeInfo();
        }
        #endregion

        #region TabFood
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

        private void GetFavoriteFormData()
        {
            txtFoodName.Text = txtfood;
            txtFoodName.ForeColor = Color.Gray;
            CreateTable();
            lblUpdateRequire.Hide();
            string sql = string.Format("SELECT * FROM favorite");
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                lstFoodNameAdd.Items.Add(rd["name_food"].ToString());
                lstIdFoodNameAdd.Items.Add(rd["food_id"].ToString());
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
                lblUpdateRequire.Show();
                picPreviewFood.Hide();
            }
            else
            {
                lblUpdateRequire.Hide();
                picPreviewFood.Show();
            }
        }

        private void lstFoodName_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string itemsel = lstFoodName.GetItemText(lstFoodName.SelectedItem);
            if (string.IsNullOrEmpty(itemsel))
                return;
            if (lstFoodNameAdd.Items.Contains(itemsel))
            {
                alert.Show("Món ăn này đã có trong danh sách!", alert.AlertType.warning);
            }
            else
            {
                lstFoodNameAdd.Items.Add(itemsel);
                lstIdFoodName.SelectedIndex = lstFoodName.Items.IndexOf(lstFoodName.SelectedItem);
                lstIdFoodNameAdd.Items.Add(lstIdFoodName.GetItemText(lstIdFoodName.SelectedItem));
                txtFoodName.ResetText();
                txtFoodName.Focus();
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstFoodNameAdd.Items.Count > 0)
                {
                    lstIdFoodNameAdd.SelectedIndex = lstFoodNameAdd.Items.IndexOf(lstFoodNameAdd.SelectedItem);
                    lstIdFoodNameAdd.Items.RemoveAt(lstIdFoodNameAdd.SelectedIndex);
                    lstFoodNameAdd.Items.RemoveAt(lstFoodNameAdd.SelectedIndex);
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

        private void lblUpdateRequire_Click(object sender, EventArgs e)
        {
            if (lib.CheckForInternetConnection())
                SendEmail("\n Món ăn: \"" + txtFoodName.Text + "\" cần được thêm vào Database !");
            else
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
        }

        private void btnNext2_Click(object sender, EventArgs e)
        {
            string strUdpate = string.Format("UPDATE favorite set stt='{0}' WHERE id > 0", false);
            databaseObject.RunSQL(strUdpate);

            strUdpate = string.Format("UPDATE ratings set stt='{0}' WHERE id > 0", false);
            databaseObject.RunSQL(strUdpate);
            for (int i = lstFoodNameAdd.Items.Count - 1; i >= 0; i--)
            {
                if (lib.CheckExists("favorite", "food_id", Convert.ToInt32(lstIdFoodNameAdd.Items[i]), ""))
                {
                    strUdpate = string.Format("UPDATE favorite set stt='{0}' where food_id='{1}'", true, lstIdFoodNameAdd.Items[i]);
                    databaseObject.RunSQL(strUdpate);
                }
                else
                {
                    string strInsert = string.Format("INSERT INTO favorite(food_id, name_food, stt) VALUES('{0}', '{1}', '{2}')", lstIdFoodNameAdd.Items[i], lstFoodNameAdd.Items[i], true);
                    databaseObject.RunSQL(strInsert);
                }
                if (lib.CheckExists("ratings", "food_id", Convert.ToInt32(lstIdFoodNameAdd.Items[i]), ""))
                {
                    strUdpate = string.Format("UPDATE ratings set rate='{0}', stt='{1}' where food_id='{2}'", maxRatings, true, lstIdFoodNameAdd.Items[i]);
                    databaseObject.RunSQL(strUdpate);
                }
                else
                {
                    string strInsert = string.Format("INSERT INTO ratings(food_id, rate, stt) VALUES('{0}', '{1}', '{2}')", lstIdFoodNameAdd.Items[i], maxRatings, true);
                    databaseObject.RunSQL(strInsert);
                }
            }

            string strDelete = string.Format("DELETE FROM favorite where stt='{0}'", false);
            databaseObject.RunSQL(strDelete);
            strDelete = string.Format("DELETE FROM ratings where stt='{0}'", false);
            databaseObject.RunSQL(strDelete);

            alert.Show("Cập nhật thông tin thành công!", alert.AlertType.success);
            NextPage();

        }

        private void btnPre2_Click(object sender, EventArgs e)
        {
            PrePage();
        }

        private void btnReset2_Click(object sender, EventArgs e)
        {
            lstFoodNameAdd.Items.Clear();
            lstIdFoodNameAdd.Items.Clear();
            lstFoodName.Items.Clear();
            lstIdFoodName.Items.Clear(); 
            GetFavoriteFormData();
            txtFoodName.Text = txtfood;
            txtFoodName.ForeColor = Color.Gray;
        }
        #endregion

        #region TabComposition

        public void GetDataAllergic()
        {
            txtDiung.Text = txtcomposition;
            txtDiung.ForeColor = Color.Gray;
            CreateTable();
            string sql = string.Format("SELECT * FROM allergic");
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                lstDiungAdd.Items.Add(rd["name_composition"].ToString());
                lstIdDiungAdd.Items.Add(rd["composition_id"].ToString());
            }
            command.Dispose();
            databaseObject.CloseConnection();
        }

        private void txtDiung_Enter(object sender, EventArgs e)
        {
            if (txtDiung.Text == txtcomposition)
            {
                txtDiung.ResetText();
                txtDiung.ForeColor = Color.FromArgb(165, 21, 80);
            }
        }

        private void txtDiung_Leave(object sender, EventArgs e)
        {
            if (txtDiung.Text == "")
            {
                txtDiung.Text = txtcomposition;
                txtDiung.ForeColor = Color.Gray;
            }
        }

        public void LoadDatatxtDiung()
        {
            lstDiung.Items.Clear();
            lstIdDiung.Items.Clear();
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
                        lstDiung.Items.Add(temp);
                        lstIdDiung.Items.Add(item.id.ToString());
                    }
                }
            }
            else
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
        }

        private void txtDiung_KeyUp(object sender, KeyEventArgs e)
        {
            txtDiung.ForeColor = Color.FromArgb(165, 21, 80);
            if (!string.IsNullOrEmpty(txtDiung.Text.Trim()) && txtDiung.Text != txtcomposition)
                LoadDatatxtDiung();
        }

        private void btnAddComposition_Click(object sender, EventArgs e)
        {
            string itemsel = lstDiung.GetItemText(lstDiung.SelectedItem);
            if (string.IsNullOrEmpty(itemsel))
                return;
            if (lstDiungAdd.Items.Contains(itemsel))
            {
                alert.Show("Thành phần này đã có trong danh sách!", alert.AlertType.warning);
                return;
            }
            if (lstDiungAdd.Items.Count >= maxTPdiung)
                alert.Show("Dữ liệu đã đạt đến giới hạn!", alert.AlertType.error);
            else
            {
                lstDiungAdd.Items.Add(itemsel);
                lstIdDiung.SelectedIndex = lstDiungAdd.Items.IndexOf(lstDiung.SelectedItem);
                lstIdDiungAdd.Items.Add(lstIdDiung.GetItemText(lstIdDiung.SelectedItem));
                txtDiung.ResetText();
                txtDiung.Focus();
            }
        }

        private void btnCompositionDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstDiungAdd.Items.Count > 0)
                {
                    lstIdDiungAdd.SelectedIndex = lstDiungAdd.Items.IndexOf(lstDiungAdd.SelectedItem);
                    lstIdDiungAdd.Items.RemoveAt(lstIdDiungAdd.SelectedIndex);
                    lstDiungAdd.Items.RemoveAt(lstDiungAdd.SelectedIndex);
                }
            }
            catch
            {
                alert.Show("Vui lòng chọn item cần xóa!", alert.AlertType.warning);
            }
        }

        private void btnNext3_Click(object sender, EventArgs e)
        {
            string strUdpate = string.Format("UPDATE allergic set stt='{0}' WHERE id > 0", false);
            databaseObject.RunSQL(strUdpate);

            for (int i = lstDiungAdd.Items.Count - 1; i >= 0; i--)
            {
                if (lib.CheckExists("allergic", " composition_id", Convert.ToInt32(lstIdDiungAdd.Items[i]), ""))
                {
                    strUdpate = string.Format("UPDATE allergic set stt='{0}' where composition_id='{1}'", true, lstIdDiungAdd.Items[i]);
                    databaseObject.RunSQL(strUdpate);
                }
                else
                {
                    string strInsert = string.Format("INSERT INTO allergic(composition_id, name_composition, stt) VALUES('{0}', '{1}', '{2}')", lstIdDiungAdd.Items[i], lstDiungAdd.Items[i], true);
                    databaseObject.RunSQL(strInsert);
                }
            }

            string strDelete = string.Format("DELETE FROM allergic where stt='{0}'", false);
            databaseObject.RunSQL(strDelete);

            alert.Show("Cập nhật thông tin thành công!", alert.AlertType.success);
            NextPage();
        }

        private void btnPre3_Click(object sender, EventArgs e)
        {
            PrePage();
        }

        private void btnReset3_Click(object sender, EventArgs e)
        {
            lstDiungAdd.Items.Clear();
            lstIdDiungAdd.Items.Clear();
            lstDiung.Items.Clear();
            lstIdDiung.Items.Clear();
            GetDataAllergic();
            txtDiung.Text = txtfood;
            txtDiung.ForeColor = Color.Gray;
        }
        #endregion

        #region TabLocation
        private void LoadLocation()
        {
            string sql = string.Format("SELECT * FROM info WHERE iduser='{0}'", id);
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                if (!String.IsNullOrEmpty(rd["country"].ToString()))
                {
                    txtCountry.SelectedIndex = txtCountry.FindStringExact(rd["country"].ToString());

                    LoadCityData();
                    LoadDistrictData();
                    txtCity.Text = rd["city"].ToString();
                    txtDistrict.Text = rd["district"].ToString();
                }
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
                foreach (var country in countryname)
                {
                    txtCountry.Items.Add(country.Name);
                }
            }
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

        private void txtCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCityData();
            txtDistrict.Items.Clear();
            txtDistrict.Items.Add("");
        }

        private void txtCity_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadDistrictData();
        }

        private void btnReset4_Click(object sender, EventArgs e)
        {
            LoadLocation();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (txtCountry.Text == "")
                alert.Show("Vui lòng chọn vị trí hiện tại của bạn!", alert.AlertType.error);
            else
            {
                string strUpdate = string.Format("UPDATE info set country='{0}', city='{1}', district='{2}' where iduser='{3}'", txtCountry.Text, txtCity.Text, txtDistrict.Text, lib.GetID());
                databaseObject.RunSQL(strUpdate);
                UpdateProfileSeverAsync(txtCountry.Text, txtCity.Text, txtDistrict.Text, inputBirthday.Value.ToString(), ConvertGender().ToString());
                alert.Show("Cập nhật thông tin thành công !", alert.AlertType.success);

                FrmDashboard frm = new FrmDashboard();
                frm.Message = "0";
                frm.Show();
            }
        }

        private async void UpdateProfileSeverAsync(string country, string city, string district, string birthday, string gender)
        {

            var values = new Dictionary<string, string>
            {
                {"user", lib.GetUsername()},
                {"birthday", birthday},
                {"gender", gender},
                {"country", country},
                {"city", city},
                {"district", district}
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(sSever.linksever + "dashboard/api/user/update-profile/", content);
            var responseString = await response.Content.ReadAsStringAsync();
        }

        private void btnPre4_Click(object sender, EventArgs e)
        {
            PrePage();
        }
        #endregion


        //Future Code
        /*
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
        */
    }
}
