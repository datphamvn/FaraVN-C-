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
        SQLquery runSQL = new SQLquery();

        //Send data to frmDashboard
        public delegate void GETDATA(string data);
        public GETDATA mydata;

        //Get data from frmViewHistoryMenu
        public void GETVALUE(string value)
        {
            lblData.Text = value;
        }

        string strmenu = "";
        int breakfast = 0, lunch = 0, dinner = 0;
        int heightDefault = 0, heightFullPanel = 0;
        int[] idMenu;
        double[] calMenuArr;
        int historyMenu = 0;
        string mainSQL;

        public frmMenuFood()
        {
            InitializeComponent();
        }

        private void frmMenuFood_Load(object sender, EventArgs e)
        {
            runSQL.createTableForDatabase(); // Dev Line
            getDataFromMenuTable(true);

            //Custom btnViewHistoryMenu
            btnNextMenu.Enabled = false;
            //Custom History menu
            heightFullPanel = pnlBreakfast.Height;
            //Custom Menu
            pnlAdvCustomMenu.Hide();
        }

        public void getDataFromMenuTable(bool todayView)
        {
            string day = DateTime.Today.AddDays(historyMenu).ToString("dd/MM/yyyy");

            mainSQL = string.Format("SELECT * FROM menu WHERE date ='{0}'", day);
            if(runSQL.countRow(mainSQL) > 0)
            {
                databaseObject.OpenConnection();
                SQLiteCommand command = new SQLiteCommand(mainSQL, databaseObject.myConnection);
                SQLiteDataReader rd = command.ExecuteReader();
                while (rd.Read())
                {
                    strmenu = rd["recommend"].ToString();
                    breakfast = Convert.ToInt32(rd["breakfast"]);
                    lunch = Convert.ToInt32(rd["lunch"]);
                    dinner = Convert.ToInt32(rd["dinner"]);
                }
                command.Dispose();
                databaseObject.CloseConnection();

                loadMenuForUser(1); // Load itemFood
                if (todayView)
                    lblTitle.Text = "Thực đơn hôm nay (" + day + ")";
                else
                    lblTitle.Text = "Thực đơn ngày " + day;
            }
            else
            {
                if (todayView)
                    createNewMenu();
                else
                {
                    lblTitle.Text = "Thực đơn ngày " + day;
                    alert.Show("Thực đơn ngày " + day + " không tồn tại !", alert.AlertType.info);

                    pnlBreakfast.Height = pnlTitleBreakfast.Height + 10;
                    pnlLunch.Height = pnlTitleLunch.Height + 10;
                    pnlDinner.Height = pnlTitleDinner.Height + 10;
                }
            }
        }

        public void loadMenuForUser(int mode)
        {
            //RestorePanel
            if(heightFullPanel != 0)
            {
                pnlBreakfast.Height = heightFullPanel;
                pnlLunch.Height = heightFullPanel;
                pnlDinner.Height = heightFullPanel;
            }

            idMenu = strmenu.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string calMenu = "";

            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(mainSQL, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                calMenu = rd["recommend"].ToString();
            }
            command.Dispose();
            databaseObject.CloseConnection();

            calMenuArr = calMenu.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            loadItemToPanel(0, breakfast, idMenu, calMenuArr, pnlLoadBreakfast, mode);
            loadItemToPanel(breakfast, breakfast + lunch, idMenu, calMenuArr, pnlLoadLunch, mode);
            loadItemToPanel(breakfast + lunch, breakfast + lunch + dinner, idMenu, calMenuArr, pnlLoadDinner, mode);
        }

        public void loadItemToPanel(int begin, int end, int[] idmenu, double[] grmenu, FlowLayoutPanel plnPanel, int mode)
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
                    if(mode == 1) // Load itemFood
                        plnPanel.Controls.Add(ItemFood.Add(idFood, namefood, timer, calo, grmenu[i]));
                    if(mode == 2) // Load itemFoodCustom
                        plnPanel.Controls.Add(ItemFoodCustom.Add(idFood, namefood));
                }
                command.Dispose();
            }
            databaseObject.CloseConnection();
        }

        private void createNewMenu()
        {
            int mod = 0;
            string sql = string.Format("SELECT * FROM settings WHERE id='{0}'", 1);
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                mod = Convert.ToInt32(rd["mod"]);
            }
            command.Dispose();
            databaseObject.CloseConnection();

            frmSettingsMenu frm = new frmSettingsMenu();
            frm.generateMenuForToday(mod);
            getDataFromMenuTable(true);
        }

        private void btnSettingsMenu_Click(object sender, EventArgs e)
        {
            //lblTab.Text = "3";
            mydata("3");
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
            //Settings
            heightDefault = pnlLoadBreakfast.Height;
            btnPreMenu.Hide();
            btnNextMenu.Hide();

            localstr = lib.getPathDataInPCUser(@"\.faraVN\Data\img\");
            Bitmap bitmap = DrawControlToBitmap(pnlHeading);
            bitmap.Save(localstr + "title.png");
            capturePanel(pnlHeading, pnlBreakfast, pnlLoadBreakfast, breakfast, "breakfast.png");
            capturePanel(pnlBreakfast, pnlLunch, pnlLoadLunch, lunch, "lunch.png");
            capturePanel(pnlLunch, pnlDinner, pnlLoadDinner, dinner, "dinner.png");

            // Restore Button
            btnPreMenu.Show();
            btnNextMenu.Show();
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


        private void btnExportComposition_Click(object sender, EventArgs e)
        {
            frmComposition composition = new frmComposition(idMenu, calMenuArr);
            composition.ShowDialog();
        }

        private void removeControlInPanel()
        {
            pnlLoadBreakfast.Controls.Clear();
            pnlLoadLunch.Controls.Clear();
            pnlLoadDinner.Controls.Clear();
        }

        //New feature
        private void btnPreMenu_Click(object sender, EventArgs e)
        {
            historyMenu--;
            lblData.Text = historyMenu.ToString();
        }

        private void btnNextMenu_Click(object sender, EventArgs e)
        {
            historyMenu++;
            lblData.Text = historyMenu.ToString();
        }

        private void btnViewHistoryMenu_Click(object sender, EventArgs e)
        {
            frmViewHistoryMenu frm = new frmViewHistoryMenu();
            frm.mydata = new frmViewHistoryMenu.GETDATA(GETVALUE);
            frm.Show();
        }

        private void viewHistoryMenu()
        {
            removeControlInPanel();
            historyMenu = Convert.ToInt32(lblData.Text);
            if (historyMenu == 0)
            {
                btnNextMenu.Enabled = false;
                btnCustomMenu.Enabled = true;
                getDataFromMenuTable(true);
            }
            else
            {
                btnNextMenu.Enabled = true;
                btnCustomMenu.Enabled = false;
                getDataFromMenuTable(false);
            }
        }

        private void lblData_TextChanged(object sender, EventArgs e)
        {
            viewHistoryMenu();
        }

        //Custom menu
        private void btnCustomMenu_Click(object sender, EventArgs e)
        {
            btnPreMenu.Enabled = false;
            btnNextMenu.Enabled = false;
            pnlAdvCustomMenu.Show();
            removeControlInPanel();
            loadMenuForUser(2); // Load itemFoodCustom
        }

        private void btnClearMenu_Click(object sender, EventArgs e)
        {
            removeControlInPanel();
        }

        private void btnBackMenu_Click(object sender, EventArgs e)
        {
            pnlAdvCustomMenu.Hide();
            btnPreMenu.Enabled = true;
            removeControlInPanel();
            loadMenuForUser(1); // Load itemFood
        }

        //Create menu
        private void createMenu_Click(object sender, EventArgs e)
        {
            foreach (var ctrl in pnlLoadLunch.Controls.OfType<UserControl>())
            {
                lblTitle.Text += ctrl + " ;";
            }
        }
    }
}
