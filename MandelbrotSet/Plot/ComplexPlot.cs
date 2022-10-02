using System.Numerics;
using MandelbrotSet.Utils;

namespace MandelbrotSet.Plot
{
    /// <summary>
    /// Represents mathematical 2D plot where X-axis are real numbers, Y-axis are imaginary numbers
    /// </summary>
    public class ComplexPlot
    {
        private readonly Size _pixelSize;
        private readonly Complex _initialMin;
        private readonly Complex _initialMax;

        public Complex Min { get; set; }
        public Complex Max { get; set; }

        /// <summary>
        /// Creates new complex plot
        /// </summary>
        /// <param name="pixelSize">Size of plot image</param>
        /// <param name="initialMin">Bottom-left plot corner coordinate</param>
        /// <param name="initialMax">Top-right plot corner coordinate</param>
        public ComplexPlot(Size pixelSize, Complex initialMin, Complex initialMax)
        {
            _pixelSize = pixelSize;
            _initialMin = initialMin;
            _initialMax = initialMax;
            Min = _initialMin;
            Max = _initialMax;
        }

        /// <summary>
        /// Transforms point on plot image into math coordinate on plot
        /// </summary>
        /// <param name="point">Pixel point on image</param>
        /// <returns>Plot coordinate</returns>
        public Complex PixelPointToPlotPoint(Point point)
        {
            return PixelPointToPlotPoint((PointF)point);
        }

        /// <summary>
        /// Transforms point on plot image into math coordinate on plot
        /// </summary>
        /// <param name="point">Pixel point on image</param>
        /// <returns>Plot coordinate</returns>
        public Complex PixelPointToPlotPoint(PointF point)
        {
            double real = MathHelper.Lerp(Min.Real, Max.Real, point.X / _pixelSize.Width);
            double imaginary = MathHelper.Lerp(Min.Imaginary, Max.Imaginary, point.Y / _pixelSize.Height);
            return new Complex(real, imaginary);
        }

        /// <summary>
        /// Repositions plot corners by zooming in point on image
        /// </summary>
        /// <remarks>
        /// <paramref name="zoomScale"/> less than 1.0 will give reverse effect
        /// </remarks>
        /// <param name="zoomPoint">Point on image</param>
        /// <param name="zoomScale">How strong zoom is</param>
        public void Zoom(Point zoomPoint, float zoomScale)
        {
            Zoom(PixelPointToPlotPoint(zoomPoint), zoomScale);
        }

        public void Zoom(Complex zoomCoordinate, float zoomScale)
        {
            double realDiff = Max.Real - Min.Real;
            double imagDiff = Max.Imaginary - Min.Imaginary;
            Min = new(zoomCoordinate.Real - realDiff * 0.5d / zoomScale,
                      zoomCoordinate.Imaginary - imagDiff * 0.5d / zoomScale);
            Max = new(zoomCoordinate.Real + realDiff * 0.5d / zoomScale,
                      zoomCoordinate.Imaginary + imagDiff * 0.5d / zoomScale);
        }

        /// <summary>
        /// Reset current zoom restoring initial plot corners
        /// </summary>
        public void Reset()
        {
            Min = _initialMin;
            Max = _initialMax;
        }
    }
}