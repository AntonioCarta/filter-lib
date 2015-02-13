namespace FilterLibF

open System.Drawing
open System.Drawing.Imaging
open System.Runtime.InteropServices

type ColorFilter() = 
  let r,g,b = 0,0,0 // values between 0 and 255
     
  let filter(r,g,b) = (r,g,b) 

  member this.ApplyFilter(processedBitmap : Bitmap) =
      //lock the bit
      let bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), 
                                                ImageLockMode.ReadWrite, processedBitmap.PixelFormat)

      let bytesPerPixel = Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8
      //NOTE: stride may include padding byte at the end
      let byteCount = bitmapData.Stride * processedBitmap.Height
      let pixels : byte[] = Array.zeroCreate byteCount
      let ptrFirstPixel = bitmapData.Scan0
      Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length)
      let heightInPixels = bitmapData.Height
      let widthInBytes = bitmapData.Width * bytesPerPixel
   
      for y in 0 .. (heightInPixels-1) do
          let currentLine = y * bitmapData.Stride
          for x in 0 .. bytesPerPixel .. (widthInBytes-1) do
              let oldBlue = pixels.[currentLine + x]
              let oldGreen = pixels.[currentLine + x + 1]
              let oldRed = pixels.[currentLine + x + 2]

              let b,g,r = filter(oldBlue, oldGreen, oldRed)

              // calculate new pixel value
              pixels.[currentLine + x] <- (byte)b
              pixels.[currentLine + x + 1] <- (byte)g
              pixels.[currentLine + x + 2] <- (byte)r
        
      // copy modified bytes back
      Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
      processedBitmap.UnlockBits(bitmapData);