using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrolyaoFara
{
    public partial class frmAbout : Form
    {
        SettingSever sSever = new SettingSever();
        string pathsave = Environment.CurrentDirectory + "/log.zip";
        WebClient wc;

        string version = "0.1.0.0";

        public frmAbout()
        {
            InitializeComponent();
        }

        string linkdown = "";
        private void frmAbout_Load(object sender, EventArgs e)
        {
            pnlUpdate.Hide();
            lblVersion.Text = "Version " + version;

            wc = new WebClient();
            string webData = wc.DownloadString(sSever.linksever + "version");
            string[] data = webData.Split(';');
            if (data[0] != version)
            {
                alert.Show("Hiện có phiên bản mới!", alert.AlertType.info);
                pnlUpdate.Show();
                linkdown = data[1];
            }

            
            wc.DownloadProgressChanged += Client_DownloadProgressChanged;
            wc.DownloadFileCompleted += Clinet_DownloadFileCompleted;
        }

        private void Clinet_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            RunFile(pathsave);
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                ProgressBarDown.Minimum = 0;
                double receive = double.Parse(e.BytesReceived.ToString());
                double total = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = receive / total * 100;
                ProgressBarDown.Value = int.Parse(Math.Truncate(percentage).ToString());
            }
            ));
        }

        private void RunFile(string pathsave)
        {
            Process process = Process.Start(pathsave);
            int id = process.Id;
            Process tempProc = Process.GetProcessById(id);
            Application.Exit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(pathsave))
            {
                Thread thread = new Thread(() =>
                {
                    wc.DownloadFileAsync(
                        new System.Uri(linkdown), pathsave
                    );

                });
                thread.Start();
            }
            else
                RunFile(pathsave);
        }
    }
}
