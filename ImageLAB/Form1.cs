using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using FilterLibC;

namespace ImageLAB
{
    public partial class Form1 : Form
    {
        Bitmap originalBmp;
        Bitmap resizedBmp;
        Bitmap previewBmp;

        //filters
        Sepia sep = new Sepia();

        public Form1()
        {
            InitializeComponent();
        }

        public static Bitmap resizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp;
                originalBmp = new Bitmap(ofd.FileName);
                //we must convert to a supported format
                if (originalBmp.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppArgb && originalBmp.PixelFormat != System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                {
                    bmp = new Bitmap(originalBmp.Width, originalBmp.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    using (var gr = Graphics.FromImage(bmp))
                        gr.DrawImage(originalBmp, new Rectangle(0, 0, originalBmp.Width, originalBmp.Height));
                    originalBmp = bmp;
                }

                //resize the image for an efficient preview fo the filters effect
                //BUG: this doesn't respect aspect ratio.
                previewBmp = resizeImage(originalBmp, previewPic.Width, previewPic.Height);
                resizedBmp = resizeImage(originalBmp, mainPic.Width, mainPic.Height);

                previewPic.Image = previewBmp;
                previewPic.Invalidate();
                mainPic.Image = resizedBmp;
                mainPic.Invalidate();
            }
        }

        private void applyFilter(IFilter filter)
        {
            originalBmp = filter.Apply(originalBmp);
            previewBmp = filter.Apply(previewBmp);
            resizedBmp = filter.Apply(resizedBmp);

            mainPic.Image = resizedBmp;
            previewPic.Image = previewBmp;
            mainPic.Invalidate();
            previewPic.Invalidate();
        }

        private void filterBtn_MouseClick(object sender, EventArgs e)
        {
            if (((Button)sender).Name == "sepBtn")
                applyFilter(sep);
        }
    }
}
