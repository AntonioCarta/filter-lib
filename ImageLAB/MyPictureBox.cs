using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ImageLAB
{
    public partial class MyPictureBox : UserControl
    {
        private GraphicsPath myPath; // Il percorso che racchiude la regione.
        Point lastPoint = Point.Empty; // Ultimo punto di myPath.
        bool selectingRegion = false; // Tasto del mouse premuto. è in corso una selezione. 

        private Bitmap myImage;
        // L'immagine myImage viene scalata. Queste sono le sue dimensioni sulla vista.
        private Size viewImageSize = Size.Empty;
        Pen myPen = new Pen(Color.Black);

        public MyPictureBox()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (myImage == null)
                base.OnPaintBackground(e);
            // Non facciamo niente.
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            
            GraphicsState oldState = g.Save();
            if (myImage != null)
            {
                float scaleFactor = (float)this.Width / (float)myImage.Width;
                g.ScaleTransform(scaleFactor, scaleFactor, MatrixOrder.Append);

                g.DrawImage(myImage, Point.Empty);
            }            
            g.Restore(oldState);

            //Disegno il GraphicsPath
            if (myPath != null)
            {
                g.DrawPath(myPen, myPath);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (myImage != null)
                viewImageSize = fitImageToBoundingBox(myImage.Size, this.Size);
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (myPath == null)
                myPath = new GraphicsPath();
            else
                myPath.AddLine(lastPoint.X, lastPoint.Y, e.X, e.Y);

            lastPoint.X = e.X;
            lastPoint.Y = e.Y;
            this.Invalidate();
            selectingRegion = true;
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            if (myPath != null) myPath.CloseFigure();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            selectingRegion = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (selectingRegion)
            {
                myPath.AddLine(lastPoint.X, lastPoint.Y, e.X, e.Y);
                lastPoint.X = e.X;
                lastPoint.Y = e.Y;
                this.Invalidate();
            }
        }

        public void closeRegion()
        {
            myPath.CloseFigure();
        }

        public void cancelSelection()
        {
            if (myPath != null)
            {
                myPath.Dispose();
                myPath = null;
            }
        }

        public void setImage(Bitmap newImage)
        {
            myImage = newImage;
            viewImageSize = fitImageToBoundingBox(newImage.Size, this.Size);            
        }

        public Bitmap getSelectedBitmap()
        {
            GraphicsPath newPath = (GraphicsPath)myPath.Clone();
            Matrix m = new Matrix();
            float scaleFactor = (float)myImage.Width / (float)this.Width;
            m.Scale(scaleFactor, scaleFactor);
            newPath.Transform(m);
            Region reg = new Region(newPath);

            Bitmap bmp = new Bitmap(myImage.Width, myImage.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.SetClip(reg, CombineMode.Intersect);
            g.DrawImage(myImage, Point.Empty);

            newPath.Dispose();
            m.Dispose();
            reg.Dispose();
            return bmp;

        }

        public bool selecting()
        {
            return myPath != null;
        }

        private static Size fitImageToBoundingBox(Size image, Size boundingBox)
        {
            float widthScale = 0, heightScale = 0;

            widthScale = (float)boundingBox.Width / (float)image.Width;
            heightScale = (float)boundingBox.Height / (float)image.Height;

            double scale = Math.Min(widthScale, heightScale);

            Size result = new Size((int)(image.Width * scale),
                                (int)(image.Height * scale));
            return result;
        }
    }
}
