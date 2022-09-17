using System.Numerics;

namespace MandelbrotSet.Plot
{
    /// <summary>
    /// Represents Mandelbrot Set
    /// </summary>
    public static class Mandelbrot
    {
        /// <summary>
        /// Test if provided complex point is in Mandelbrot Set
        /// </summary>
        /// <param name="complexPoint">Complex point to test</param>
        /// <param name="maxIterations">Total iterations to test</param>
        /// <param name="iteration">Iterations succeeded during test. Equals to <paramref name="maxIterations"/> if test passed</param>
        /// <returns>True if point in Mandelbrot Set, false otherwise</returns>
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
