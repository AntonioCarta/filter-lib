using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterLibC.ConvolutionFilters
{
    class Sharpen : Convolution
    {
        static int[,] kernel = {
            { 0, -2, 0 },
            { -2, 11, -2 },
            { 0, -2, 0 }
        };

        public Sharpen() : base(kernel, 3, 0) { }

    }
}
