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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._timerLabel = new System.Windows.Forms.Label();
            this._staticTimerLabel = new System.Windows.Forms.Label();
            this._statusLabel = new System.Windows.Forms.Label();
            this._staticStatusLabel = new System.Windows.Forms.Label();
            this._resetZoomButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this._settingsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            this._settingsBox.Size = new System.Drawing.Size(150, 154);
            this._settingsBox.TabIndex = 6;
            this._settingsBox.TabStop = false;
            this._settingsBox.Text = "Settings";
            // 
            // _zoomScaleText
            // 
            this._zoomScaleText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._zoomScaleText.Location = new System.Drawing.Point(3, 123);
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
            this._zoomScaleLabel.Location = new System.Drawing.Point(3, 103);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._timerLabel);
            this.groupBox2.Controls.Add(this._staticTimerLabel);
            this.groupBox2.Controls.Add(this._statusLabel);
            this.groupBox2.Controls.Add(this._staticStatusLabel);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(820, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(150, 117);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rendering";
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
            this._statusLabel.Text = "Rendering finished";
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
            this._resetZoomButton.Location = new System.Drawing.Point(820, 342);
            this._resetZoomButton.Name = "_resetZoomButton";
            this._resetZoomButton.Size = new System.Drawing.Size(149, 43);
            this._resetZoomButton.TabIndex = 8;
            this._resetZoomButton.Text = "Reset zoom";
            this._resetZoomButton.UseVisualStyleBackColor = true;
            this._resetZoomButton.Click += new System.EventHandler(this.ResetZoomButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 816);
            this.Controls.Add(this._resetZoomButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this._settingsBox);
            this.Controls.Add(this._renderButton);
            this.Controls.Add(this._pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Mandelbrot Set";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this._settingsBox.ResumeLayout(false);
            this._settingsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private GroupBox groupBox2;
        private Label _statusLabel;
        private Label _staticStatusLabel;
        private Label _timerLabel;
        private Label _staticTimerLabel;
        private Button _resetZoomButton;
    }
}