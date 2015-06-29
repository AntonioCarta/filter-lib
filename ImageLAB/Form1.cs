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
using FilterLibC.ConvolutionFilters;

namespace ImageLAB
{
    public partial class Form1 : Form
    {
        Bitmap oldOriginal;
        Bitmap oldPreview;

        Bitmap originalBmp;
        Bitmap previewBmp;

        //filters
        Sepia sep = new Sepia();
        GrayScale gray = new GrayScale();
        Posterize poster = new Posterize();
        ColorFilter color = new ColorFilter();
        Median median = new Median();

        SphereDistortion sphere = new SphereDistortion();
        Pixelate pixel = new Pixelate();

        SobelEdgeDetection sobel = new SobelEdgeDetection();
        Blur blur = new Blur();
        Emboss emboss = new Emboss();
        Sharpen sharp = new Sharpen();
        IFilter currentFilter = new Sepia();

        public Form1()
        {
            InitializeComponent();

            //DEBUG: automatically open diablo img
            // C:\Users\Antonio\Pictures
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
                float ar1 = originalBmp.Height / (float) originalBmp.Width;
                float ar2 = previewPic.Height / (float) previewPic.Width;

                //preview pic
                if (ar1 > ar2)                
                    previewBmp = resizeImage(originalBmp, (int) ((1/ar1)*previewPic.Height), previewPic.Height);
                else
                    previewBmp = resizeImage(originalBmp, previewPic.Width, (int) (ar1*previewPic.Width));

                oldPreview = previewBmp;

                previewPic.Image = previewBmp;
                previewPic.Invalidate();

                mainPic.Image = originalBmp;
                mainPic.Invalidate();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK) {
                originalBmp.Save( sfd.FileName );
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            originalBmp = oldOriginal;
            previewBmp = oldPreview;
            mainPic.Image = originalBmp;
            previewPic.Image = previewBmp;
            mainPic.Invalidate();
            previewPic.Invalidate();
            cancelBtn.Enabled = false;
        }

        private void applyFilter()
        {
            if (originalBmp == null) return;

            //save current images
            oldOriginal = originalBmp;
            oldPreview = previewBmp;
            cancelBtn.Enabled = true;

            //apply filter
            originalBmp = currentFilter.Apply(originalBmp);
            previewBmp = currentFilter.Apply(previewBmp);

            mainPic.Image = originalBmp;
            previewPic.Image = previewBmp;
            mainPic.Invalidate();
            previewPic.Invalidate();
            
        }

        private void drawPreview() {
            if (previewBmp == null) return;


            previewBmp = currentFilter.Apply(oldPreview);
            previewPic.Image = previewBmp;
            previewPic.Invalidate();
        }

        private void filterBtn_MouseClick(object sender, EventArgs e)
        {
            switch( ((Button)sender).Name )
            {
                case "sepBtn":
                    currentFilter = sep;
                    break;
                case "grayBtn":
                    currentFilter = gray;
                    break;
                case "posterBtn":
                    currentFilter = poster;
                    break;
                case "colorBtn":
                    currentFilter = color;
                    break;
                case "sphereBtn":
                    currentFilter = sphere;
                    break;
                case "medianBtn":
                    currentFilter = median;
                    break;
                case "pixelBtn":
                    currentFilter = pixel;
                    break;
                case "sobelBtn":
                    currentFilter = sobel;
                    break;
                case "blurBtn":
                    currentFilter = blur;
                    break;
                case "embossBtn":
                    currentFilter = emboss;
                    break;
                case "sharpBtn":
                    currentFilter = sharp;
                    break;
            }
            applyFilter();
        }

        private void previewControlActivated(object sender, EventArgs e)
        {
            switch (((Control)sender).Name) {
                case "sepBtn":
                    currentFilter = sep;
                    break;
                case "grayBtn":
                    currentFilter = gray;
                    break;   
                case "posterBtn":
                    currentFilter = poster;
                    break;
                case "redBar":
                    currentFilter = color;
                    color.fr = ((TrackBar)sender).Value;
                    break;
                case "blueBar":
                    currentFilter = color;
                    color.fb = ((TrackBar)sender).Value;
                    break;
                case "greenBar":
                    currentFilter = color;
                    color.fg = ((TrackBar)sender).Value;
                    break;
                case "sphereBtn":
                    currentFilter = sphere;
                    break;
                case "medianBtn":
                    currentFilter = median;
                    break;
                case "pixelBtn":
                    currentFilter = pixel;
                    break;
                case "pixelBar":
                    pixel.pixelSize = ((TrackBar)sender).Value;
                    currentFilter = pixel;
                    break;
                case "sobelBtn":
                    currentFilter = sobel;
                    break;
                case "blurBtn":
                    currentFilter = blur;
                    break;
                case "embossBtn":
                    currentFilter = emboss;
                    break;
                case "sharpBtn":
                    currentFilter = sharp;
                    break;
            }
            drawPreview();
        }

    }
}
