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
    public class SobelEdgeDetection : IFilter
    {
        static int[,] gy = {
            { -1, -2, -1 },
            { 0, 0, 0 },
            { 1, 2, 1 }
        };
        static int[,] gx = {
            { -1, 0, 1 },
            { -2, 0, 2 },
            { -1, 0, 1 }
        };

        public Bitmap Apply(Bitmap input) {
            //lock the bit
            BitmapData bmpData = input.LockBits(new Rectangle(0, 0, input.Width, input.Height),
                                                    ImageLockMode.ReadOnly, input.PixelFormat);

            //NOTE: stride may include padding byte at the end
            int byteCount = bmpData.Stride * input.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bmpData.Scan0;
            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);
            input.UnlockBits(bmpData);

            byte[] outpixels = ApplyToNewArray(pixels, bmpData);

            // copy modified bytes in a new bitmap
            Bitmap output = new Bitmap(input.Width, input.Height);
            BitmapData outData = output.LockBits(new Rectangle(0, 0, input.Width, input.Height),
                                                    ImageLockMode.WriteOnly, input.PixelFormat);
            Marshal.Copy(outpixels, 0, outData.Scan0, outData.Stride * outData.Height);
            output.UnlockBits(outData);

            return output;
        }

        public void ApplyToArray(byte[] pixels, BitmapData bmpData)
        {
            byte[] output = ApplyToNewArray(pixels, bmpData);
            Array.Copy(output, pixels, output.Length);        
        }

        public byte[] ApplyToNewArray(byte[] pixels, BitmapData bmpData)
        {
            int bytesPerPixel = Bitmap.GetPixelFormatSize(bmpData.PixelFormat) / 8;
            int heightInPixels = bmpData.Height;
            int widthInBytes = bmpData.Width * bytesPerPixel;            
            int delta = 1;
            int size = 3;
            int deltaInBytes = delta * bytesPerPixel;
            int byteCount = bmpData.Stride * bmpData.Height;
            
            byte[] outpixels = new byte[byteCount];
            
            //border pixel ignored
            Parallel.For(delta, heightInPixels - delta, y =>
            {
                int currentLine = y * bmpData.Stride;
                for (int x = deltaInBytes; x < widthInBytes - deltaInBytes; x++)
                {
                    //ignore alpha channel in 32bppArgb
                    if (bmpData.PixelFormat != PixelFormat.Format32bppArgb || x % 4 != 3)
                    {
                        int resx = 0;
                        int resy = 0;
                        for (int i = 0; i < size; i++)
                        {
                            for (int j = 0; j < size; j++)
                            {
                                resx += gx[j, i] * pixels[currentLine + x + (i - delta) * bmpData.Stride + (j - delta) * bytesPerPixel];
                                resy += gy[j, i] * pixels[currentLine + x + (i - delta) * bmpData.Stride + (j - delta) * bytesPerPixel];
                            }
                        }
                        int res = (int)Math.Sqrt(resx * resx + resy * resy);
                        outpixels[currentLine + x] = (byte)res;
                    }
                    else { //alpha channel 
                        outpixels[currentLine + x] = pixels[currentLine + x];
                    }
                }
            });

            return outpixels;
        }
    }
}
