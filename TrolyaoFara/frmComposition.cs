using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrolyaoFara
{
    public partial class frmComposition : Form
    {
        SettingSever sSever = new SettingSever();
        LibFunction lib = new LibFunction();

        public frmComposition(int[] idMenu, double[] calMenuArr)
        {
            InitializeComponent();

            int idx = 0;
            foreach (var item in idMenu)
            {
                frmGuideForFood frm = new frmGuideForFood(item, "", calMenuArr[idx]);
                frm.getDataUsingAsync(item, calMenuArr[idx], panelLoad, gunaDataGridView2, false);
                idx++;
            }
        }

        public static void Show(int[] idMenu, double[] calMenuArr)
        {
            new frmComposition(idMenu, calMenuArr).Show();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog savepath = new SaveFileDialog();
            savepath.Filter = ".XLS|*.XLS|.XLSX|*.XLSX";

            if (savepath.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;

                // storing header part in Excel  
                for (int i = 1; i < gunaDataGridView2.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = gunaDataGridView2.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < gunaDataGridView2.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < gunaDataGridView2.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = gunaDataGridView2.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs(savepath.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            alert.Show("Xuất dữ liệu hoàn tất!", alert.AlertType.success);
        }
    }
}