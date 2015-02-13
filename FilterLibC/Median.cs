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
    public class Median : IFilter
    {
        int maxDistance = 2;

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

            //copy modified bytes in a new bitmap
            Bitmap output = new Bitmap(input.Width, input.Height, input.PixelFormat);
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
            int byteCount = bmpData.Stride * bmpData.Height;
            int heightInPixels = bmpData.Height;
            int widthInBytes = bmpData.Width * bytesPerPixel;

            byte[] outpixels = new byte[byteCount];
            int neighbourRow = maxDistance * 2 + 1;
            int maxDistInPixel = maxDistance * bytesPerPixel;
            int medianIndex = neighbourRow * neighbourRow / 2;
            int rowInPixel = neighbourRow * bytesPerPixel;
            int stride = bmpData.Stride;

            Parallel.For(maxDistance, heightInPixels - maxDistance, y =>
            {
                byte[] neighbour = new byte[neighbourRow * neighbourRow];
                int currentLine = y * bmpData.Stride;
                //for each byte in a row (border excluded)
                for (int x = maxDistInPixel; x < widthInBytes - maxDistInPixel; x++)
                {
                    int currentByte = currentLine + x;
                    //find neighbour                    
                    int i = 0;
                    int currentNeighbour = currentByte - (maxDistance * stride + maxDistance * bytesPerPixel);
                    for (int dy = 0; dy < neighbourRow; dy++)
                    {
                        for (int dx = 0; dx < neighbourRow; dx++)
                        {
                            neighbour[i] = pixels[currentNeighbour];
                            i++;
                            currentNeighbour += bytesPerPixel;
                        }
                        currentNeighbour += stride;
                        currentNeighbour -= rowInPixel;
                    }

                    Array.Sort(neighbour);
                    byte median = neighbour[medianIndex];

                    outpixels[currentByte] = median;
                }
            });

            return outpixels;
        }
    }
}
