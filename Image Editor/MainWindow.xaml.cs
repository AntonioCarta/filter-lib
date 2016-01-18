using FilterLibC;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Image_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bitmap oldOriginal;
        Bitmap originalBmp;

        System.Windows.Controls.Image mainPic;

        IFilter currentFilter = new Sepia();

        public MainWindow()
        {
            InitializeComponent();
            mainPic = (System.Windows.Controls.Image)this.FindName("imageView");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name) { 
                case "btnOpen":
                    openImage();
                    break;
                case "btnSave":
                    saveImage();
                    break;
                case "btnCancel":
                    cancelLastOperation();
                    break;
            }
        }

        private void cancelLastOperation()
        {            
            originalBmp = oldOriginal;
            mainPic.Source = originalBmp;
            cancelBtn.Enabled = false;
        }

        private void saveImage()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                originalBmp.Save(sfd.FileName);
            }
        }

        /* Permette all'utente di selezionare un'immagine da aprire e se necessario la converte in un formato appropriato. */
        private void openImage()
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
                float ar1 = originalBmp.Height / (float)originalBmp.Width;
                float ar2 = previewPic.Height / (float)previewPic.Width;

                //preview pic
                if (ar1 > ar2)
                    previewBmp = resizeImage(originalBmp, (int)((1 / ar1) * previewPic.Height), previewPic.Height);
                else
                    previewBmp = resizeImage(originalBmp, previewPic.Width, (int)(ar1 * previewPic.Width));

                oldPreview = previewBmp;

                previewPic.Image = previewBmp;
                previewPic.Invalidate();

                mainPic.Image = originalBmp;
                mainPic.Invalidate();
            }
        }

        public Bitmap selectBitmap(Bitmap input, Region reg)
        {
            Graphics g = Graphics.FromImage(input);
            g.SetClip(reg, CombineMode.Intersect);

            Bitmap bmp = new Bitmap(input.Width, input.Height, g);
            input.Dispose();
            return bmp;
        }

        private void applyFilter()
        {
            if (originalBmp == null) return;

            //save current images
            oldOriginal = originalBmp;
            cancelBtn.Enabled = true;

            //apply filter
            originalBmp = currentFilter.Apply(originalBmp);

            mainPic.Image = originalBmp;
            mainPic.Invalidate();
        }
    }
}
