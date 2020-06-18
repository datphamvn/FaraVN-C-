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
    public partial class frmCustomFood : Form
    {
        ItemFoodCustom item;
        private string[] arrDataFoodName;
        int mode; 

        //Send data to ItemCustomFood in frmMenuFood (Mode: Edit)
        public delegate void GETDATA(string[] data);
        public GETDATA mydata;

        //Send data to frmMenuFood (Mode: Add item)
        public delegate void GETDATA2(string[] data2);
        public GETDATA2 mydata2;

        //Mode = 1: Edit
        //Mode = 2: Add
        public frmCustomFood(int _mode, string defIDFood, string defNameFood) 
        {
            InitializeComponent();

            mode = _mode;
            item = new ItemFoodCustom(Convert.ToInt64(defIDFood), defNameFood, 1);
            if (mode == 2)
            {
                btnSave.Text = "Thêm";
                btnSave.Enabled = false;
            }
        }
        
        private void openChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlAddData.Controls.Add(childForm);
            pnlAddData.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        //Get data from frmAddData
        public void GETVALUE(string value)
        {
            if (mode == 2) // Add item
            {
                value = value + ";" + "-1";
                btnSave.Enabled = true;
            }
            arrDataFoodName = value.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            item.IDfoodName = arrDataFoodName[0];
            item.foodName = arrDataFoodName[1];
        }

        private void frmCustomFood_Load(object sender, EventArgs e)
        {
            frmAddData frm = new frmAddData("frmMenuFood");
            frm.mydata = new frmAddData.GETDATA(GETVALUE); //Get data from frmAddData
            openChildForm(frm);

            pnlItemFoodPreview.Controls.Add(item);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mode == 1) // Sửa
            {
                mydata(arrDataFoodName);
                alert.Show("Đã cập nhật!", alert.AlertType.success);
                this.Close();
            }
            if (mode == 2) // Thêm
            {
                int cbxTimeIndex = cbxTime.SelectedIndex;
                if(cbxTimeIndex == -1)
                    alert.Show("Vui lòng chọn thời điểm thêm món ăn!", alert.AlertType.error);
                else
                {
                    arrDataFoodName[2] = cbxTimeIndex.ToString();
                    mydata2(arrDataFoodName);
                    alert.Show("Đã thêm mới!", alert.AlertType.success);
                }
            }
        }
    }
}
