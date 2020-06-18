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
        GAVer2 GA = new GAVer2();
        GACal gaCal = new GACal();

        //Send data to frmDashboard
        public delegate void GETDATA(string data);
        public GETDATA mydata;

        //Get data from frmViewHistoryMenu
        public void GETVALUE(string value)
        {
            lblData.Text = value;
        }

        //Get data from frmCustomFood
        public void GETVALUE2(string[] newItem)
        {
            if (newItem[2] == "0") //Breakfast
                pnlLoadBreakfast.Controls.Add(ItemFoodCustom.Add(Convert.ToInt64(newItem[0]), newItem[1], 0)); // Mode = 0 -> Full permison
            if (newItem[2] == "1") //Lunch
                pnlLoadLunch.Controls.Add(ItemFoodCustom.Add(Convert.ToInt64(newItem[0]), newItem[1], 0));
            if (newItem[2] == "2") //Dinner
                pnlLoadDinner.Controls.Add(ItemFoodCustom.Add(Convert.ToInt64(newItem[0]), newItem[1], 0));
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
            if(lib.countRow(mainSQL) > 0)
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
                {
                    createNewMenu(DateTime.Today.ToString("dd/MM/yyyy"));
                    alert.Show("Khởi tạo thực đơn hoàn tất!", alert.AlertType.success);
                    //alert.Show("Vui lòng thiết lập thực đơn!", alert.AlertType.info);
                }
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
                calMenu = rd["cal_menu"].ToString();
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
                        plnPanel.Controls.Add(ItemFoodCustom.Add(idFood, namefood, 0)); // Mode = 0 -> Full permison 
                }
                command.Dispose();
            }
            databaseObject.CloseConnection();
        }

        private void createNewMenu(string day)
        {
           // if (lib.CheckExists("settings", "id", 1, ""))
           // {
            int subtractDay = -1;
            string recentDay = DateTime.Today.AddDays(subtractDay).ToString("dd/MM/yyyy");
            mainSQL = string.Format("SELECT * FROM menu WHERE date ='{0}'", recentDay);
            while(lib.countRow(mainSQL) <= 0)
            {
                subtractDay--;
                recentDay = DateTime.Today.AddDays(subtractDay).ToString("dd/MM/yyyy");
                mainSQL = string.Format("SELECT * FROM menu WHERE date ='{0}'", recentDay);
            }

            int mod = 0, protein = 0, lipid = 0, carb = 0, p_breakfast = 0, p_lunch = 0, p_dinner = 0, calo = 0;
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(mainSQL, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                breakfast = Convert.ToInt32(rd["breakfast"]);
                lunch = Convert.ToInt32(rd["lunch"]);
                dinner = Convert.ToInt32(rd["dinner"]);
                protein = Convert.ToInt32(rd["protein"]);
                lipid = Convert.ToInt32(rd["lipid"]);
                carb = Convert.ToInt32(rd["carb"]);
                p_breakfast = Convert.ToInt32(rd["p_breakfast"]);
                p_lunch = Convert.ToInt32(rd["p_lunch"]);
                p_dinner = Convert.ToInt32(rd["p_dinner"]);
                mod = Convert.ToInt32(rd["mod"]);
                calo = Convert.ToInt32(rd["calo"]);
            }
            command.Dispose();
            databaseObject.CloseConnection();

            runSQL.SQLforMenuTable(breakfast, lunch, dinner, calo, protein, lipid, carb, p_breakfast, p_lunch, p_dinner, mod, day);

            frmSettingsMenu frm = new frmSettingsMenu();
            frm.generateMenuForToday(mod, day);
            getDataFromMenuTable(true);
           // }
           /*
            else
            {
                //alert.Show("Vui lòng thiết lập thực đơn!", alert.AlertType.info);
                //mydata("2.1");
            }*/
        }

        private void btnSettingsMenu_Click(object sender, EventArgs e)
        {
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
            //alert.Show("Tính năng đang phát triển!", alert.AlertType.info);
            
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

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            frmCustomFood frm = new frmCustomFood(2, "-1", ""); // Add item
            frm.mydata2 = new frmCustomFood.GETDATA2(GETVALUE2); //Get data from frmCustomFood
            frm.Show();
        }

        private void btnInfomationMenu_Click(object sender, EventArgs e)
        {
            frmInfoMenu frm = new frmInfoMenu();
            frm.ShowDialog();
        }

        //Create menu

        private string getDataEdit(FlowLayoutPanel plnPanel, int nItems)
        {
            int count = 0;
            string editMenu = "";
            foreach (var ctrl in plnPanel.Controls.OfType<UserControl>())
            {
                editMenu += ctrl.Name + " ";
                count++;
            }
            return editMenu;
        }

        private bool checkFullItems(string editMenu)
        {
            int[] DNA = editMenu.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            foreach (var i in DNA)
            {
                if (i == -1)
                {
                    return false;
                }
            }
            return true;
        }

        private void createMenu_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "";
            string editMenu = "";
            string day = DateTime.Today.ToString("dd/MM/yyyy");

            editMenu += getDataEdit(pnlLoadBreakfast, breakfast);
            editMenu += getDataEdit(pnlLoadLunch, lunch);
            editMenu += getDataEdit(pnlLoadDinner, dinner);

            lblTitle.Text = editMenu;
            
            GA.MainGA(editMenu, day);
            gaCal.RunGACal(day);
            /*
            if (checkFullItems(editMenu))
            {
                //Add function: Đánh giá món ăn người dùng chọn 
                string strUdpate = string.Format("UPDATE menu set recommend='{0}' where date='{1}'", editMenu, DateTime.Today.ToString("dd/MM/yyyy"));
                databaseObject.RunSQL(strUdpate);
                gaCal.RunGACal(day);
            }
            else
            {
                GA.MainGA(editMenu, day);
                gaCal.RunGACal(day);
            }*/
            removeControlInPanel();
            pnlAdvCustomMenu.Hide();
            getDataFromMenuTable(true);
            alert.Show("Điều chỉnh thực đơn thành công!", alert.AlertType.success);
        }
    }
}
