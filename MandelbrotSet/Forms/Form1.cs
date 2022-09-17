using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Numerics;
using MandelbrotSet.Plot;
using MandelbrotSet.Utils;
using MandelbrotSet.Writers;

namespace MandelbrotSet.Forms
{
    /// <summary>
    /// Main window
    /// </summary>
    public partial class Form1 : Form
    {
        private const double SATURATION = 0.65d;
        private const double LIGHTNESS = 0.5d;

        private static readonly Complex _initialStart = new(-1.5d, -1d);
        private static readonly Complex _initialEnd = new(0.5d, 1d);

        private readonly ComplexPlot _plot;
        private readonly Stopwatch _stopwatch;
        private readonly Bitmap _bitmap;

        private int _maxIterations = 100;
        private float _zoomScale = 2f;

        /// <summary>
        /// Initialize form window
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap = new(_pictureBox.Width, _pictureBox.Height, PixelFormat.Format24bppRgb);
            _bitmap = bitmap;
            _stopwatch = new Stopwatch();
            _plot = new ComplexPlot(bitmap.Size, _initialStart, _initialEnd);
        }

        /// <summary>
        /// Called after form window loaded
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            _iterationsText.Text = _maxIterations.ToString();
            _zoomScaleText.Text = _zoomScale.ToString();
            RenderImage();
        }

        /// <summary>
        /// Render Mandelbrot set and show it
        /// </summary>
        private void RenderImage()
        {
            SetStatus("Rendering...", Color.Olive);
            using (BitmapWriter writer = new(_bitmap))
            {
                _stopwatch.Restart();
                for (int y = 0; y < _bitmap.Height; y++)
                    for (int x = 0; x < _bitmap.Width; x++)
                    {
                        Complex point = _plot.PixelPointToPlotPoint(new Point(x, y));
                        Color color = Mandelbrot.Contains(point, _maxIterations, out int iterations) ? 
                                      Color.Black : 
                                      ColorHelper.HSLToRGB(360d * ((double)iterations / _maxIterations),
                                                           SATURATION, LIGHTNESS);
                        writer.Write(x, y, color);
                    }
                _stopwatch.Stop();
            }
            SetStatus("Render complete", Color.Green);
            _timerLabel.Text = $"{_stopwatch.ElapsedMilliseconds / 1000f:0.000}s";
            _pictureBox.Image = _bitmap;
        }

        /// <summary>
        /// Sets text and color to status label
        /// </summary>
        /// <param name="text">Status text</param>
        /// <param name="color">Status text color</param>
        private void SetStatus(string text, Color color)
        {
            _statusLabel.Text = text;
            _statusLabel.ForeColor = color;
            _statusLabel.Refresh();
        }

        /// <summary>
        /// Validate that last text box contains valid input
        /// </summary>
        /// <returns>True if validation successful, otherwise false</returns>
        private bool ValidateInput()
        {
            if (!Validate())
            {
                SetStatus("Fix all errors", Color.Red);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Called when _renderButton clicked
        /// </summary>
        private void RenderButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;
            RenderImage();
        }

        /// <summary>
        /// Called when _pictureBox clicked
        /// </summary>
        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;
            Point zoomPoint = _pictureBox.PointToClient(MousePosition);
            _plot.Zoom(zoomPoint, _zoomScale);
            RenderImage();
        }

        /// <summary>
        /// Called when _resetZoomButton clicked
        /// </summary>
        private void ResetZoomButton_Click(object sender, EventArgs e)
        {
            _plot.Reset();
        }

        /// <summary>
        /// Called when lost focus on _iterationsText to validate input
        /// </summary>
        private void IterationsText_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(_iterationsText.Text, out int _))
            {
                e.Cancel = true;
                _errorProvider.SetError(_iterationsText, "Enter an integer value");
            }
        }

        /// <summary>
        /// Called when _iterationsText value validated successfully
        /// </summary>
        private void IterationsText_Validated(object sender, EventArgs e)
        {
            _maxIterations = int.Parse(_iterationsText.Text);
            _errorProvider.SetError(_iterationsText, "");
        }

        /// <summary>
        /// Called when lost focus on _zoomScaleText to validate input
        /// </summary>
        private void ZoomScaleText_Validating(object sender, CancelEventArgs e)
        {
            if (!float.TryParse(_zoomScaleText.Text, out float zoom) || zoom <= 1f)
            {
                e.Cancel = true;
                _errorProvider.SetError(_zoomScaleText, "Enter an decimal number greater than 1");
            }
        }

        /// <summary>
        /// Called when _zoomScaleText value validated successfully
        /// </summary>
        private void ZoomScaleText_Validated(object sender, EventArgs e)
        {
            _zoomScale = float.Parse(_zoomScaleText.Text);
            _errorProvider.SetError(_zoomScaleText, "");
        }
    }
}