﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace FilterLibC
{
    public class Convolution : IFilter
    {
        int[,] kernel;
        int size;
        int delta;
        int factor;
        int offset;

        public Convolution() { 
            int[,] k = { {1} };
            this.kernel = k;            
            this.offset = 0;
            this.size = 1;
            this.factor = 1;
            this.delta = 0;
        }

        /// <summary>
        /// Inizializza il filtro con il kernel dato.
        /// </summary>
        /// <param name="kernel">Array rappresentante il kernel.</param>
        /// <param name="factor"></param>
        /// <param name="offset"></param>
        public Convolution( int[,] kernel, int factor, int offset ) {
            this.kernel = kernel;
            this.offset = offset;
            this.size = kernel.GetLength(0);
            this.factor = factor;
            this.delta = size / 2;
        }


        public Bitmap Apply(Bitmap input)       
        {          
            // Lock sui bit della Bitmap.
            BitmapData bmpData = input.LockBits(new Rectangle(0, 0, input.Width, input.Height),
                                                    ImageLockMode.ReadOnly, input.PixelFormat);

            int byteCount = bmpData.Stride * input.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bmpData.Scan0;
            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);
            input.UnlockBits(bmpData);

            byte[] outpixels = ApplyToNewArray(pixels, bmpData);
            
            // Copia i pixel in una nuova Bitmap.
            Bitmap output = new Bitmap(input.Width, input.Height);
            BitmapData outData = output.LockBits(new Rectangle(0, 0, input.Width, input.Height),
                                                    ImageLockMode.WriteOnly, input.PixelFormat);
            Marshal.Copy(outpixels, 0, outData.Scan0, outData.Stride * outData.Height);
            output.UnlockBits(outData);

            return output;
        }

        public void ApplyToArray(byte[] pixels, BitmapData bmpData) {
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

            int delta = size / 2;
            int deltaInBytes = delta * bytesPerPixel;
            // !!! Bordi esclusi !!!
            Parallel.For(delta, heightInPixels - delta, y =>
            {
                int currentLine = y * bmpData.Stride;                
                for (int x = deltaInBytes; x < widthInBytes - deltaInBytes; x++)
                {
                    // Voglio ignorare l'alpha.
                    if (bytesPerPixel == 4 && (x % 4) == 3)
                    {
                        outpixels[currentLine + x] = pixels[currentLine + x];
                        continue;
                    }
                    
                    int res = 0;
                    // Convoluzione.
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            res += kernel[j, i] * pixels[currentLine + x + (i - delta) * bmpData.Stride + (j - delta) * bytesPerPixel];
                        }
                    }
                    res = res / factor;
                    res -= offset;
                    outpixels[currentLine + x] = (byte)res;
                }
            });

            return outpixels;
        }
    }

}
