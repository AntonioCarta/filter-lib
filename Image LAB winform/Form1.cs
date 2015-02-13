using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilterLibC;

namespace Image_LAB_winform
{
    public partial class Form1 : Form
    {
        Bitmap oldBmp;
        Bitmap newBmp;
        ColorFilter cf = new ColorFilter();
        GrayScale gray = new GrayScale();
        Posterize post = new Posterize();
        SobelEdgeDetection sobel = new SobelEdgeDetection();
        Pixelate pix = new Pixelate();
        SphereDistortion sphere = new SphereDistortion();
        Median median = new Median();

        static int[,] kernel = {
                { -1, 0, -1 },
                { 0, 4, 0 },
                { -1, 0, -1 }
            };

        static int[,] gaussianKernel = {
                { 1, 2, 1 },
                { 2, 4, 2 },
                { 1, 2, 1 }                        
            };

        static int[,] bigKernel = {
                { 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1 }
            };

        Convolution cv = new Convolution(kernel, 1, 127);
        Convolution blur = new Convolution(gaussianKernel, 16, 0);
        Convolution big = new Convolution(bigKernel, 49, 0);
        Sepia sep = new Sepia();

        public Form1()
        {
            InitializeComponent();
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) {
                oldBmp = new Bitmap(ofd.FileName);
                pictureBox1.Image = oldBmp;
                pictureBox1.Invalidate();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK) {
                oldBmp.Save(sfd.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            oldBmp = median.Apply(oldBmp); 
            sw.Stop();
            label1.Text = sw.Elapsed.ToString();
            
            pictureBox1.Image = oldBmp;
            pictureBox1.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            cf.fr = trackBar1.Value;
            cf.fg = trackBar2.Value;
            cf.fb = trackBar3.Value;

            newBmp = cf.Apply(oldBmp);
            pictureBox1.Image = newBmp;
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            newBmp = sobel.Apply(oldBmp);
            sw.Stop();
            label1.Text = sw.Elapsed.ToString();
            pictureBox1.Image = newBmp;
            pictureBox1.Invalidate();
            pictureBox1.Invalidate();
            //MessageBox.Show(oldBmp.Width + " x " + oldBmp.Height);
            //for (int y = 0; y < 500; y += 100)
            //    for (int x = 0; x < 500; x += 100)
            //    {
            //        gray.Apply(oldBmp);
            //        pictureBox1.Image = oldBmp;
            //        pictureBox1.Invalidate();
            //    }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            post.LevelNumber = 5;
            oldBmp = sphere.Apply(oldBmp);
            sw.Stop();
            label1.Text = sw.Elapsed.ToString();
            pictureBox1.Image = oldBmp;
            pictureBox1.Invalidate();
            pictureBox1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //oldBmp = new Bitmap(@"C:\Users\Antonio\Pictures\Diablo.jpg");
            oldBmp = new Bitmap(pictureBox1.Image);
            pix.pixelSize = 20;
        }
    }
}
