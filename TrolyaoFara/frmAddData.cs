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
    public partial class frmAddData : Form
    {
        string textFood = "Nhập tên món ăn";
        List<string> listFood = new List<string>();
        List<long> listIdFood = new List<long>();
        List<string> listComposition = new List<string>();
        List<long> listIdComposition = new List<long>();

        //Send data to other form
        public delegate void GETDATA(string data);
        public GETDATA mydata;

        private string typeForm;

        public frmAddData(string _typeForm)
        {
            InitializeComponent();
            typeForm = _typeForm;
        }

        private void frmAddData_Load(object sender, EventArgs e)
        {
            frmUpdateInfo frm = new frmUpdateInfo();

            //setting when call from frmMenuFood
            if(typeForm == "frmMenuFood")
            {
                this.BackColor = Color.FromArgb(14, 20, 47);
            }

            txtInput.Enabled = false;
            frm.LoadFoodFavourite(imgLoading, txtInput);

            listFood = frm.listFood;
            listIdFood = frm.listIdFood;
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            var textBoxContent = txtInput.Text;
        }

        private void txtInput_Enter(object sender, EventArgs e)
        {
            if (txtInput.Text == textFood)
            {
                txtInput.ResetText();
                txtInput.ForeColor = Color.Black;
            }
        }

        private void txtInput_Leave(object sender, EventArgs e)
        {
            if (txtInput.Text == "")
            {
                txtInput.Text = textFood;
                txtInput.ForeColor = Color.Gray;
            }
        }

        private void txtInput_KeyUp(object sender, KeyEventArgs e)
        {
            lstData.Items.Clear();
            lstIDData.Items.Clear();
            txtInput.ForeColor = Color.Black;
            if (!(string.IsNullOrEmpty(txtInput.Text.Trim()) || txtInput.Text == textFood))
            {
                int idx = 0;
                foreach (string str in listFood)
                {
                    if (str.ToUpper().Contains(txtInput.Text.ToUpper()))
                    {
                        lstData.Items.Add(str);
                        lstIDData.Items.Add(listIdFood[idx]);
                    }
                    idx++;
                }
                lstData.Show();
            }
            else
                lstData.Hide();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string itemsel = lstData.GetItemText(lstData.SelectedItem);
            if (string.IsNullOrEmpty(itemsel))
                return;

            lstIDData.SelectedIndex = lstData.Items.IndexOf(lstData.SelectedItem);
            string idUser = lstIDData.GetItemText(lstIDData.SelectedItem);

            mydata(idUser + ";" + itemsel);
        }
    }
}
