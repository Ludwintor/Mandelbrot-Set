using MandelbrotSet.Utils;
using NUnit.Framework;

namespace MandelbrotSet.Tests
{
    public class MathHelperTests
    {
        [TestCase(0f, 100f, 0.5f, 50f)]
        [TestCase(150f, 300f, 0.2f, 180f)]
        public void Lerp_Validate(float start, float end, float value, float expected)
        {
            float result = MathHelper.Lerp(start, end, value);
            Assert.AreEqual(expected, result);
        }
    }
}
