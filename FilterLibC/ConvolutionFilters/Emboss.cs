using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterLibC.ConvolutionFilters
{
    class Emboss : Convolution
    {
        static int[,] kernel = { 
            { -1, 0, -1 },
            { 0, 4, 0 },
            { -1, 0, -1 } 
        };
        static int factor = 1;
        static int offset = 127;
    
        public Emboss() : base(kernel, factor, offset) { }
    }
}
