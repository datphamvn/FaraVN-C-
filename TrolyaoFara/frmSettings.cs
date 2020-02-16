using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class frmSettings : Form
    {
        LibFunction lib = new LibFunction();
        SettingSever sSever = new SettingSever();
        GetData db = new GetData();
        Database databaseObject = new Database();


        private static readonly HttpClient client = new HttpClient();// Add


        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTraining frm = new frmTraining();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateInfoSeverAsync();
        }

        private async void UpdateInfoSeverAsync()
        {
            var values = new Dictionary<string, string>
            {
                {"user", "1"},
                {"food", "100"},
                {"ratings", "5"},
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(sSever.linksever + "ai/api/ratings/create/", content);
            var responseString = await response.Content.ReadAsStringAsync();
            textBox1.Text = responseString;
        }
    }
}
