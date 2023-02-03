namespace CannyEdgeDetection_Test
{
    public partial class Form1 : Form
    {
        Canny edgeDetector;

        bool displayThresholdImage = false;

        public Form1()
        {
            InitializeComponent();

            float[,] gradientXMatrix = new float[3, 3]
            {
                { 1.0f, 0.0f, -1.0f },
                { 2.0f, 0.0f, -2.0f },
                { 1.0f, 0.0f, -1.0f }
            };
            float[,] gradientYMatrix = new float[3, 3]
            {
                { 1.0f, 2.0f, 1.0f },
                { 0.0f, 0.0f, 0.0f },
                { -1.0f, -2.0f, -1.0f }
            };

            ImageFilter gradientXFilter = new ImageFilter(gradientXMatrix);
            ImageFilter gradientYFilter = new ImageFilter(gradientXMatrix);

            edgeDetector = new Canny(EdgeDetectionMode.Grayscale);
            edgeDetector.EdgeDetectThreshold = 128;

            Bitmap testImage = new Bitmap(Image.FromFile(@"C:\Users\timow\source\repos\RGB_Canny\TestImage.png"));

            refPictureBox.BackgroundImage = testImage;

            edgeDetector.ReferenceImage = testImage;

            Bitmap OutputImage = edgeDetector.GradientOutputImage;
            if (OutputImage != null)
            {
                edgeDetectPictureBox.BackgroundImage = OutputImage;
            }
        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            OpenReferenceImage();
        }

        private void thresholdTrackbar_Scroll(object sender, EventArgs e)
        {
            edgeDetector.EdgeDetectThreshold = thresholdTrackbar.Value;

            edgeDetectPictureBox.BackgroundImage = edgeDetector.EdgeOutputImage;
        }

        private void edgeDetectPictureBox_Click(object sender, EventArgs e)
        {
            displayThresholdImage = !displayThresholdImage;

            if (displayThresholdImage)
            {
                edgeDetectPictureBox.BackgroundImage = edgeDetector.EdgeOutputImage;
                thresholdTrackbar.Enabled = true;
            }
            else
            {
                edgeDetectPictureBox.BackgroundImage = edgeDetector.GradientOutputImage;
                thresholdTrackbar.Enabled = false;
            }
        }

        private void refPictureBox_Click(object sender, EventArgs e)
        {
            OpenReferenceImage();
        }

        void OpenReferenceImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|jpeg files (*.jpeg)|*.jpeg";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Open reference image";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap inputImage = new Bitmap(Image.FromFile(openFileDialog.FileName));
                edgeDetector.ReferenceImage = inputImage;

                UpdateDisplayImage();

                refPictureBox.BackgroundImage = inputImage;
            }
        }

        void UpdateDisplayImage()
        {
            if(displayThresholdImage)
            {
                edgeDetectPictureBox.BackgroundImage = edgeDetector.EdgeOutputImage;
            }
            else
            {
                edgeDetectPictureBox.BackgroundImage = edgeDetector.GradientOutputImage;
            }
        }
    }
}