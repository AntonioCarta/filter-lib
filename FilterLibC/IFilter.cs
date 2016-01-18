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
        /// Applica il filtro.
        /// Il funzionamento è garantito se PixelFormat è 32bppArgb o 24bppArgb.
        /// </summary>
        /// <param name="input">input image</param>
        /// <returns></returns>
        Bitmap Apply(Bitmap input);

        /// <summary>
        /// Applica il filtro in-place.
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="bmpData"></param>
        void ApplyToArray(byte[] pixels, BitmapData bmpData);

        /// <summary>
        /// Applica il filtro, restituendo il risultato in un nuovo byte[].
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="bmpData"></param>
        /// <returns></returns>
        byte[] ApplyToNewArray(byte[] pixels, BitmapData bmpData);
    }
}
