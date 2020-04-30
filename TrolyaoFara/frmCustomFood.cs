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
        public string foodName;

        public frmCustomFood()
        {
            InitializeComponent();
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

        private void frmCustomFood_Load(object sender, EventArgs e)
        {
            openChildForm(new frmAddData());

            ItemFoodCustom item = new ItemFoodCustom(0, "");
            pnlItemFoodPreview.Controls.Add(item);
            item.foodNamePreview = foodName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
