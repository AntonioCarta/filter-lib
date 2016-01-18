using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace FilterLibC
{
    public abstract class PixelFilter : IFilter
    {
        /// <summary>
        /// Calcola il valore di un singolo pixel.
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="index"></param>
        /// <param name="nbytesPerPixel"></param>
        protected abstract void processPixel(byte[] pixels, int index, int nbytesPerPixel);


        public Bitmap Apply(Bitmap input) 
        {
            //lock the bit
            BitmapData bmpData = input.LockBits(new Rectangle(0, 0, input.Width, input.Height),
                                                    ImageLockMode.ReadOnly, input.PixelFormat);

            int bytesPerPixel = Bitmap.GetPixelFormatSize(input.PixelFormat) / 8;
            int byteCount = bmpData.Stride * input.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bmpData.Scan0;
            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);
            input.UnlockBits(bmpData);

            ApplyToArray(pixels, bmpData);

            // Copia i byte in una nuova bitmap.
            Bitmap output = new Bitmap(input.Width, input.Height, input.PixelFormat);
            BitmapData outData = output.LockBits(new Rectangle(0, 0, input.Width, input.Height),
                                                    ImageLockMode.WriteOnly, input.PixelFormat);
            Marshal.Copy(pixels, 0, outData.Scan0, outData.Stride * outData.Height);
            output.UnlockBits(outData);

            return output;
        }

        public void ApplyToArray(byte[] pixels, BitmapData bmpData)
        {
            int bytesPerPixel = Bitmap.GetPixelFormatSize(bmpData.PixelFormat) / 8;
            int heightInPixels = bmpData.Height;
            int widthInBytes = bmpData.Width * bytesPerPixel;

            Parallel.For(0, heightInPixels, y =>
            {
                int currentLine = y * bmpData.Stride;
                for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                {
                    processPixel(pixels, currentLine + x, bytesPerPixel);
                }
            });
        }

        public byte[] ApplyToNewArray(byte[] pixels, BitmapData bmpData)
        {
            byte[] output = new byte[bmpData.Stride * bmpData.Height];
            Array.Copy(pixels, output, pixels.Length);

            ApplyToArray(output, bmpData);

            return output;
        }
    }


}
