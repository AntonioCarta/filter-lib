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
    public class SphereDistortion : Displacement
    {
        override protected Point calculateOffset(int x, int y, int width, int height)
        {
            Point center = new Point(width / 2, height / 2);
            Point dist = new Point(x - center.X, y - center.Y);
            double radius = Math.Sqrt(dist.X * dist.X + dist.Y * dist.Y);
            double theta = Math.Atan2(dist.Y, dist.X);

            double newRadius = radius * radius/(Math.Min(center.X, center.Y));
            double newX = center.X + newRadius * Math.Cos(theta);
            double newY = center.Y + newRadius * Math.Sin(theta);

            return new Point((int) newX, (int) newY);
        }
    }
}
