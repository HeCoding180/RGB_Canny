namespace CannyEdgeDetection_Test
{
    public partial class Form1 : Form
    {
        Canny edgeDetector;

        public Form1()
        {
            InitializeComponent();

            edgeDetector = new Canny(EdgeDetectionMode.RGB);
            edgeDetector.EdgeDetectThreshold = 128;
        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|jpeg files (*.jpeg)|*.jpeg";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Open reference image";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap inputFile = (Bitmap)Image.FromFile(openFileDialog.FileName);
                refPictureBox.BackgroundImage = inputFile;
                Bitmap OutputImage = edgeDetector.GenerateEdgeDetectBitmap(inputFile);
                if (OutputImage != null)
                {
                    edgeDetectPictureBox.BackgroundImage = OutputImage;
                }
            }
        }

        private void thresholdTrackbar_Scroll(object sender, EventArgs e)
        {
            edgeDetector.EdgeDetectThreshold = thresholdTrackbar.Value;
            edgeDetectPictureBox.Image = edgeDetector.GenerateEdgeDetectBitmap();
        }
    }
}