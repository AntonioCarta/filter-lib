using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;

namespace FilterLibC
{
    public class Pixelate : IFilter
    {
        public int pixelSize = 20;
        int bytesPerPixel = 0;
            
        public Bitmap Apply(Bitmap input)
        {
            //lock the bit
            BitmapData bmpData = input.LockBits(new Rectangle(0, 0, input.Width, input.Height),
                                                    ImageLockMode.ReadOnly, input.PixelFormat);

            //NOTE: stride may include padding byte at the end
            int byteCount = bmpData.Stride * input.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bmpData.Scan0;
            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);
            input.UnlockBits(bmpData);

            ApplyToArray(pixels, bmpData);

            // copy modified bytes in a new bitmap
            Bitmap output = new Bitmap(input.Width, input.Height, input.PixelFormat);
            BitmapData outData = output.LockBits(new Rectangle(0, 0, input.Width, input.Height),
                                                    ImageLockMode.WriteOnly, input.PixelFormat);
            Marshal.Copy(pixels, 0, outData.Scan0, byteCount);
            output.UnlockBits(outData);

            return output;
        }

        public void ApplyToArray(byte[] pixels, BitmapData bmpData)
        {
            bytesPerPixel = Bitmap.GetPixelFormatSize(bmpData.PixelFormat) / 8;
            int heightInPixels = bmpData.Height;
            int widthInBytes = bmpData.Width * bytesPerPixel;
            int sizex = bmpData.Width / pixelSize + 1;
            int sizey = bmpData.Height / pixelSize + 1;
            int pixelArea = pixelSize * pixelSize;
            int[,] pixelRed = new int[sizey, sizex];
            int[,] pixelGreen = new int[sizey, sizex];
            int[,] pixelBlue = new int[sizey, sizex];

            for (int i = 0; i < sizey; i++)
            {
                for (int j = 0; j < sizex; j++)
                {
                    pixelBlue[i, j] = 0;
                    pixelRed[i, j] = 0;
                    pixelGreen[i, j] = 0;
                }
            }

            //phase 1: calculate each pixel value
            for (int y = 0; y < heightInPixels; y++)
            {
                int currentLine = y * bmpData.Stride;
                for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                {
                    int px = x / (bytesPerPixel * pixelSize);
                    int py = y / pixelSize;
                    int curr = currentLine + x;
                    pixelBlue[py, px] += pixels[curr];
                    pixelGreen[py, px] += pixels[curr + 1];
                    pixelRed[py, px] += pixels[curr + 2];
                }
            }
            for (int i = 0; i < sizey; i++)
            {
                for (int j = 0; j < sizex; j++)
                {
                    pixelBlue[i, j] /= pixelArea;
                    pixelRed[i, j] /= pixelArea;
                    pixelGreen[i, j] /= pixelArea;
                }
            }

            //phase 2: paint the pixels
            for (int y = 0; y < heightInPixels; y++)
            {
                int currentLine = y * bmpData.Stride;
                for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                {
                    int curr = currentLine + x;
                    int px = x / (bytesPerPixel * pixelSize);
                    int py = y / pixelSize;
                    pixels[curr] = (byte)pixelBlue[py, px];
                    pixels[curr + 1] = (byte)pixelGreen[py, px];
                    pixels[curr + 2] = (byte)pixelRed[py, px];
                }
            }
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
