using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Numerics;
using System.Windows.Media.Imaging;
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
        private const int GIF_FPS = 24;
        private const double SATURATION = 0.65d;
        private const double LIGHTNESS = 0.5d;

        private static readonly Complex _initialStart = new(-1.5d, -1d);
        private static readonly Complex _initialEnd = new(0.5d, 1d);

        private readonly ComplexPlot _plot;
        private readonly Stopwatch _stopwatch;
        private readonly Bitmap _bitmap;

        private int _maxIterations = 100;
        private float _zoomScale = 2f;
        private float _duration = 5f;
        private float _speed = 3f;
        private bool _previewGif = true;
        private bool _isGifExport = false;

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
            _pictureBox.Image = _bitmap;
        }

        /// <summary>
        /// Called after form window loaded
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            _iterationsText.Text = _maxIterations.ToString();
            _zoomScaleText.Text = _zoomScale.ToString();
            _durationText.Text = _duration.ToString();
            _speedText.Text = _speed.ToString();
            _previewCheckBox.Checked = _previewGif;
            _selectPointGifLabel.Text = "";
            RenderPicture();
        }

        private void RenderPicture()
        {
            SetStatus("Rendering...", Color.Olive);
            _stopwatch.Restart();
            RenderImage(_bitmap);
            _stopwatch.Stop();
            SetStatus("Render complete", Color.Green);
            SetTimerLabel(_stopwatch.ElapsedMilliseconds);
            DisplayPicture(_bitmap);
        }

        private void DisplayPicture(Bitmap bitmap)
        {
            _pictureBox.Image = bitmap;
            _pictureBox.Refresh();
        }

        /// <summary>
        /// Render Mandelbrot set and show it
        /// </summary>
        private void RenderImage(Bitmap bitmap)
        {
            using BitmapWriter writer = new(bitmap);
            for (int y = 0; y < bitmap.Height; y++)
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Complex point = _plot.PixelPointToPlotPoint(new Point(x, y));
                    Color color = Mandelbrot.Contains(point, _maxIterations, out int iterations) ?
                                  Color.Black :
                                  ColorHelper.HSLToRGB(360d * ((double)iterations / _maxIterations),
                                                       SATURATION, LIGHTNESS);
                    writer.Write(x, y, color);
                }
        }

        /// <summary>
        /// Renders GIF file in provided output
        /// </summary>
        /// <param name="output">Stream to save GIF file</param>
        /// <param name="start">Start zoom from this point on plot</param>
        private void RenderGif(Stream output, Point start)
        {
            _plot.Reset();
            _plot.Zoom(start, 1f);
            Bitmap bitmap = new(_pictureBox.Width, _pictureBox.Height);
            Point center = new(bitmap.Width / 2, bitmap.Height / 2);
            float frameTime = 1f / GIF_FPS;
            int totalFrames = (int)MathF.Ceiling(GIF_FPS * _duration);
            float delta = _speed / 10f * frameTime;
            int renderedFrames = 0;
            SetStatus("Rendering GIF...", Color.Olive);
            _stopwatch.Restart();
            using GifWriter writer = new(output, 0);
            do
            {
                RenderImage(bitmap);
                writer.WriteFrame(bitmap, (int)(frameTime * 1000d));
                if (_previewGif)
                    DisplayPicture(bitmap);
                _plot.Zoom(center, 1f + delta);
                renderedFrames++;
            } while (renderedFrames < totalFrames);
            _stopwatch.Stop();
            SetTimerLabel(_stopwatch.ElapsedMilliseconds);
            SetStatus("GIF render complete", Color.Green);
            _isGifExport = false;
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
            RenderPicture();
        }

        /// <summary>
        /// Called when _pictureBox clicked
        /// </summary>
        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;
            Point clickPoint = _pictureBox.PointToClient(MousePosition);
            if (_isGifExport)
            {
                _selectPointGifLabel.Text = "";
                SaveFileDialog saveDialog = new()
                {
                    Filter = "Gif image|*.gif",
                    Title = "Save GIF file"
                };
                DialogResult result = saveDialog.ShowDialog();
                if (result == DialogResult.OK)
                    RenderGif(saveDialog.OpenFile(), clickPoint);
            }
            else
            {
                _plot.Zoom(clickPoint, _zoomScale);
                RenderPicture();
            }
        }

        /// <summary>
        /// Called when _resetZoomButton clicked
        /// </summary>
        private void ResetZoomButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;
            _plot.Reset();
            RenderPicture();
        }

        /// <summary>
        /// Called when _exportButton clicked
        /// </summary>
        private void ExportButton_Click(object sender, EventArgs e)
        {
            _plot.Reset();
            RenderPicture();
            _selectPointGifLabel.Text = "Select point on image to zoom from";
            _isGifExport = true;
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
            _zoomScaleText.Text = _zoomScaleText.Text.Replace(',', '.');
            if (!float.TryParse(_zoomScaleText.Text, out float zoom) || zoom <= 1f)
            {
                e.Cancel = true;
                _errorProvider.SetError(_zoomScaleText, "Enter a decimal number greater than 1");
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

        private void DurationText_Validating(object sender, CancelEventArgs e)
        {
            _durationText.Text = _durationText.Text.Replace(',', '.');
            if (!float.TryParse(_durationText.Text, out float duration) || duration <= 0)
            {
                e.Cancel = true;
                _errorProvider.SetError(_durationText, "Enter a decimal number greater than 0");
            }
        }

        private void DurationText_Validated(object sender, EventArgs e)
        {
            _duration = float.Parse(_durationText.Text);
            _errorProvider.SetError(_durationText, "");
        }

        private void SpeedText_Validating(object sender, CancelEventArgs e)
        {
            _speedText.Text = _speedText.Text.Replace(',', '.');
            if (!float.TryParse(_speedText.Text, out float speed) || speed <= 0)
            {
                e.Cancel = true;
                _errorProvider.SetError(_speedText, "Enter a decimal number greater than 0");
            }
        }

        private void SpeedText_Validated(object sender, EventArgs e)
        {
            _speed = float.Parse(_speedText.Text);
            _errorProvider.SetError(_speedText, "");
        }

        private void PreviewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _previewGif = _previewCheckBox.Checked;
        }

        /// <summary>
        /// Sets text on timer label
        /// </summary>
        /// <param name="milliseconds">elapsed time in milliseconds</param>
        private void SetTimerLabel(long milliseconds)
        {
            _timerLabel.Text = $"{milliseconds / 1000f:0.000}s";
        }
    }
}