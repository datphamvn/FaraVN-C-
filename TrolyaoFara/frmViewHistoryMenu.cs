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
    public partial class frmViewHistoryMenu : Form
    {
        //Send data to frmMenuFood
        public delegate void GETDATA(string data);
        public GETDATA mydata;

        public frmViewHistoryMenu()
        {
            InitializeComponent();

            pickDatetime.Value = DateTime.Today;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            double historyMenu = (DateTime.Today - pickDatetime.Value).TotalDays;
            if (historyMenu >= 0 && historyMenu <= 365)
                mydata((-historyMenu).ToString());
            else
                alert.Show("Thời gian không hợp lệ!", alert.AlertType.error);
        }

        private void btnMenuToday_Click(object sender, EventArgs e)
        {
            pickDatetime.Value = DateTime.Today;
            mydata("0");
        }
    }
}
