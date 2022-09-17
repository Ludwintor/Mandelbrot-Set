using System.Drawing.Imaging;

namespace MandelbrotSet.Writers
{
    /// <summary>
    /// Set pixels on bitmap locking it once<br/>
    /// IMPORTANT: Call <see cref="Dispose"/> after finishing writing pixels and before rendering bitmap
    /// </summary>
    public sealed class BitmapWriter : IDisposable
    {
        /// <summary>
        /// Bitmap 
        /// </summary>
        private readonly Bitmap _bitmap;
        /// <summary>
        /// Bitmap data used to get pixels bytes pointer
        /// </summary>
        private readonly BitmapData _data;

        /// <summary>
        /// Create instance of BitmapWriter and immediately lock bits for writing 
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        public BitmapWriter(Bitmap bitmap)
        {
            _bitmap = bitmap;
            Rectangle rect = new(0, 0, _bitmap.Width, _bitmap.Height);
            _data = bitmap.LockBits(rect, ImageLockMode.WriteOnly, _bitmap.PixelFormat);
        }

        /// <summary>
        /// Set pixel color in provided point
        /// </summary>
        /// <param name="x">Horizontal pixel position</param>
        /// <param name="y">Vertical pixel position</param>
        /// <param name="color">New pixel color</param>
        public unsafe void Write(int x, int y, Color color)
        {
            int offset = DetermineFormatOffset();
            byte* rgbValues = (byte*)_data.Scan0 + y * Math.Abs(_data.Stride) + x * offset;
            // ToArgb() returns int as 0xAARRGGBB
            int hexColor = color.ToArgb();
            for (int i = 0; i < offset; i++)
                // 0xFF is a mask for right most hexes of color so we take colors in that order: Blue, Green, Red, Alpha
                rgbValues[i] = (byte)(0xFF & (hexColor >> 8 * i));
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _bitmap.UnlockBits(_data);
        }

        /// <summary>
        /// Determine how much bytes allocated per pixel
        /// </summary>
        /// <remarks>
        /// Only <see cref="PixelFormat.Format24bppRgb"/> and <see cref="PixelFormat.Format32bppArgb"/> supported
        /// </remarks>
        /// <returns>Count of bytes per pixel</returns>
        /// <exception cref="NotSupportedException"></exception>
        private int DetermineFormatOffset()
        {
            return _data.PixelFormat switch
            {
                PixelFormat.Format24bppRgb => 3,
                PixelFormat.Format32bppArgb => 4,
                _ => throw new NotSupportedException()
            };
        }
    }
}
