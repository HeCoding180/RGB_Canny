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
            }
            get
            {
                return _refImage;
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

        private Color GetGrayscaleColor(int level)
        {
            return Color.FromArgb(level, level, level);
        }

        public Bitmap? GenerateEdgeDetectBitmap()
        {
            if (ReferenceImage != null)
            {
                Bitmap outputImage = new Bitmap(imageWidth, imageHeight);

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
                                    absolutePixelGradientX3[x, y, 0] = ReferenceImage.GetPixel(x, y).R;
                                    absolutePixelGradientX3[x, y, 1] = ReferenceImage.GetPixel(x, y).G;
                                    absolutePixelGradientX3[x, y, 2] = ReferenceImage.GetPixel(x, y).B;
                                }
                                else
                                {
                                    absolutePixelGradientX3[x, y, 0] += ReferenceImage.GetPixel(x + 1, y).R - absolutePixelGradientX3[x - 1, y, 0];
                                    absolutePixelGradientX3[x, y, 1] += ReferenceImage.GetPixel(x + 1, y).G - absolutePixelGradientX3[x - 1, y, 1];
                                    absolutePixelGradientX3[x, y, 2] += ReferenceImage.GetPixel(x + 1, y).B - absolutePixelGradientX3[x - 1, y, 2];
                                }

                                if ((y == 0) || (y == (imageHeight - 1)))
                                {
                                    absolutePixelGradientY3[x, y, 0] = ReferenceImage.GetPixel(x, y).R;
                                    absolutePixelGradientY3[x, y, 1] = ReferenceImage.GetPixel(x, y).G;
                                    absolutePixelGradientY3[x, y, 2] = ReferenceImage.GetPixel(x, y).B;
                                }
                                else
                                {
                                    absolutePixelGradientY3[x, y, 0] += ReferenceImage.GetPixel(x, y + 1).R - absolutePixelGradientX3[x, y - 1, 0];
                                    absolutePixelGradientY3[x, y, 1] += ReferenceImage.GetPixel(x, y + 1).G - absolutePixelGradientX3[x, y - 1, 1];
                                    absolutePixelGradientY3[x, y, 2] += ReferenceImage.GetPixel(x, y + 1).B - absolutePixelGradientX3[x, y - 1, 2];
                                }

                                absolutePixelGradientOutput[x, y] = absolutePixelGradientX3[x, y, 0] + absolutePixelGradientY3[x, y, 0]
                                                                  + absolutePixelGradientX3[x, y, 1] + absolutePixelGradientY3[x, y, 1]
                                                                  + absolutePixelGradientX3[x, y, 2] + absolutePixelGradientY3[x, y, 2];

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
                                    absolutePixelGradientX[x, y] += ReferenceImage.GetPixel(x + 1, y).R
                                                                  + ReferenceImage.GetPixel(x + 1, y).G
                                                                  + ReferenceImage.GetPixel(x + 1, y).B
                                                                  - absolutePixelGradientY[x - 1, y];
                                }
                                if ((y == 0) || (y == (imageHeight - 1)))
                                {
                                    absolutePixelGradientY[x, y] = ReferenceImage.GetPixel(x, y).R + ReferenceImage.GetPixel(x, y).G + ReferenceImage.GetPixel(x, y).B;
                                }
                                else
                                {
                                    absolutePixelGradientY[x, y] += ReferenceImage.GetPixel(x, y + 1).R
                                                                  + ReferenceImage.GetPixel(x, y + 1).G
                                                                  + ReferenceImage.GetPixel(x, y + 1).B
                                                                  - absolutePixelGradientY[x, y - 1];
                                }

                                absolutePixelGradientOutput[x, y] = absolutePixelGradientX[x, y] + absolutePixelGradientY[x, y];

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
                double scaleFactor = 255.0 / (maxPixelValue - minPixelValue);

                int[,] outArr = new int[imageWidth, imageHeight];

                for (int x = 0; x < imageWidth; x++)
                {
                    for (int y = 0; y < imageHeight; y++)
                    {
                        if ((int)Math.Round((absolutePixelGradientOutput[x, y] + offset) * scaleFactor) >= EdgeDetectThreshold)
                            outputImage.SetPixel(x, y, GetGrayscaleColor(255));
                        else
                            outputImage.SetPixel(x, y, GetGrayscaleColor(0));
                        //outputImage.SetPixel(x, y, GetGrayscaleColor((int)Math.Round((absolutePixelGradientOutput[x, y] + offset) * scaleFactor)));
                        outArr[x, y] = (int)Math.Round((absolutePixelGradientOutput[x, y] + offset) * scaleFactor);
                    }
                }

                return outputImage;
            }
            else
            {
                return null;
            }
        }

        public Bitmap? GenerateEdgeDetectBitmap(Bitmap refImage)
        {
            ReferenceImage = refImage;

            return GenerateEdgeDetectBitmap();
        }

        public Bitmap? GenerateEdgeDetectBitmap(Bitmap refImage, int threshold)
        {
            ReferenceImage = refImage;

            EdgeDetectThreshold = threshold;

            return GenerateEdgeDetectBitmap();
        }
    }
}
