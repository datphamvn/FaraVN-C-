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
        LibFunction lib = new LibFunction();

        // Mode = 1 -> Preview mode
        public ItemFoodCustom(long id, string namefood, int mode)
        {
            InitializeComponent();

            this.Name = id.ToString();
            lblID.Text = id.ToString();
            lblNameFood.Text = namefood;
            hideCustomGram();
            txtGram.Text = "100";

            if(mode == 1)
            {
                btnSwitch.Enabled = false;
                btnClose.Enabled = false;
                pnlCustomGr.Enabled = false;
            }

            if(id >= 0)
                lib.getImgForFoodItem(lblID.Text, imgFood);
        }

        //Get data from frmCustomFood
        public void GETVALUE(string[] infoUpdate)
        {
            lblID.Text = infoUpdate[0];
            lblNameFood.Text = infoUpdate[1];
        }

        public string _foodName;
        public String foodName
        {
            get { return _foodName; }
            set { lblNameFood.Text = value; }
        }

        public string _IDfoodName;
        public String IDfoodName
        {
            get { return _IDfoodName; }
            set { lblID.Text = value; }
        }

        private static ItemFoodCustom _instance;
        public static ItemFoodCustom Add(long id, string namefood, int mode)
        {
            _instance = new ItemFoodCustom(id, namefood, mode);
            return _instance;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa item này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                this.Name = "-1";
            }
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
            frmCustomFood frm = new frmCustomFood(1, lblID.Text, lblNameFood.Text); // Edit item
            frm.mydata = new frmCustomFood.GETDATA(GETVALUE); //Get data from frmAddData
            frm.Show();
        }

        private void lblID_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt64(lblID.Text) >= 0)
            {
                lib.getImgForFoodItem(lblID.Text, imgFood);
                this.Name = lblID.Text;
            }
        }
    }
}
