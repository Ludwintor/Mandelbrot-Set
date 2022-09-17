using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using MandelbrotSet.Plot;
using NUnit.Framework;

namespace MandelbrotSet.Tests
{
    public class ComplexPlotTests
    {
        private readonly ComplexPlot _plot = new(new Size(100, 100),
                                                 new Complex(-2d, -2d),
                                                 new Complex(2d, 2d));

        [SetUp]
        public void Setup()
        {
            _plot.Reset();
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public void PixelPointToPlotPoint_Valid(Point pixelPoint, Complex expected)
        {
            Complex result = _plot.PixelPointToPlotPoint(pixelPoint);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCaseSource(nameof(ZoomTestData))]
        public void Zoom_NewBordersLess(Point zoomPoint, float zoomScale)
        {
            Complex oldMin = _plot.Min;
            Complex oldMax = _plot.Max;
            _plot.Zoom(zoomPoint, zoomScale);
            Assert.Less(Math.Abs(_plot.Min.Real * _plot.Max.Real),
                        Math.Abs(oldMin.Real * oldMax.Real), "New borders on X axis became larger");
            Assert.Less(Math.Abs(_plot.Min.Imaginary * _plot.Max.Imaginary),
                        Math.Abs(oldMin.Imaginary * oldMax.Imaginary), "New borders on Y axis became larger");
        }

        private static IEnumerable<object> TestData()
        {
            yield return new object[] { new Point(50, 50), new Complex(0d, 0d) };
            yield return new object[] { new Point(25, 75), new Complex(-1d, 1d) };
        }

        private static IEnumerable<object> ZoomTestData()
        {
            yield return new object[] { new Point(50, 50), 2 };
            yield return new object[] { new Point(0, 50), 1.5f };
            yield return new object[] { new Point(0, 100), 10 };
        }
    }
}
