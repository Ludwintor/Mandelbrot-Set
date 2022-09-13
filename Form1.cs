using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace MandelbrotSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap bitmap = new(_pictureBox.Width, _pictureBox.Height);
            int maxIterations = 100;
            double realStart = -1.5;
            double realEnd = 0.5;
            double imaginaryStart = -1;
            double imaginaryEnd = 1;
            for (int y = 0; y < bitmap.Height; y++)
                for (int x = 0; x < bitmap.Width; x++)
                {
                    double real = Lerp(realStart, realEnd, (double)x / bitmap.Width);
                    double imaginary = Lerp(imaginaryStart, imaginaryEnd, (double)y / bitmap.Height);
                    Complex point = new(real, imaginary);
                    Color color = Mandelbrot.Contains(point, maxIterations, out int iterations) ?
                                  Color.Black : HSLToRGB(360d * ((double)iterations / maxIterations), 1d, 0.5d);
                    bitmap.SetPixel(x, y, color);
                }
            _pictureBox.Image = bitmap;
        }

        private Color HSLToRGB(double hue, double saturation, double lightness)
        {
            while (hue < 0d)
                hue += 360d;
            while (hue >= 360d)
                hue -= 360d;
            double chroma = (1d - Math.Abs(2d * lightness - 1d)) * saturation;
            double partitionHue = hue / 60d;
            double secondChroma = chroma * (1d - Math.Abs(partitionHue % 2d - 1d));
            Color point = GetPointOnHSL(chroma, secondChroma, (int)partitionHue);
            double lightnessMatch = (lightness - chroma / 2d) * 255d;
            return Color.FromArgb((int)(point.R + lightnessMatch),
                                  (int)(point.G + lightnessMatch),
                                  (int)(point.B + lightnessMatch));

            Color GetPointOnHSL(double chroma, double secondChroma, int hueIndex)
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private double Lerp(double start, double end, double value)
        {
            return start + value * (end - start);
        }
    }
}