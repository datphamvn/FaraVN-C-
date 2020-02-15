using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrolyaoFara
{
    public partial class frmInfoFood : Form
    {
        Database databaseObject = new Database();

        public frmInfoFood(int idFood, string nameFood)
        {
            InitializeComponent();

            lblTitle.Text = "Công thức món: " + nameFood;
            string sql = string.Format("SELECT * FROM ai_food WHERE id='{0}'", idFood);
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                webBrowser1.DocumentText = rd["content"].ToString();
            }
            command.Dispose();
            databaseObject.CloseConnection();
        }

        public static void Show(int idFood, string nameFood)
        {
            new frmInfoFood(idFood, nameFood).Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
