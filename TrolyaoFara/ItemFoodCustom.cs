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
    public partial class ItemFoodCustom : UserControl
    {
        public ItemFoodCustom(long id, string namefood)
        {
            InitializeComponent();

            lblID.Text = id.ToString();
            lblNameFood.Text = namefood;

            hideCustomGram();
            txtGram.Text = "100";
        }

        public String foodNamePreview
        {
            //get { return FoodName; }
            set { lblNameFood.Text = value; }
        }

        public string FoodName;
        public String foodName
        {
            get { return FoodName; }
            set { lblNameFood.Text = value; }
        }

        private static ItemFoodCustom _instance;
        public static ItemFoodCustom Add(long id, string namefood)
        {
            _instance = new ItemFoodCustom(id, namefood);
            return _instance;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void hideCustomGram()
        {
            lblGr.Hide();
            txtGram.Hide();
            btnUpGr.Hide();
            btnDownGr.Hide();
        }

        private void switchStt_CheckedChanged(object sender, EventArgs e)
        {
            if(switchStt.Checked == true)
            {
                hideCustomGram();
            }
            else
            {
                lblGr.Show();
                txtGram.Show();
                btnUpGr.Show();
                btnDownGr.Show();
            }
        }

        private void txtGram_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
        }

        private void btnUpGr_Click(object sender, EventArgs e)
        { 
            int value = Convert.ToInt32(txtGram.Text);
            value++;
            txtGram.Text = value.ToString();
        }

        private void btnDownGr_Click(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(txtGram.Text);
            value--;
            txtGram.Text = value.ToString();
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            frmCustomFood frm = new frmCustomFood();
            frm.Show();
        }
    }
}
