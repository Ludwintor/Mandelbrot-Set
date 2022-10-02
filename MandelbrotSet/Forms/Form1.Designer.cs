namespace MandelbrotSet.Forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this._renderButton = new System.Windows.Forms.Button();
            this._settingsBox = new System.Windows.Forms.GroupBox();
            this._zoomScaleText = new System.Windows.Forms.TextBox();
            this._zoomScaleLabel = new System.Windows.Forms.Label();
            this._iterationsText = new System.Windows.Forms.TextBox();
            this._iterationsLabel = new System.Windows.Forms.Label();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._renderBox = new System.Windows.Forms.GroupBox();
            this._timerLabel = new System.Windows.Forms.Label();
            this._staticTimerLabel = new System.Windows.Forms.Label();
            this._statusLabel = new System.Windows.Forms.Label();
            this._staticStatusLabel = new System.Windows.Forms.Label();
            this._resetZoomButton = new System.Windows.Forms.Button();
            this._zoomPrompt = new System.Windows.Forms.Label();
            this._exportBox = new System.Windows.Forms.GroupBox();
            this._previewCheckBox = new System.Windows.Forms.CheckBox();
            this._speedText = new System.Windows.Forms.TextBox();
            this._speedLabel = new System.Windows.Forms.Label();
            this._durationText = new System.Windows.Forms.TextBox();
            this._durationLabel = new System.Windows.Forms.Label();
            this._exportButton = new System.Windows.Forms.Button();
            this._selectPointGifLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this._settingsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this._renderBox.SuspendLayout();
            this._exportBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pictureBox
            // 
            this._pictureBox.Location = new System.Drawing.Point(10, 10);
            this._pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(800, 800);
            this._pictureBox.TabIndex = 0;
            this._pictureBox.TabStop = false;
            this._pictureBox.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // _renderButton
            // 
            this._renderButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._renderButton.Location = new System.Drawing.Point(820, 135);
            this._renderButton.Name = "_renderButton";
            this._renderButton.Size = new System.Drawing.Size(149, 41);
            this._renderButton.TabIndex = 4;
            this._renderButton.Text = "Render";
            this._renderButton.UseVisualStyleBackColor = true;
            this._renderButton.Click += new System.EventHandler(this.RenderButton_Click);
            // 
            // _settingsBox
            // 
            this._settingsBox.Controls.Add(this._zoomScaleText);
            this._settingsBox.Controls.Add(this._zoomScaleLabel);
            this._settingsBox.Controls.Add(this._iterationsText);
            this._settingsBox.Controls.Add(this._iterationsLabel);
            this._settingsBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._settingsBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this._settingsBox.Location = new System.Drawing.Point(820, 182);
            this._settingsBox.Name = "_settingsBox";
            this._settingsBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._settingsBox.Size = new System.Drawing.Size(150, 140);
            this._settingsBox.TabIndex = 6;
            this._settingsBox.TabStop = false;
            this._settingsBox.Text = "Settings";
            // 
            // _zoomScaleText
            // 
            this._zoomScaleText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._zoomScaleText.Location = new System.Drawing.Point(6, 110);
            this._zoomScaleText.Name = "_zoomScaleText";
            this._zoomScaleText.Size = new System.Drawing.Size(116, 23);
            this._zoomScaleText.TabIndex = 3;
            this._zoomScaleText.Text = "2";
            this._zoomScaleText.Validating += new System.ComponentModel.CancelEventHandler(this.ZoomScaleText_Validating);
            this._zoomScaleText.Validated += new System.EventHandler(this.ZoomScaleText_Validated);
            // 
            // _zoomScaleLabel
            // 
            this._zoomScaleLabel.AutoSize = true;
            this._zoomScaleLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._zoomScaleLabel.Location = new System.Drawing.Point(6, 90);
            this._zoomScaleLabel.Name = "_zoomScaleLabel";
            this._zoomScaleLabel.Size = new System.Drawing.Size(75, 17);
            this._zoomScaleLabel.TabIndex = 2;
            this._zoomScaleLabel.Text = "Zoom scale";
            // 
            // _iterationsText
            // 
            this._iterationsText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._iterationsText.Location = new System.Drawing.Point(6, 55);
            this._iterationsText.Name = "_iterationsText";
            this._iterationsText.Size = new System.Drawing.Size(113, 23);
            this._iterationsText.TabIndex = 1;
            this._iterationsText.Text = "100";
            this._iterationsText.Validating += new System.ComponentModel.CancelEventHandler(this.IterationsText_Validating);
            this._iterationsText.Validated += new System.EventHandler(this.IterationsText_Validated);
            // 
            // _iterationsLabel
            // 
            this._iterationsLabel.AutoSize = true;
            this._iterationsLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._iterationsLabel.Location = new System.Drawing.Point(6, 35);
            this._iterationsLabel.Name = "_iterationsLabel";
            this._iterationsLabel.Size = new System.Drawing.Size(62, 17);
            this._iterationsLabel.TabIndex = 0;
            this._iterationsLabel.Text = "Iterations";
            // 
            // _errorProvider
            // 
            this._errorProvider.ContainerControl = this;
            // 
            // _renderBox
            // 
            this._renderBox.Controls.Add(this._timerLabel);
            this._renderBox.Controls.Add(this._staticTimerLabel);
            this._renderBox.Controls.Add(this._statusLabel);
            this._renderBox.Controls.Add(this._staticStatusLabel);
            this._renderBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._renderBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this._renderBox.Location = new System.Drawing.Point(820, 12);
            this._renderBox.Name = "_renderBox";
            this._renderBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._renderBox.Size = new System.Drawing.Size(150, 117);
            this._renderBox.TabIndex = 7;
            this._renderBox.TabStop = false;
            this._renderBox.Text = "Rendering";
            // 
            // _timerLabel
            // 
            this._timerLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._timerLabel.Location = new System.Drawing.Point(0, 91);
            this._timerLabel.Name = "_timerLabel";
            this._timerLabel.Size = new System.Drawing.Size(150, 17);
            this._timerLabel.TabIndex = 3;
            this._timerLabel.Text = "0.222ms";
            this._timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _staticTimerLabel
            // 
            this._staticTimerLabel.AutoSize = true;
            this._staticTimerLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._staticTimerLabel.Location = new System.Drawing.Point(20, 71);
            this._staticTimerLabel.Name = "_staticTimerLabel";
            this._staticTimerLabel.Size = new System.Drawing.Size(111, 20);
            this._staticTimerLabel.TabIndex = 2;
            this._staticTimerLabel.Text = "Rendering time";
            // 
            // _statusLabel
            // 
            this._statusLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._statusLabel.ForeColor = System.Drawing.Color.Green;
            this._statusLabel.Location = new System.Drawing.Point(0, 45);
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(150, 17);
            this._statusLabel.TabIndex = 1;
            this._statusLabel.Text = "Render finish";
            this._statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _staticStatusLabel
            // 
            this._staticStatusLabel.AutoSize = true;
            this._staticStatusLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._staticStatusLabel.Location = new System.Drawing.Point(52, 25);
            this._staticStatusLabel.Name = "_staticStatusLabel";
            this._staticStatusLabel.Size = new System.Drawing.Size(49, 20);
            this._staticStatusLabel.TabIndex = 0;
            this._staticStatusLabel.Text = "Status";
            // 
            // _resetZoomButton
            // 
            this._resetZoomButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._resetZoomButton.Location = new System.Drawing.Point(820, 328);
            this._resetZoomButton.Name = "_resetZoomButton";
            this._resetZoomButton.Size = new System.Drawing.Size(149, 43);
            this._resetZoomButton.TabIndex = 8;
            this._resetZoomButton.Text = "Reset zoom";
            this._resetZoomButton.UseVisualStyleBackColor = true;
            this._resetZoomButton.Click += new System.EventHandler(this.ResetZoomButton_Click);
            // 
            // _zoomPrompt
            // 
            this._zoomPrompt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._zoomPrompt.Location = new System.Drawing.Point(813, 374);
            this._zoomPrompt.Name = "_zoomPrompt";
            this._zoomPrompt.Size = new System.Drawing.Size(166, 17);
            this._zoomPrompt.TabIndex = 4;
            this._zoomPrompt.Text = "Click on image to zoom";
            this._zoomPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _exportBox
            // 
            this._exportBox.Controls.Add(this._previewCheckBox);
            this._exportBox.Controls.Add(this._speedText);
            this._exportBox.Controls.Add(this._speedLabel);
            this._exportBox.Controls.Add(this._durationText);
            this._exportBox.Controls.Add(this._durationLabel);
            this._exportBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._exportBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this._exportBox.Location = new System.Drawing.Point(820, 416);
            this._exportBox.Name = "_exportBox";
            this._exportBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._exportBox.Size = new System.Drawing.Size(150, 164);
            this._exportBox.TabIndex = 7;
            this._exportBox.TabStop = false;
            this._exportBox.Text = "Export";
            // 
            // _previewCheckBox
            // 
            this._previewCheckBox.AutoSize = true;
            this._previewCheckBox.Checked = true;
            this._previewCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._previewCheckBox.Location = new System.Drawing.Point(6, 135);
            this._previewCheckBox.Name = "_previewCheckBox";
            this._previewCheckBox.Size = new System.Drawing.Size(84, 25);
            this._previewCheckBox.TabIndex = 8;
            this._previewCheckBox.Text = "Preview";
            this._previewCheckBox.UseVisualStyleBackColor = true;
            this._previewCheckBox.CheckedChanged += new System.EventHandler(this.PreviewCheckBox_CheckedChanged);
            // 
            // _speedText
            // 
            this._speedText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._speedText.Location = new System.Drawing.Point(3, 106);
            this._speedText.Name = "_speedText";
            this._speedText.Size = new System.Drawing.Size(116, 23);
            this._speedText.TabIndex = 7;
            this._speedText.Text = "3";
            this._speedText.Validating += new System.ComponentModel.CancelEventHandler(this.SpeedText_Validating);
            this._speedText.Validated += new System.EventHandler(this.SpeedText_Validated);
            // 
            // _speedLabel
            // 
            this._speedLabel.AutoSize = true;
            this._speedLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._speedLabel.Location = new System.Drawing.Point(3, 86);
            this._speedLabel.Name = "_speedLabel";
            this._speedLabel.Size = new System.Drawing.Size(45, 17);
            this._speedLabel.TabIndex = 6;
            this._speedLabel.Text = "Speed";
            // 
            // _durationText
            // 
            this._durationText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._durationText.Location = new System.Drawing.Point(3, 51);
            this._durationText.Name = "_durationText";
            this._durationText.Size = new System.Drawing.Size(116, 23);
            this._durationText.TabIndex = 5;
            this._durationText.Text = "5";
            this._durationText.Validating += new System.ComponentModel.CancelEventHandler(this.DurationText_Validating);
            this._durationText.Validated += new System.EventHandler(this.DurationText_Validated);
            // 
            // _durationLabel
            // 
            this._durationLabel.AutoSize = true;
            this._durationLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._durationLabel.Location = new System.Drawing.Point(3, 31);
            this._durationLabel.Name = "_durationLabel";
            this._durationLabel.Size = new System.Drawing.Size(58, 17);
            this._durationLabel.TabIndex = 4;
            this._durationLabel.Text = "Duration";
            // 
            // _exportButton
            // 
            this._exportButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._exportButton.Location = new System.Drawing.Point(820, 586);
            this._exportButton.Name = "_exportButton";
            this._exportButton.Size = new System.Drawing.Size(149, 43);
            this._exportButton.TabIndex = 9;
            this._exportButton.Text = "Export as GIF";
            this._exportButton.UseVisualStyleBackColor = true;
            this._exportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // _selectPointGifLabel
            // 
            this._selectPointGifLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._selectPointGifLabel.Location = new System.Drawing.Point(813, 632);
            this._selectPointGifLabel.Name = "_selectPointGifLabel";
            this._selectPointGifLabel.Size = new System.Drawing.Size(166, 38);
            this._selectPointGifLabel.TabIndex = 10;
            this._selectPointGifLabel.Text = "Select point on image to zoom from";
            this._selectPointGifLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 816);
            this.Controls.Add(this._selectPointGifLabel);
            this.Controls.Add(this._exportBox);
            this.Controls.Add(this._zoomPrompt);
            this.Controls.Add(this._exportButton);
            this.Controls.Add(this._resetZoomButton);
            this.Controls.Add(this._renderBox);
            this.Controls.Add(this._settingsBox);
            this.Controls.Add(this._renderButton);
            this.Controls.Add(this._pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Mandelbrot Set";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this._settingsBox.ResumeLayout(false);
            this._settingsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this._renderBox.ResumeLayout(false);
            this._renderBox.PerformLayout();
            this._exportBox.ResumeLayout(false);
            this._exportBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox _pictureBox;
        private Button _renderButton;
        private GroupBox _settingsBox;
        private Label _iterationsLabel;
        private TextBox _iterationsText;
        private TextBox _zoomScaleText;
        private Label _zoomScaleLabel;
        private ErrorProvider _errorProvider;
        private GroupBox _renderBox;
        private Label _statusLabel;
        private Label _staticStatusLabel;
        private Label _timerLabel;
        private Label _staticTimerLabel;
        private Button _resetZoomButton;
        private Label _zoomPrompt;
        private GroupBox _exportBox;
        private Button _exportButton;
        private TextBox _durationText;
        private Label _durationLabel;
        private TextBox _speedText;
        private Label _speedLabel;
        private CheckBox _previewCheckBox;
        private Label _selectPointGifLabel;
    }
}