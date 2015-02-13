using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterLibC
{
    public class Posterize : PixelFilter
    {
        int[] levels = new int[256];

        public int LevelNumber
        {
            get { return LevelNumber; }
            set { if (value > 0 && value <= 10) initialize(value); }
        }     

        void initialize(int numLevels) {
            for (int i = 0; i < 256; i++)
            {
                levels[i] = 255 * (i * numLevels / 255) / (numLevels - 1);
            }
        }
        public Posterize() {
            this.LevelNumber = 5;
        }

        public Posterize(int numLevels) {
            this.LevelNumber = numLevels;
        }

        protected override void processPixel(byte[] pixels, int index, int nbytesPerPixel)
        {
            int oldBlue = pixels[index];
            int oldGreen = pixels[index + 1];
            int oldRed = pixels[index + 2];

            // calculate new pixel value
            int b = levels[oldBlue];
            int g = levels[oldGreen];
            int r = levels[oldRed];

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
