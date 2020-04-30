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

        private string _typeForm;
        public string typeForm
        {
            get { return _typeForm; }
            set { _typeForm = value; }
        }

        public frmAddData()
        {
            InitializeComponent();
        }

        private void frmAddData_Load(object sender, EventArgs e)
        {
            frmUpdateInfo frm = new frmUpdateInfo();
            frm.LoadFoodFavourite(imgLoading, txtInput);
            txtInput.Hide();

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
    }
}
