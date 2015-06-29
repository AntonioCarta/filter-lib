using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterLibC.ConvolutionFilters
{
    public class Blur : Convolution
    {
        static int[,] kernel ={
                { 1, 2, 1 },
                { 2, 4, 2 },
                { 1, 2, 1 } 
        };

        public Blur() : base(kernel, 16, 0) { 
        }
    }
}
