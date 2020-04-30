using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrolyaoFara
{
    public partial class ItemFood : UserControl
    {
        public ItemFood(long id, string namefood, int timer, double calo, double factor)
        {
            InitializeComponent();

            lblFactor.Text = factor.ToString();
            lblID.Text = id.ToString();
            lblNameFood.Text = namefood;
            lblTimer.Text = timer.ToString() + " min";
            lblGr.Text = Convert.ToInt32(factor*calo).ToString() + " Calo";
        }

        private static ItemFood _instance;

        public static ItemFood Add(long id, string namefood, int timer, double calo, double factor)
        {
            _instance = new ItemFood(id, namefood, timer, calo, factor);
            return _instance;
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            frmGuideForFood infofood = new frmGuideForFood(Convert.ToInt32(lblID.Text), lblNameFood.Text, Convert.ToDouble(lblFactor.Text));
            infofood.ShowDialog();
        }
    }
}
