using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet.Utils
{
    /// <summary>
    /// Provides additional methods to manipulate <see cref="Color"/>
    /// </summary>
    public static class ColorHelper
    {
        /// <summary>
        /// Transforms HSL to RGB <see cref="Color"/>
        /// </summary>
        /// <remarks>
        /// <see href="https://en.wikipedia.org/wiki/HSL_and_HSV#HSL_to_RGB">Transform algorithm on wikipedia</see>
        /// </remarks>
        /// <param name="hue">Must be in range [0; 360]</param>
        /// <param name="saturation">Must be in range [0; 1]</param>
        /// <param name="lightness">Must be in range [0; 1]</param>
        /// <returns>RGB <see cref="Color"/></returns>
        public static Color HSLToRGB(double hue, double saturation, double lightness)
        {
            while (hue < 0d)
                hue += 360d;
            while (hue >= 360d)
                hue -= 360d;
            double chroma = (1d - Math.Abs(2d * lightness - 1d)) * saturation;
            double partitionHue = hue / 60d;
            double secondChroma = chroma * (1d - Math.Abs(partitionHue % 2d - 1d));
            Color point = GetHSLPoint(chroma, secondChroma, (int)partitionHue);
            double lightnessMatch = (lightness - chroma / 2d) * 255d;
            return Color.FromArgb((int)(point.R + lightnessMatch),
                                  (int)(point.G + lightnessMatch),
                                  (int)(point.B + lightnessMatch));
        }

        /// <summary>
        /// Determine point on HSL palette by two chromas and hue index
        /// </summary>
        /// <param name="chroma">First largest component</param>
        /// <param name="secondChroma">Second largest component</param>
        /// <param name="hueIndex">Hue index in range [0; 5]</param>
        /// <returns>HSL point as <see cref="Color"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">If hue index outside [0; 5]</exception>
        private static Color GetHSLPoint(double chroma, double secondChroma, int hueIndex)
        {
            int r = (int)(chroma * 255d);
            int g = (int)(secondChroma * 255d);
            return hueIndex switch
            {
                0 => Color.FromArgb(r, g, 0),
                1 => Color.FromArgb(g, r, 0),
                2 => Color.FromArgb(0, r, g),
                3 => Color.FromArgb(0, g, r),
                4 => Color.FromArgb(g, 0, r),
                5 => Color.FromArgb(r, 0, g),
                _ => throw new ArgumentOutOfRangeException(nameof(hueIndex))
            };
        }
    }
}
