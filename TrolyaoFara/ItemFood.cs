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

        public ItemFood(int id, string namefood, int timer)
        {
            InitializeComponent();

            lblID.Text = id.ToString();
            lblNameFood.Text = namefood;
            lblTimer.Text = timer.ToString();
        }

        private static ItemFood _instance;

        public static ItemFood Add(int id, string namefood, int timer)
        {
            _instance = new ItemFood(id, namefood, timer);
            return _instance;
        }

        private void ItemFood_Load(object sender, EventArgs e)
        {

        }


        private void btnResetSetting_Click(object sender, EventArgs e)
        {
            frmInfoFood infofood = new frmInfoFood(Convert.ToInt32(lblID.Text), lblNameFood.Text);
            infofood.ShowDialog();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {

        }

    }
}
