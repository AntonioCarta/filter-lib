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
        Bitmap originalBmp;

        // Color filters
        Sepia sep = new Sepia();
        GrayScale gray = new GrayScale();
        Posterize poster = new Posterize();
        ColorFilter color = new ColorFilter();
        Median median = new Median();

        // Displacement filters
        SphereDistortion sphere = new SphereDistortion();
        Pixelate pixel = new Pixelate();

        // Convolution Filters
        SobelEdgeDetection sobel = new SobelEdgeDetection();
        Blur blur = new Blur();
        Emboss emboss = new Emboss();
        Sharpen sharp = new Sharpen();


        IFilter currentFilter = new Sepia();

        public Form1()
        {
            InitializeComponent();
            //DEBUG: automatically open img
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
                // Tutte le immagini devono avere il formato PixelFormat.Format32bppArgb
                if (originalBmp.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                {
                    bmp = new Bitmap(originalBmp.Width, originalBmp.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    using (var gr = Graphics.FromImage(bmp))
                        gr.DrawImage(originalBmp, new Rectangle(0, 0, originalBmp.Width, originalBmp.Height));
                    originalBmp = bmp;
                }
                
                mainPic.setImage(originalBmp);
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
            mainPic.setImage(originalBmp);
            mainPic.Invalidate();
            cancelBtn.Enabled = false;
        }

        private void applyFilter()
        {
            if (originalBmp == null) return;            
            //save current images
            oldOriginal = originalBmp;
            cancelBtn.Enabled = true;

            //apply filter
            if (mainPic.selecting())
                originalBmp = applyFilterToSelection();
            else
                originalBmp = currentFilter.Apply(originalBmp);
    
            mainPic.setImage(originalBmp);
            mainPic.Invalidate();
        }

        private Bitmap applyFilterToSelection()
        {
            Bitmap bmp;
            using (Bitmap sel = mainPic.getSelectedBitmap())
            {
                bmp = new Bitmap(originalBmp.Width, originalBmp.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(originalBmp, Point.Empty);                
                Bitmap filt = currentFilter.Apply(sel);
                g.DrawImage(filt, Point.Empty);           
            }
            return bmp;
        }

        private void btnCancelSelection_Click(object sender, EventArgs e)
        {
            mainPic.cancelSelection();
            mainPic.Invalidate();
        }

        private void tbRed_ValueChanged(object sender, EventArgs e)
        {
            TrackBar tb = ((TrackBar) sender);
            switch (tb.Name)
            {
                case "tbRed":
                    color.fr = tb.Value;
                    lblRed.Text = "Rosso: " + tb.Value;
                    lblRed.Invalidate();
                    break;
                case "tbGreen":
                    color.fg = tb.Value;
                    lblGreen.Text = "Verde : " + tb.Value;
                    lblGreen.Invalidate();
                    break;
                case "tbBlue":
                    color.fb = tb.Value;
                    lblBlue.Text = "Blu: " + tb.Value;
                    lblBlue.Invalidate();
                    break;
                case "tbPixelSize":
                    pixel.pixelSize = tb.Value;
                    lblPixelSize.Text = "Dim. Pixel: " + tb.Value;
                    lblPixelSize.Invalidate();
                    break;
                case "tbOffX":
                    sphere.centerOff.Width = tbOffX.Value;
                    lbloffX.Text = "Off X: " + tb.Value;
                    lbloffX.Invalidate();
                    break;
                case "tbOffY":
                    sphere.centerOff.Height = tb.Value;
                    lbloffY.Text = "Off Y: " + tb.Value;
                    lbloffY.Invalidate();
                    break;
            }
        }

        private void select_filter_click(object sender, MouseEventArgs e)
        {
            Button b = ((Button) sender);
            switch (b.Name) { 
                case "btnColor":
                    currentFilter = color;
                    break;
                case "btnSepia":
                    currentFilter = sep;
                    break;
                case "btnGray":
                    currentFilter = gray;
                    break;
                case "btnPosterize":
                    currentFilter = poster;
                    break;
                case "btnMedian":
                    currentFilter = median;
                    break;
                case "btnSphere":
                    currentFilter = sphere;
                    break;
                case "btnPixel":
                    currentFilter = pixel;
                    break;
                case "btnSobel":
                    currentFilter = sobel;
                    break;
                case "btnBlur":
                    currentFilter = blur;
                    break;
                case "btnEmboss":
                    currentFilter = emboss;
                    break;
                case "btnSharpen":
                    currentFilter = sharp;
                    break;
            }
            applyFilter();
        }

        Matrix createMatrix(Bitmap input) {
            float pbx = mainPic.Width;
            float pby = mainPic.Height;
            float imgx = input.Width;
            float imgy = input.Height;
            float pbratio = mainPic.Width / mainPic.Height;
            float imgratio = input.Width / input.Height;

            // Dimensione dell'immagine dopo lo zoom.
            float newx = pbx;
            float newy = pby;
            // Coordinate per la traslazione.
            float offx = 0, offy = 0;
            if (pbratio > imgratio)
            {
                newx = pby * imgratio;
                offx = - (pbx - newx) / 2;
            }
            else
            {
                newy = pbx / imgratio;
                offy = - (pby - newy) / 2;
            }
            Matrix m = new Matrix();
            m.Translate(offx, offy);
            float scale = Math.Max( imgx/pbx, imgy/pby );
            m.Scale(scale, scale);

            return m;
        }

        private void btnCloseSelection_Click(object sender, EventArgs e)
        {
            mainPic.closeRegion();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
