using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrolyaoFara
{
    class ExportMenuToImage
    {
        public string filename = null;
        public List<Image> imglist = new List<Image>();
        LibFunction lib = new LibFunction();

        private Size getResolution(List<Image> images)
        {
            int w = 0;
            int h = 0;
            foreach (Image item in imglist)
            {
                w += item.Width;
                h += item.Height;
            }
            return new Size(w, h);
        }

        private int getMax(List<Image> images)
        {
            int max = 0;
            int i = 0;
            max = images[0].Width;
            if (images.Count > 1)
            {
                foreach (Image item in images)
                {
                    if (images[i].Width > max)
                        max = images[i].Width;
                    i += 1;
                }
            }
            return max;
        }

        private void loadimage()
        {
            try
            {
                imglist.Clear();
            }
            catch { }

            string localstr = lib.getPathDataInPCUser(@"\.faraVN\Data\img\");
            imglist.Add(new Bitmap(localstr + "title.png"));
            imglist.Add(new Bitmap(localstr + "breakfast.png"));
            imglist.Add(new Bitmap(localstr + "lunch.png"));
            imglist.Add(new Bitmap(localstr + "dinner.png"));
        }
      
        public void ExportToImage()
        {
            loadimage();

            SaveFileDialog savepath = new SaveFileDialog();
            savepath.Filter = ".JPG|*.JPG|.PNG|*.PNG";

            if (savepath.ShowDialog() == DialogResult.OK)
            {
                Size maxres = getResolution(imglist);
                int resW = maxres.Width;
                int resH = maxres.Height;
                int maxW = getMax(imglist);
                Bitmap bmp;
                bmp = new Bitmap(maxW, resH, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                Graphics g = Graphics.FromImage(bmp);
                int w = imglist[0].Width + 1;
                int h = imglist[0].Height + 1;

                if (imglist.Count > 1)
                {
                    g.DrawImage(imglist[0], 0, 0, imglist[0].Width, imglist[0].Height);
                    for (int i = 1; i <= imglist.Count - 1; i++)
                    {
                        g.DrawImage(imglist[i], 0, h, imglist[i].Width, imglist[i].Height);
                        h += imglist[i].Height;
                    }
                    bmp.Save(savepath.FileName);
                }
                g.Dispose();
                bmp.Dispose();
            }
        }
    }
}
