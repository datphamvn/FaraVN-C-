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
        public ItemFoodMini(string namefood)
        {
            InitializeComponent();

            lblName.Text = namefood;
        }

        private static ItemFoodMini _instance;

        public static ItemFoodMini Add(string namefood)
        {
            _instance = new ItemFoodMini(namefood);
            return _instance;
        }
    }
}
