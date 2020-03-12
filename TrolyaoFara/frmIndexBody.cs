using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrolyaoFara
{
    public partial class frmIndexBody : Form
    {
        LibFunction lib = new LibFunction();
        Database databaseObject = new Database();
        public delegate void GETDATA(string data);
        public GETDATA mydata;

        int weight, height, neck, waist, hip, intensity;

        private void gunaGradientButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIndexBody_Load(object sender, EventArgs e)
        {
            iduser = lib.GetID();
            getDataFromInfoTable();
        }

        int iduser;

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            lblTab.Text = "2.1";
            mydata(lblTab.Text);
        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHeight.Text))
                alert.Show("Vui lòng nhập chiều cao của bạn!", alert.AlertType.error);
            else if (string.IsNullOrEmpty(txtWeight.Text))
                alert.Show("Vui lòng nhập cân nặng của bạn!", alert.AlertType.error);
            else if (cbxIntensity.SelectedIndex == -1)
                alert.Show("Vui lòng lựa chọn cường độ vận động của bạn!", alert.AlertType.error);
            else if (checkSkip.Checked == true)
            {
                if (string.IsNullOrEmpty(txtNeck.Text))
                    alert.Show("Vui lòng nhập số đo vòng cổ của bạn!", alert.AlertType.error);
                else if (string.IsNullOrEmpty(txtWaist.Text))
                    alert.Show("Vui lòng nhập số đo vòng eo của bạn!", alert.AlertType.error);
                else if (string.IsNullOrEmpty(txtHip.Text))
                    alert.Show("Vui lòng nhập số đo vòng mông của bạn!", alert.AlertType.error);
            }
            else
            {
                string strUpdate = string.Format("UPDATE info set height='{0}', weight='{1}', intensity='{2}', neck='{3}', waist='{4}', hip='{5}' where id='{6}'", txtHeight.Text, txtWeight.Text, cbxIntensity.SelectedIndex, txtNeck.Text, txtWaist.Text, txtHip.Text, iduser);
                databaseObject.RunSQL(strUpdate);
                alert.Show("Cập nhật thông tin thành công !", alert.AlertType.success);

                lblTab.Text = "2";
                mydata(lblTab.Text);
            }
        }

        public frmIndexBody()
        {
            InitializeComponent();
        }

        private void getDataFromInfoTable()
        {
            string sql = string.Format("SELECT * FROM info WHERE iduser='{0}'", iduser);
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                height = Convert.ToInt32(rd["height"]);
                weight = Convert.ToInt32(rd["weight"]);
                neck = Convert.ToInt32(rd["neck"]);
                waist = Convert.ToInt32(rd["waist"]);
                hip = Convert.ToInt32(rd["hip"]);
                intensity = Convert.ToInt32(rd["intensity"]);
            }
            command.Dispose();
            databaseObject.CloseConnection();
            //Load Data in textbox
            if (height > 0)
                txtHeight.Text = height.ToString();
            if (weight > 0)
                txtWeight.Text = weight.ToString();
            if (neck > 0)
                txtNeck.Text = neck.ToString();
            if (waist > 0)
                txtWaist.Text = waist.ToString();
            if (hip > 0)
                txtHip.Text = hip.ToString();
            if (intensity != -1)
                cbxIntensity.SelectedIndex = intensity;
        }
    }
}
