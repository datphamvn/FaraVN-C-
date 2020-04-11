using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Threading;

namespace TrolyaoFara
{
    public partial class frmLogin : Form
    {
        Database databaseObject = new Database();
        SettingSever sSever = new SettingSever();
        LoadData lData = new LoadData();
        LibFunction lib = new LibFunction();
        SQLquery sql = new SQLquery();

        public frmLogin()
        {
            InitializeComponent();
        }

        #region SomeFunction
        void LoadMainForm()
        {
            if (lib.CheckExists("account","login",-1,"True"))
            {
                this.Hide();
                Form1 frm = new Form1();
                frm.ShowDialog();
                this.Close();
            }
        }
        
        static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        #endregion


        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = PicLogo;
            sql.createTableForDatabase();
            LoadMainForm();
            panelLoad.Visible = false;
        }

        #region Custom UI
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if(txtUsername.Text == "Username")
            {
                txtUsername.ResetText();
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.ResetText();
                txtPassword.isPassword = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.isPassword = false;
            }
        }
        #endregion

        #region Function_For_Form
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        private async void btnLogin_ClickAsync(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username" || txtPassword.Text == "Password")
                alert.Show("Vui lòng điền đầy đủ thông tin", alert.AlertType.warning);
            else
            {
                btnLogin.Enabled = false;
                string username, email;
                string userlogin = txtUsername.Text;
                string password = txtPassword.Text;
                if (IsValidEmail(userlogin))
                {
                    username = "";
                    email = userlogin;
                }
                else
                {
                    username = userlogin;
                    email = "";
                }

                var client = new HttpClient();

                // Create the HttpContent for Login Form
                var requestContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("email", email),
                });

                if (lib.CheckForInternetConnection())
                {
                    try
                    {
                        HttpResponseMessage response = client.PostAsync(sSever.linksever + "dashboard/api/user/login/", requestContent).Result;
                        HttpContent responseContent = response.Content;

                        string stt;
                        using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
                        {
                            stt = await reader.ReadToEndAsync();
                            if (stt.Contains("non_field_errors"))
                            {
                                btnLogin.Enabled = true;
                                alert.Show("Username/Password không chính xác !", alert.AlertType.error);
                            }
                            else
                            {
                                Thread thread = new Thread(() =>
                                {
                                    LoginAsync(stt, username, email, password);
                                    Action action = new Action(LoadMainForm);
                                    this.BeginInvoke(action);
                                });
                                thread.Start();

                                panelLoad.Visible = true;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        alert.Show("Lỗi Server!", alert.AlertType.error);
                        btnLogin.Enabled = true;
                    }
                }
                else
                {
                    alert.Show("Vui lòng kết nối Internet!", alert.AlertType.error);
                    btnLogin.Enabled = true;
                }
            }
        }

        public void getInfoUserFormServer(long iduser)
        {
            // Biến lưu thông tin
            string lname = "", fname = "";
            string birthday = DateTime.Now.ToString("dd/MM/yyyy"), district = "", city = "", country = "";
            int gender = 0;
            int height = 0, weight = 0, neck = 0, waist = 0, hip = 0, intensity = 0;

            // Load Họ và tên User
            try
            {
                var jsondetailuser = new WebClient().DownloadString(sSever.linksever + "dashboard/api/user/" + iduser.ToString());
                var detailuser = JsonConvert.DeserializeObject<DetailUser>(jsondetailuser);

                byte[] bytes = Encoding.Default.GetBytes(detailuser.LastName.ToString());
                lname = Encoding.UTF8.GetString(bytes);
                byte[] bytes1 = Encoding.Default.GetBytes(detailuser.FirstName.ToString());
                fname = Encoding.UTF8.GetString(bytes1);
            }
            catch (WebException)
            {
                alert.Show("Lỗi Server!", alert.AlertType.error);
                //alert.Show("ERROR: LDATA1 - Load họ tên user không thành công !", alert.AlertType.error);
            }

            //Load thong tin ca nhan
            try
            {
                var jsondata = new WebClient().DownloadString(sSever.linksever + "dashboard/api/profile/" + iduser.ToString());
                var info = JsonConvert.DeserializeObject<LoadInfo>(jsondata);
                //Download Avata User
                /*
                    using (WebClient img = new WebClient())
                    {
                        img.DownloadFile(new Uri(info.image.ToString()), lData.loginimg);
                    }
                */

                birthday = info.birthday;
                district = info.district;
                city = info.city;
                country = info.country;
                gender = info.gender;
            }
            catch (WebException)
            {
                alert.Show("Lỗi Server!", alert.AlertType.error);
                //alert.Show("ERROR: LDATA3 - Cập nhật thông tin User không thành công !", alert.AlertType.error);
            }

            // Load thong tin suc khoe
            try
            {
                var jsonhealthidx = new WebClient().DownloadString(sSever.linksever + "dashboard/api/healthidx/" + iduser.ToString());
                var healthidx = JsonConvert.DeserializeObject<HealthIdx>(jsonhealthidx);

                height = healthidx.height;
                weight = healthidx.weight;
                neck = healthidx.neck;
                waist = healthidx.waist;
                hip = healthidx.hip;
                intensity = healthidx.intensity;
            }
            catch (WebException)
            {
                alert.Show("Lỗi Server!", alert.AlertType.error);
                //alert.Show("ERROR: LDATA4 - Cập nhật thông số sức khỏe User không thành công !", alert.AlertType.error);
            }

            sql.SQLforInfoTable(lname, fname, gender, birthday, district, city, country, height, weight, neck, waist, hip, intensity);
        }

        private void LoginAsync(string stt, string username, string email, string password)
        {
            var data = JsonConvert.DeserializeObject<LoadUser>(stt);

            if (lib.CheckExists("account", "username", -1, username) || lib.CheckExists("account", "email", -1, email))
            {
                string strUpdate = string.Format("UPDATE account set login='{0}', password='{1}' where username='{2}' or email='{3}'", "True", Encrypt(password), username, email);
                databaseObject.RunSQL(strUpdate);
            }
            else
            {
                string strInsert = string.Format("INSERT INTO account(username, email, password, iduser, login) VALUES('{0}','{1}','{2}','{3}','{4}')", username, email, Encrypt(password), data.id, "True");
                databaseObject.RunSQL(strInsert);

                getInfoUserFormServer(data.id);
            }
        }

        private void lblPasswordReset_Click(object sender, EventArgs e)
        {
            if (lib.CheckForInternetConnection())
                System.Diagnostics.Process.Start(sSever.linksever + "accounts/password_reset");
            else
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
        }

        private void lblCreateAcc_Click(object sender, EventArgs e)
        {

            if (lib.CheckForInternetConnection())
                System.Diagnostics.Process.Start(sSever.linksever + "register");
            else
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
        }
    }
}
