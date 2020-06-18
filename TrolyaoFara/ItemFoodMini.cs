using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrolyaoFara
{
    public partial class ItemFoodMini : UserControl
    {
        LibFunction lib = new LibFunction();

        public ItemFoodMini(long idFood, string namefood)
        {
            InitializeComponent();

            lblName.Text = namefood;
            lib.getImgForFoodItem(idFood.ToString(), imgFood);
        }

        private static ItemFoodMini _instance;

        public static ItemFoodMini Add(long idFood, string namefood)
        {
            _instance = new ItemFoodMini(idFood, namefood);
            return _instance;
        }
    }
}
