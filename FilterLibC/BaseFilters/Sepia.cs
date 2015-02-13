using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterLibC
{
    public class Sepia : PixelFilter
    {
        protected override void processPixel(byte[] pixels, int index, int nbytesPerPixel)
        {
            int oldBlue = pixels[index];
            int oldGreen = pixels[index + 1];
            int oldRed = pixels[index + 2];

            // calculate new pixel value
            int r = (int) (pixels[index] * 0.189f + pixels[index + 1] * 0.769f + pixels[index + 2] * 0.393f);
            int g = (int) (pixels[index] * 0.168f + pixels[index + 1] * 0.686f + pixels[index + 2] * 0.349f);
            int b = (int) (pixels[index] * 0.131f + pixels[index + 1] * 0.534f + pixels[index + 2] * 0.272f);

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
