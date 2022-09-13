using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet.Utils
{
    /// <summary>
    /// Provides additional methods to manipulate numbers
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        /// Interpolate between <paramref name="start"/> and <paramref name="end"/>
        /// by <paramref name="value"/>
        /// </summary>
        /// <param name="start">Start value</param>
        /// <param name="end">End value</param>
        /// <param name="value">Interpolator value</param>
        /// <returns>Linear interpolated value between <paramref name="start"/> and <paramref name="end"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Lerp(double start, double end, double value)
        {
            return start + value * (end - start);
        }

        /// <summary>
        /// Interpolate between <paramref name="start"/> and <paramref name="end"/>
        /// by <paramref name="value"/>
        /// </summary>
        /// <param name="start">Start value</param>
        /// <param name="end">End value</param>
        /// <param name="value">Interpolator value</param>
        /// <returns>Linear interpolated value between <paramref name="start"/> and <paramref name="end"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Lerp(float start, float end, float value)
        {
            return start + value * (end - start);
        }
    }
}
