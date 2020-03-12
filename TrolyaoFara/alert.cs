using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrolyaoFara
{
    public partial class alert : Form
    {
        public alert(string _message, AlertType type, int height)
        {
            InitializeComponent();

            label1.Text = _message;
            switch (type)
            {
                case AlertType.success:
                    this.BackColor = Color.SeaGreen;
                    pictureBox1.Image = imageList1.Images[0];
                    break;
                case AlertType.info:
                    this.BackColor = Color.SteelBlue;
                    pictureBox1.Image = imageList1.Images[1];
                    break;
                case AlertType.warning:
                    this.BackColor = Color.FromArgb(255, 128, 0);
                    pictureBox1.Image = imageList1.Images[2];
                    break;
                case AlertType.error:
                    this.BackColor = Color.Crimson;
                    pictureBox1.Image = imageList1.Images[2];
                    break;
            }
            this.Height = height;
        }

        public enum AlertType
        {
            success, info, warning, error
        }

        public static void Show(string message, AlertType type, int height=81)
        {
            new alert(message, type, height).Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            close_alert.Start();
        }

        private void timeout_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        int interval = 0;

        private void show_Tick(object sender, EventArgs e)
        {
            if(this.Top < 60)
            {
                this.Top += interval;
                interval += 2;
            }
            else
            {
                show.Stop();
            }
        }

        private void close_Tick(object sender, EventArgs e)
        {
            if(this.Opacity>0)
            {
                this.Opacity -= 0.1 ;
            }
            else
            {
                this.Close();
            }
        }

        private void loadfrm ()
        {
            int alrt = -1;
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                //iterate through
                if (frm.Name == "alert")
                {
                    alrt++;
                }
            }

            this.Top = alrt * (this.Height + 4) + 5;
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 10;
        }

        private void alert_Load(object sender, EventArgs e)
        {
            loadfrm();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            loadfrm();
        }
    }

}
