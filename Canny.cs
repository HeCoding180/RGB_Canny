using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannyEdgeDetection_Test
{
    public enum EdgeDetectionMode
    {
        RGB,
        Grayscale
    }

    public class Canny
    {
        private Bitmap _refImage { set; get; }
        public Bitmap ReferenceImage
        {
            set
            {
                _refImage = value;
                imageWidth = value.Width;
                imageHeight = value.Height;
                GenerateEdgeDetectBitmap();
            }
            get
            {
                return _refImage;
            }
        }

        public Bitmap GradientOutputImage { private set; get; }
        public int[,] ScaledGradientOutputArray { private set; get; }

        public Bitmap EdgeOutputImage
        {
            get
            {
                return GetThresholdEdgeImage();
            }
        }

        public int EdgeDetectThreshold { set; get; }
        public EdgeDetectionMode mode { set; get; }

        public int imageWidth { private set; get; }
        public int imageHeight { private set; get; }

        public Canny(EdgeDetectionMode mode)
        {
            this.mode = mode;
        }
        public Canny(Bitmap refImage, EdgeDetectionMode mode)
        {
            this.mode = mode;

            ReferenceImage = refImage;

            imageWidth = refImage.Width;
            imageHeight = refImage.Height;
        }
        public Canny(Bitmap refImage, int threshold, EdgeDetectionMode mode)
        {
            this.mode = mode;

            ReferenceImage = refImage;
            EdgeDetectThreshold = threshold;

            imageWidth = refImage.Width;
            imageHeight = refImage.Height;
        }
        public Canny(Image refImage, EdgeDetectionMode mode)
        {
            this.mode = mode;

            ReferenceImage = (Bitmap)refImage;

            imageWidth = refImage.Width;
            imageHeight = refImage.Height;
        }
        public Canny(Image refImage, int threshold, EdgeDetectionMode mode)
        {
            this.mode = mode;

            ReferenceImage = (Bitmap)refImage;
            EdgeDetectThreshold = threshold;

            imageWidth = refImage.Width;
            imageHeight = refImage.Height;
        }

        private Color GetGrayscaleColor(int level)
        {
            return Color.FromArgb(level, level, level);
        }

        private void GenerateEdgeDetectBitmap()
        {
            if (ReferenceImage != null)
            {
                GradientOutputImage = new Bitmap(imageWidth, imageHeight);
                ScaledGradientOutputArray = new int[imageWidth, imageHeight];

                int[,] absolutePixelGradientOutput = new int[imageWidth, imageHeight];

                int minPixelValue = 0;
                int maxPixelValue = 0;

                switch (mode)
                {
                    case EdgeDetectionMode.RGB:
                        int[,,] absolutePixelGradientX3 = new int[imageWidth, imageHeight, 3];
                        int[,,] absolutePixelGradientY3 = new int[imageWidth, imageHeight, 3];

                        for (int x = 0; x < imageWidth; x++)
                        {
                            for (int y = 0; y < imageHeight; y++)
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    absolutePixelGradientX3[x, y, i] = 0;
                                    absolutePixelGradientY3[x, y, i] = 0;
                                }


                                if ((x == 0) || (x == (imageWidth - 1)))
                                {
                                    absolutePixelGradientX3[x, y, 0] = _refImage.GetPixel(x, y).R;
                                    absolutePixelGradientX3[x, y, 1] = _refImage.GetPixel(x, y).G;
                                    absolutePixelGradientX3[x, y, 2] = _refImage.GetPixel(x, y).B;
                                }
                                else
                                {
                                    absolutePixelGradientX3[x, y, 0] += _refImage.GetPixel(x + 1, y).R - _refImage.GetPixel(x - 1, y).R;
                                    absolutePixelGradientX3[x, y, 1] += _refImage.GetPixel(x + 1, y).G - _refImage.GetPixel(x - 1, y).G;
                                    absolutePixelGradientX3[x, y, 2] += _refImage.GetPixel(x + 1, y).B - _refImage.GetPixel(x - 1, y).B;
                                }

                                if ((y == 0) || (y == (imageHeight - 1)))
                                {
                                    absolutePixelGradientY3[x, y, 0] = _refImage.GetPixel(x, y).R;
                                    absolutePixelGradientY3[x, y, 1] = _refImage.GetPixel(x, y).G;
                                    absolutePixelGradientY3[x, y, 2] = _refImage.GetPixel(x, y).B;
                                }
                                else
                                {
                                    absolutePixelGradientY3[x, y, 0] += _refImage.GetPixel(x, y + 1).R - _refImage.GetPixel(x, y - 1).R;
                                    absolutePixelGradientY3[x, y, 1] += _refImage.GetPixel(x, y + 1).G - _refImage.GetPixel(x, y - 1).G;
                                    absolutePixelGradientY3[x, y, 2] += _refImage.GetPixel(x, y + 1).B - _refImage.GetPixel(x, y - 1).B;
                                }

                                absolutePixelGradientOutput[x, y] = Math.Abs(absolutePixelGradientX3[x, y, 0] + absolutePixelGradientY3[x, y, 0])
                                                                  + Math.Abs(absolutePixelGradientX3[x, y, 1] + absolutePixelGradientY3[x, y, 1])
                                                                  + Math.Abs(absolutePixelGradientX3[x, y, 2] + absolutePixelGradientY3[x, y, 2]);

                                if (absolutePixelGradientOutput[x, y] < minPixelValue)
                                {
                                    minPixelValue = absolutePixelGradientOutput[x, y];
                                }
                                if (absolutePixelGradientOutput[x, y] > maxPixelValue)
                                {
                                    maxPixelValue = absolutePixelGradientOutput[x, y];
                                }
                            }
                        }
                        break;
                    case EdgeDetectionMode.Grayscale:
                        int[,] absolutePixelGradientX = new int[imageWidth, imageHeight];
                        int[,] absolutePixelGradientY = new int[imageWidth, imageHeight];

                        for (int x = 0; x < imageWidth; x++)
                        {
                            for (int y = 0; y < imageHeight; y++)
                            {
                                absolutePixelGradientX[x, y] = 0;
                                absolutePixelGradientY[x, y] = 0;

                                if ((x == 0) || (x == (imageWidth - 1)))
                                {
                                    absolutePixelGradientX[x, y] = ReferenceImage.GetPixel(x, y).R + ReferenceImage.GetPixel(x, y).G + ReferenceImage.GetPixel(x, y).B;
                                }
                                else
                                {
                                    absolutePixelGradientX[x, y] += _refImage.GetPixel(x + 1, y).R
                                                                  + _refImage.GetPixel(x + 1, y).G
                                                                  + _refImage.GetPixel(x + 1, y).B
                                                                  - _refImage.GetPixel(x - 1, y).R
                                                                  - _refImage.GetPixel(x - 1, y).G
                                                                  - _refImage.GetPixel(x - 1, y).B;


                                }
                                if ((y == 0) || (y == (imageHeight - 1)))
                                {
                                    absolutePixelGradientY[x, y] = ReferenceImage.GetPixel(x, y).R + ReferenceImage.GetPixel(x, y).G + ReferenceImage.GetPixel(x, y).B;
                                }
                                else
                                {
                                    absolutePixelGradientY[x, y] += _refImage.GetPixel(x, y + 1).R
                                                                  + _refImage.GetPixel(x, y + 1).G
                                                                  + _refImage.GetPixel(x, y + 1).B
                                                                  - _refImage.GetPixel(x, y - 1).R
                                                                  - _refImage.GetPixel(x, y - 1).G
                                                                  - _refImage.GetPixel(x, y - 1).B;
                                }

                                absolutePixelGradientOutput[x, y] = Math.Abs(absolutePixelGradientX[x, y] + absolutePixelGradientY[x, y]);

                                if (absolutePixelGradientOutput[x, y] < minPixelValue)
                                {
                                    minPixelValue = absolutePixelGradientOutput[x, y];
                                }
                                if (absolutePixelGradientOutput[x, y] > maxPixelValue)
                                {
                                    maxPixelValue = absolutePixelGradientOutput[x, y];
                                }
                            }
                        }
                        break;
                }

                int offset = -minPixelValue;
                double scaleFactor = 255.0 / (double)(maxPixelValue - minPixelValue);

                for (int x = 0; x < imageWidth; x++)
                {
                    for (int y = 0; y < imageHeight; y++)
                    {
                        int scaledValue = (int)Math.Round((absolutePixelGradientOutput[x, y] + offset) * scaleFactor);
                        ScaledGradientOutputArray[x, y] = scaledValue;
                        GradientOutputImage.SetPixel(x, y, GetGrayscaleColor(scaledValue));
                    }
                }
            }
        }

        private Bitmap? GetThresholdEdgeImage()
        {
            Bitmap outputImage = new Bitmap(imageWidth, imageHeight);

            for (int x = 0; x < imageWidth; x++)
            {
                for (int y = 0; y < imageHeight; y++)
                {
                    if (ScaledGradientOutputArray[x, y] >= EdgeDetectThreshold)
                        outputImage.SetPixel(x, y, GetGrayscaleColor(255));
                    else
                        outputImage.SetPixel(x, y, GetGrayscaleColor(0));
                }
            }

            return outputImage;
        }
    }
}
