using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet
{
    public static class Mandelbrot
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="complexPoint"></param>
        /// <param name="maxIterations"></param>
        /// <param name="iteration"></param>
        /// <returns></returns>
        public static bool Contains(Complex complexPoint, int maxIterations, out int iteration)
        {
            Complex z = Complex.Zero;
            iteration = 0;
            do
            {
                iteration++;
                z = z * z + complexPoint;
            } while (z.Magnitude <= 2d && iteration < maxIterations);

            return iteration == maxIterations;
        }
    }
}
