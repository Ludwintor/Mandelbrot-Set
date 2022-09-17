using System.Collections.Generic;
using System.Drawing;
using MandelbrotSet.Utils;
using NUnit.Framework;

namespace MandelbrotSet.Tests
{
    public class ColorHelperTests
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public void HSLToRGB_OutputColorEqualExpected(double hue, double saturation, double lightness, Color expected)
        {
            Color color = ColorHelper.HSLToRGB(hue, saturation, lightness);
            Assert.AreEqual(expected, color, "Expected color is not same as result");
        }

        private static IEnumerable<object> TestData()
        {
            yield return new object[] { 60d, 0.5d, 0.5d, Color.FromArgb(191, 191, 64) };
            yield return new object[] { 32d, 0d, 1d, Color.FromArgb(255, 255, 255) };
            yield return new object[] { 500d, 0.1d, 0.8d, Color.FromArgb(209, 199, 199) };
            yield return new object[] { 253d, 0.9d, 0d, Color.FromArgb(0, 0, 0) };
        }
    }
}