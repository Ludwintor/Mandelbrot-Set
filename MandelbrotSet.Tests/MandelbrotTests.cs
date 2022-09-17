using System.Collections.Generic;
using System.Numerics;
using MandelbrotSet.Plot;
using NUnit.Framework;

namespace MandelbrotSet.Tests
{
    public class MandelbrotTests
    {
        [Test]
        [TestCaseSource(nameof(ContainsTestData))]
        public void Mandelbrot_ContainsPoint_IterationsEqualMax(Complex point, int maxIterations)
        {
            Assert.True(Mandelbrot.Contains(point, maxIterations, out int iterations), $"Iterations: {iterations}");
            Assert.AreEqual(maxIterations, iterations, "Set contains point, but count of iterations is not valid");
        }

        [Test]
        [TestCaseSource(nameof(NotContainsTestData))]
        public void Mandelbrot_NotContainsPoint_IterationsLessMax(Complex point, int maxIterations)
        {
            Assert.False(Mandelbrot.Contains(point, maxIterations, out int iterations), $"Iterations: {iterations}");
            Assert.Less(iterations, maxIterations, $"{iterations} is not less than {maxIterations}");
        }

        private static IEnumerable<object> ContainsTestData()
        {
            yield return new object[] { new Complex(0.2d, 0.3d), 50 };
            yield return new object[] { new Complex(0.2d, 0.1d), 20 };
        }

        private static IEnumerable<object> NotContainsTestData()
        {
            yield return new object[] { new Complex(2d, 1d), 100 };
            yield return new object[] { new Complex(0.8d, 0.9d), 20 };
        }
    }
}
