namespace CannyEdgeDetection_Test
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
            this.refPictureBox = new System.Windows.Forms.PictureBox();
            this.lRefImage = new System.Windows.Forms.Label();
            this.lEdgeDetect = new System.Windows.Forms.Label();
            this.edgeDetectPictureBox = new System.Windows.Forms.PictureBox();
            this.bOpen = new System.Windows.Forms.Button();
            this.lThresh = new System.Windows.Forms.Label();
            this.thresholdTrackbar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.refPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edgeDetectPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // refPictureBox
            // 
            this.refPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.refPictureBox.Location = new System.Drawing.Point(12, 27);
            this.refPictureBox.Name = "refPictureBox";
            this.refPictureBox.Size = new System.Drawing.Size(300, 300);
            this.refPictureBox.TabIndex = 0;
            this.refPictureBox.TabStop = false;
            // 
            // lRefImage
            // 
            this.lRefImage.AutoSize = true;
            this.lRefImage.Location = new System.Drawing.Point(12, 9);
            this.lRefImage.Name = "lRefImage";
            this.lRefImage.Size = new System.Drawing.Size(95, 15);
            this.lRefImage.TabIndex = 1;
            this.lRefImage.Text = "Reference Image";
            // 
            // lEdgeDetect
            // 
            this.lEdgeDetect.AutoSize = true;
            this.lEdgeDetect.Location = new System.Drawing.Point(318, 9);
            this.lEdgeDetect.Name = "lEdgeDetect";
            this.lEdgeDetect.Size = new System.Drawing.Size(87, 15);
            this.lEdgeDetect.TabIndex = 2;
            this.lEdgeDetect.Text = "Edge Detection";
            // 
            // edgeDetectPictureBox
            // 
            this.edgeDetectPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.edgeDetectPictureBox.Location = new System.Drawing.Point(318, 27);
            this.edgeDetectPictureBox.Name = "edgeDetectPictureBox";
            this.edgeDetectPictureBox.Size = new System.Drawing.Size(300, 300);
            this.edgeDetectPictureBox.TabIndex = 3;
            this.edgeDetectPictureBox.TabStop = false;
            // 
            // bOpen
            // 
            this.bOpen.Location = new System.Drawing.Point(12, 399);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(606, 30);
            this.bOpen.TabIndex = 4;
            this.bOpen.Text = "Open Image";
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // lThresh
            // 
            this.lThresh.AutoSize = true;
            this.lThresh.Location = new System.Drawing.Point(12, 330);
            this.lThresh.Name = "lThresh";
            this.lThresh.Size = new System.Drawing.Size(59, 15);
            this.lThresh.TabIndex = 5;
            this.lThresh.Text = "Threshold";
            // 
            // thresholdTrackbar
            // 
            this.thresholdTrackbar.LargeChange = 16;
            this.thresholdTrackbar.Location = new System.Drawing.Point(12, 348);
            this.thresholdTrackbar.Maximum = 255;
            this.thresholdTrackbar.Name = "thresholdTrackbar";
            this.thresholdTrackbar.Size = new System.Drawing.Size(606, 45);
            this.thresholdTrackbar.TabIndex = 6;
            this.thresholdTrackbar.TickFrequency = 16;
            this.thresholdTrackbar.Value = 128;
            this.thresholdTrackbar.Scroll += new System.EventHandler(this.thresholdTrackbar_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 441);
            this.Controls.Add(this.thresholdTrackbar);
            this.Controls.Add(this.lThresh);
            this.Controls.Add(this.bOpen);
            this.Controls.Add(this.edgeDetectPictureBox);
            this.Controls.Add(this.lEdgeDetect);
            this.Controls.Add(this.lRefImage);
            this.Controls.Add(this.refPictureBox);
            this.Name = "Form1";
            this.Text = "Canny Edge Detection";
            ((System.ComponentModel.ISupportInitialize)(this.refPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edgeDetectPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox refPictureBox;
        private Label lRefImage;
        private Label lEdgeDetect;
        private PictureBox edgeDetectPictureBox;
        private Button bOpen;
        private Label lThresh;
        private TrackBar thresholdTrackbar;
    }
}