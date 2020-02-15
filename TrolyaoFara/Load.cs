﻿using System;
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
    public partial class Load : UserControl
    {
        List<Color> colors = new List<Color>();
        int cur_color = 0;

        public Load()
        {
            InitializeComponent();

            colors.Add(Color.FromArgb(0, 150, 136));
            colors.Add(Color.FromArgb(0, 188, 212));
            colors.Add(Color.FromArgb(63, 81, 181));
            colors.Add(Color.FromArgb(156, 39, 176));

            bunifuCircleProgressbar1.ProgressColor = colors[cur_color];
        }

        int dir = 1;
        private void stretch_Tick(object sender, EventArgs e)
        {
            if(bunifuCircleProgressbar1.Value == 90)
            {
                dir = -1;
                bunifuCircleProgressbar1.animationSpeed = 4;
                SwictColor();
            }
            else if(bunifuCircleProgressbar1.Value == 10)
            {
                dir = +1;
                bunifuCircleProgressbar1.animationSpeed = 2;
                SwictColor();
            }
            bunifuCircleProgressbar1.Value += dir;

        }

        void SwictColor()
        {
            bunifuColorTransition1.Color1 = colors[cur_color];
            if(cur_color < colors.Count - 1)
            {
                cur_color++;
            }
            else
            {
                cur_color = 0;
            }
            bunifuColorTransition1.Color1 = colors[cur_color];
            color_transtion.Start();
        }

        private void color_transtion_Tick(object sender, EventArgs e)
        {
            if(bunifuColorTransition1.ProgessValue < 100)
            {
                bunifuColorTransition1.ProgessValue++;
                bunifuCircleProgressbar1.ProgressColor = bunifuColorTransition1.Value;
            }
        }
    }
}
