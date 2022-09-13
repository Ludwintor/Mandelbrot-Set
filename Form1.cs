using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using MandelbrotSet.Utils;

namespace MandelbrotSet
{
    public partial class Form1 : Form
    {
        private int _maxIterations = 100;
        private int _zoomScale = 2;
        private Complex _start = new(-1.5d, -1d);
        private Complex _end = new(0.5d, 1d);
        private Bitmap _bitmap;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _bitmap = new(_pictureBox.Width, _pictureBox.Height);
            RenderImage(_start, _end, _bitmap);
        }

        private void RenderImage(Complex start, Complex end, Bitmap bitmap)
        {
            for (int y = 0; y < bitmap.Height; y++)
                for (int x = 0; x < bitmap.Width; x++)
                {
                    double real = MathHelper.Lerp(start.Real, end.Real, (double)x / bitmap.Width);
                    double imaginary = MathHelper.Lerp(start.Imaginary, end.Imaginary, (double)y / bitmap.Height);
                    Complex point = new(real, imaginary);
                    Color color = MandelbrotSet.Contains(point, _maxIterations, out int iterations) ?
                                  Color.Black : ColorHelper.HSLToRGB(360d * ((double)iterations / _maxIterations), 1d, 0.5d);
                    bitmap.SetPixel(x, y, color);
                }
            _pictureBox.Image = bitmap;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            Point position = _pictureBox.PointToClient(MousePosition);
            PointF normalizedPosition = new PointF((float)position.X / _pictureBox.Size.Width,
                                                   (float)position.Y / _pictureBox.Size.Height);
            double startX = _start.Real * normalizedPosition.X * (_zoomScale - 1d);
            Complex oldStart = _start;
            Complex oldEnd = _end;
            _start += new Complex(startX + 1.5d, startY + 1.5d);
            _end += new Complex(endX - 0.5d, endY - 0.5d);
            RenderImage(_start, _end, _bitmap);
            MessageBox.Show($"OLD START: {oldStart}\nOLD END: {oldEnd}\n" +
                            $"START: {_start}\nEND: {_end}\n" +
                            $"DELTA START: {new Complex(startX, startY)}\nDELTA END: {new Complex(endX, endY)}");
        }
    }
}