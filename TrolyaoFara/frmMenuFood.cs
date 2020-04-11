using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrolyaoFara
{
    public partial class frmMenuFood : Form
    {
        Database databaseObject = new Database();
        ExportMenuToImage exportMenu = new ExportMenuToImage();
        LibFunction lib = new LibFunction();

        public delegate void GETDATA(string data);
        public GETDATA mydata;

        string strmenu = "";
        int breakfast = 0, lunch = 0, dinner = 0;
        int heightDefault = 0;
        int[] idMenu;
        double[] calMenuArr;

        public frmMenuFood()
        {
            InitializeComponent();
        }

        private void frmMenuFood_Load(object sender, EventArgs e)
        {
            getDataFromMenuTable();
        }

        public void getDataFromMenuTable()
        {
            string today = DateTime.Today.ToString("dd/MM/yyyy");
            string day = "";
            string sql = string.Format("SELECT * FROM menu WHERE id=1");
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                strmenu = rd["recommend"].ToString();
                breakfast = Convert.ToInt32(rd["breakfast"]);
                lunch = Convert.ToInt32(rd["lunch"]);
                dinner = Convert.ToInt32(rd["dinner"]);
                day = rd["date"].ToString();
            }
            command.Dispose();

            databaseObject.CloseConnection();
            if (strmenu != "" && today == day)
                loadMenuForUser();
            else
                createNewMenu();
        }

        public void loadMenuForUser()
        {
            idMenu = strmenu.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string calMenu = "";

            string sql = string.Format("SELECT * FROM menu WHERE id=2");
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                calMenu = rd["recommend"].ToString();
            }
            command.Dispose();
            databaseObject.CloseConnection();

            calMenuArr = calMenu.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            loadItemToPanel(0, breakfast, idMenu, calMenuArr, pnlLoadBreakfast);
            loadItemToPanel(breakfast, breakfast + lunch, idMenu, calMenuArr, pnlLoadLunch);
            loadItemToPanel(breakfast + lunch, breakfast + lunch + dinner, idMenu, calMenuArr, pnlLoadDinner);
        }

        public void loadItemToPanel(int begin, int end, int[] idmenu, double[] grmenu, FlowLayoutPanel plnPanel)
        {
            int id, timer;
            string namefood;
            long idFood;
            double calo;

            databaseObject.OpenConnection();
            for (int i = begin; i < end; i++)
            {
                id = idmenu[i] + 1;
                string sql = string.Format("SELECT * FROM food_db WHERE id='{0}'", id);

                SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
                SQLiteDataReader rd = command.ExecuteReader();
                while (rd.Read())
                {
                    idFood = Convert.ToInt64(rd["id_food"].ToString());
                    namefood = rd["name"].ToString();
                    timer = Convert.ToInt32(rd["timer"].ToString());
                    calo = Convert.ToDouble(rd["calo"].ToString());
                    plnPanel.Controls.Add(ItemFood.Add(idFood, namefood, timer, calo, grmenu[i]));
                }
                command.Dispose();
            }
            databaseObject.CloseConnection();
        }

        private void createNewMenu()
        {
            frmSettingsMenu frm = new frmSettingsMenu();
            frm.generateMenuForToday();
            getDataFromMenuTable();
        }


        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            lblTab.Text = "3";
            mydata(lblTab.Text);
        }

        // Capture a picture

        private static Bitmap DrawControlToBitmap(Control control)
        {
            Bitmap bitmap = new Bitmap(control.Width, control.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            Rectangle rect = control.RectangleToScreen(control.ClientRectangle);
            graphics.CopyFromScreen(rect.Location, Point.Empty, control.Size);
            return bitmap;
        }

        private void setHeightPanel(Panel pnlParent, Panel pnlLoad, int row)
        {
            row = (row + row % 2) / 2;
            pnlLoad.Height = heightItemFood * row + row * 5;
            pnlParent.Height = pnlLoad.Height + pnlTitleBreakfast.Height + 5;
        }

        private void restorePanel(Panel pnlParent, Panel pnlLoad)
        {
            pnlLoad.Height = heightDefault;
            pnlParent.Height = pnlTitleBreakfast.Height + heightDefault + 2;
        }

        private void capturePanel(Panel prePanel, Panel pnlParent, Panel pnlLoad, int row, string imgname)
        {
            prePanel.Hide();
            setHeightPanel(pnlParent, pnlLoad, row);
            pnlParent.Update();
            Bitmap bitmap = DrawControlToBitmap(pnlParent);
            bitmap.Save(localstr + imgname);
        }

        int heightItemFood = 144;
        string localstr;
        private void btnExportMenu_Click(object sender, EventArgs e)
        {
            heightDefault = pnlLoadBreakfast.Height;

            localstr = lib.getPathDataInPCUser(@"\.faraVN\Data\img\");
            Bitmap bitmap = DrawControlToBitmap(pnlHeading);
            bitmap.Save(localstr + "title.png");
            capturePanel(pnlHeading, pnlBreakfast, pnlLoadBreakfast, breakfast, "breakfast.png");
            capturePanel(pnlBreakfast, pnlLunch, pnlLoadLunch, lunch, "lunch.png");
            capturePanel(pnlLunch, pnlDinner, pnlLoadDinner, dinner, "dinner.png");

            // Restore Panel
            pnlHeading.Show();
            pnlBreakfast.Show();
            restorePanel(pnlBreakfast, pnlLoadBreakfast);
            pnlLunch.Show();
            restorePanel(pnlLunch, pnlLoadLunch);
            restorePanel(pnlDinner, pnlLoadDinner);
            pnlFullMenu.Update();

            exportMenu.ExportToImage();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {/*
            string sql = "CREATE TABLE IF NOT EXISTS db_food([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, id_food INTEGER NOT NULL, id_purpose INTEGER NOT NULL, id_type INTEGER NOT NULL, id_method INTEGER NOT NULL, calo INTEGER NOT NULL)";
            databaseObject.RunSQL(sql);
            if (lib.CheckForInternetConnection())
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(sSever.linksever + "ai/api/food/");
                    List<Food> data = JsonConvert.DeserializeObject<List<Food>>(json);
                    foreach (var item in data)
                    {
                        string strInsert = string.Format("INSERT INTO db_food(id_food, id_purpose, id_type, id_method, calo) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", item.Id, lib.GetFirstValueinList(item.Purpose), lib.GetFirstValueinList(item.Type), lib.GetFirstValueinList(item.Method), item.Calo);
                        databaseObject.RunSQL(strInsert);
                    }
                }
            }
            else
                alert.Show("Vui lòng kết nối Internet !", alert.AlertType.error);
                */
        }

        private void btnExportComposition_Click(object sender, EventArgs e)
        {
            frmComposition composition = new frmComposition(idMenu, calMenuArr);
            composition.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //flowLayoutPanel1.Controls.Add(ItemFood.Instance);
        }


        #region TabSettings
        /*
        public void GetDataFormSettings()
        {
            string sql = string.Format("SELECT * FROM settings");
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                numBreakfast.Value = Convert.ToInt32(rd["breakfast"]);
                numLunch.Value = Convert.ToInt32(rd["lunch"]);
                numDinner.Value = Convert.ToInt32(rd["dinner"]);
                cbxMode.SelectedIndex = Convert.ToInt32(rd["mode"]);
            }
            command.Dispose();
            databaseObject.CloseConnection();
        }
        */
        #endregion

        private void RemoveControlInPanel()
        {
            pnlLoadBreakfast.Controls.Clear();
            pnlLoadLunch.Controls.Clear();
            pnlLoadDinner.Controls.Clear();
        }

    }
}
