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
        private Complex _min;
        private Complex _max;

        public Complex Min => _min;
        public Complex Max => _max;

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
            _min = _initialMin;
            _max = _initialMax;
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
            double real = MathHelper.Lerp(_min.Real, _max.Real, point.X / _pixelSize.Width);
            double imaginary = MathHelper.Lerp(_min.Imaginary, _max.Imaginary, point.Y / _pixelSize.Height);
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
            Complex newMin = ZoomBorder(zoomPoint, -zoomScale);
            Complex newMax = ZoomBorder(zoomPoint, zoomScale);
            _min = newMin;
            _max = newMax;

            Complex ZoomBorder(Point zoomPoint, float zoomScale)
            {
                PointF pixelBorder = new(zoomPoint.X + _pixelSize.Width * 0.5f / zoomScale,
                                         zoomPoint.Y + _pixelSize.Height * 0.5f / zoomScale);
                return PixelPointToPlotPoint(pixelBorder);
            }
        }

        /// <summary>
        /// Reset current zoom restoring initial plot corners
        /// </summary>
        public void Reset()
        {
            _min = _initialMin;
            _max = _initialMax;
        }
    }
}