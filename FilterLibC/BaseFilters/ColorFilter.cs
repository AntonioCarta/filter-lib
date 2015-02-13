using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace FilterLibC
{
    public class ColorFilter : PixelFilter
    {
        public int fr = 0, fg = 0, fb = 0;

        protected override void processPixel(byte[] pixels, int index, int nbytesPerPixel)
        {
            int oldBlue = pixels[index];
            int oldGreen = pixels[index + 1];
            int oldRed = pixels[index + 2];

            // calculate new pixel value
            int b = oldBlue + fb;
            int g = oldGreen + fg;
            int r = oldRed + fr;

            b = System.Math.Max(0, System.Math.Min(255, b));
            g = System.Math.Max(0, System.Math.Min(255, g));
            r = System.Math.Max(0, System.Math.Min(255, r));

            //write new value
            pixels[index] = (byte)b;
            pixels[index + 1] = (byte)g;
            pixels[index + 2] = (byte)r;
        }
    }
}
