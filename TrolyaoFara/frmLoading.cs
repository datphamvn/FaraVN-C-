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
    public partial class frmLoading : Form
    {
        public frmLoading(string _mes)
        {
            InitializeComponent();

            lblContent.Text = _mes;
        }

        public static void Show(string _mes)
        {
            new TrolyaoFara.frmLoading(_mes).Show();
        }
    }
}
