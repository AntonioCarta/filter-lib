using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterLibC
{
    public class GrayScale : PixelFilter
    {
        protected override void processPixel(byte[] pixels, int index, int nbytesPerPixel)
        {
            int oldBlue = pixels[index];
            int oldGreen = pixels[index + 1];
            int oldRed = pixels[index + 2];

            // calculate new pixel value
            int gray = (byte) ( .299 * oldRed + .587 * oldGreen + .114 * oldBlue );

            //write new value
            pixels[index] = (byte)gray;
            pixels[index + 1] = (byte)gray;
            pixels[index + 2] = (byte)gray;
        }

    }
}
