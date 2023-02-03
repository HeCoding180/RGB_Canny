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
            this.thresholdTrackbar = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lThreshold = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.refPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edgeDetectPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackbar)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // refPictureBox
            // 
            this.refPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.refPictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.refPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.refPictureBox.Location = new System.Drawing.Point(3, 23);
            this.refPictureBox.Name = "refPictureBox";
            this.refPictureBox.Size = new System.Drawing.Size(297, 303);
            this.refPictureBox.TabIndex = 0;
            this.refPictureBox.TabStop = false;
            this.refPictureBox.Click += new System.EventHandler(this.refPictureBox_Click);
            // 
            // lRefImage
            // 
            this.lRefImage.AutoSize = true;
            this.lRefImage.Location = new System.Drawing.Point(3, 0);
            this.lRefImage.Name = "lRefImage";
            this.lRefImage.Size = new System.Drawing.Size(95, 15);
            this.lRefImage.TabIndex = 1;
            this.lRefImage.Text = "Reference Image";
            // 
            // lEdgeDetect
            // 
            this.lEdgeDetect.AutoSize = true;
            this.lEdgeDetect.Location = new System.Drawing.Point(306, 0);
            this.lEdgeDetect.Name = "lEdgeDetect";
            this.lEdgeDetect.Size = new System.Drawing.Size(87, 15);
            this.lEdgeDetect.TabIndex = 2;
            this.lEdgeDetect.Text = "Edge Detection";
            // 
            // edgeDetectPictureBox
            // 
            this.edgeDetectPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edgeDetectPictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.edgeDetectPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.edgeDetectPictureBox.Location = new System.Drawing.Point(306, 23);
            this.edgeDetectPictureBox.Name = "edgeDetectPictureBox";
            this.edgeDetectPictureBox.Size = new System.Drawing.Size(297, 303);
            this.edgeDetectPictureBox.TabIndex = 3;
            this.edgeDetectPictureBox.TabStop = false;
            this.edgeDetectPictureBox.Click += new System.EventHandler(this.edgeDetectPictureBox_Click);
            // 
            // bOpen
            // 
            this.bOpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bOpen.Location = new System.Drawing.Point(12, 419);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(606, 30);
            this.bOpen.TabIndex = 4;
            this.bOpen.Text = "Open Image";
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // thresholdTrackbar
            // 
            this.thresholdTrackbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thresholdTrackbar.LargeChange = 16;
            this.thresholdTrackbar.Location = new System.Drawing.Point(12, 368);
            this.thresholdTrackbar.Maximum = 255;
            this.thresholdTrackbar.Name = "thresholdTrackbar";
            this.thresholdTrackbar.Size = new System.Drawing.Size(606, 45);
            this.thresholdTrackbar.TabIndex = 6;
            this.thresholdTrackbar.TickFrequency = 16;
            this.thresholdTrackbar.Value = 128;
            this.thresholdTrackbar.Scroll += new System.EventHandler(this.thresholdTrackbar_Scroll);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.refPictureBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lRefImage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lEdgeDetect, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.edgeDetectPictureBox, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(606, 329);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // lThreshold
            // 
            this.lThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lThreshold.AutoSize = true;
            this.lThreshold.Location = new System.Drawing.Point(12, 350);
            this.lThreshold.Name = "lThreshold";
            this.lThreshold.Size = new System.Drawing.Size(62, 15);
            this.lThreshold.TabIndex = 8;
            this.lThreshold.Text = "Threshold:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 461);
            this.Controls.Add(this.lThreshold);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.thresholdTrackbar);
            this.Controls.Add(this.bOpen);
            this.Name = "Form1";
            this.Text = "Canny Edge Detection";
            ((System.ComponentModel.ISupportInitialize)(this.refPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edgeDetectPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackbar)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox refPictureBox;
        private Label lRefImage;
        private Label lEdgeDetect;
        private PictureBox edgeDetectPictureBox;
        private Button bOpen;
        private TrackBar thresholdTrackbar;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lThreshold;
    }
}