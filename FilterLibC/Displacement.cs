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
    public abstract class Displacement : IFilter
    {
        protected abstract Point calculateOffset(int x, int y, int width, int height);

        public Bitmap Apply(Bitmap input)
        {
            //lock the bit
            BitmapData bmpData = input.LockBits(new Rectangle(0, 0, input.Width, input.Height),
                                                    ImageLockMode.ReadOnly, input.PixelFormat);

            int bytesPerPixel = Bitmap.GetPixelFormatSize(input.PixelFormat) / 8;
            //NOTE: stride may include padding byte at the end
            int byteCount = bmpData.Stride * input.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bmpData.Scan0;
            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);
            input.UnlockBits(bmpData);

            byte[] outPixels = ApplyToNewArray(pixels, bmpData);

            // copy modified bytes in a new bitmap
            Bitmap output = new Bitmap(input.Width, input.Height, input.PixelFormat);
            BitmapData outData = output.LockBits(new Rectangle(0, 0, input.Width, input.Height),
                                                    ImageLockMode.WriteOnly, input.PixelFormat);
            Marshal.Copy(outPixels, 0, outData.Scan0, outData.Stride * outData.Height);
            output.UnlockBits(outData);

            return output;
        }

        public void ApplyToArray(byte[] pixels, BitmapData bmpData)
        { 
        
        }

        public byte[] ApplyToNewArray(byte[] pixels, BitmapData bmpData)
        {
            int bytesPerPixel = Bitmap.GetPixelFormatSize(bmpData.PixelFormat) / 8;
            //NOTE: stride may include padding byte at the end
            int byteCount = bmpData.Stride * bmpData.Height;            
            int heightInPixels = bmpData.Height;
            int widthInBytes = bmpData.Width * bytesPerPixel;
            
            byte[] outPixels = new byte[byteCount];

            Point[,] offset = new Point[bmpData.Height, bmpData.Width];
            int width = bmpData.Width;
            int height = bmpData.Height;

            //calculate offset for every pixel
            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    offset[y, x] = calculateOffset(x, y, width, height);
                }
            });

            //now we replace the pixels
            Parallel.For(0, height, y =>
            {
                int currentLine = y * bmpData.Stride;
                for (int x = 0; x < width; x++)
                {
                    int currentPixel = currentLine + x * bytesPerPixel;
                    int yOff = offset[y, x].Y;
                    int xOff = offset[y, x].X;


                    //check for out of bound pixels
                    if (xOff < 0)
                        xOff = 0;
                    else if (xOff >= width)
                        xOff = width - 1;
                    if (yOff < 0)
                        yOff = 0;
                    else if (yOff >= height)
                        yOff = height - 1;

                    outPixels[currentPixel] = pixels[yOff * bmpData.Stride + xOff * bytesPerPixel];
                    outPixels[currentPixel + 1] = pixels[yOff * bmpData.Stride + xOff * bytesPerPixel + 1];
                    outPixels[currentPixel + 2] = pixels[yOff * bmpData.Stride + xOff * bytesPerPixel + 2];
                    if(bmpData.PixelFormat == PixelFormat.Format32bppArgb)
                        outPixels[currentPixel + 3] = pixels[yOff * bmpData.Stride + xOff * bytesPerPixel + 3];
                }
            });

            return outPixels;
        }
    }
}
