using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace FilterLibC
{
    public interface IFilter
    {
        /// <summary>
        /// Applies the filter.
        /// The filter is guaranteed to work with the PixelFormat 32bppArgb and 24bppArgb.
        /// </summary>
        /// <param name="input">input image</param>
        /// <returns></returns>
        Bitmap Apply(Bitmap input);

        /// <summary>
        /// Applies the filter, but working directly on the pixels array.
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="bmpData"></param>
        void ApplyToArray(byte[] pixels, BitmapData bmpData);

        /// <summary>
        /// Applies the filter, reading from the pixels array and writing the result in a new byte[].
        /// pixels array is not modified.
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="bmpData"></param>
        /// <returns></returns>
        byte[] ApplyToNewArray(byte[] pixels, BitmapData bmpData);
    }
}
