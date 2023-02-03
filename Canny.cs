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

    public class ImageFilter
    {
        private float[,] _filterArray { set; get; }
        public float[,] filterArray
        {
            set
            {
                _filterArray = value;
                filterRows = value.GetLength(0);
                filterColumns = value.GetLength(1);
            }
            get
            {
                return _filterArray;
            }
        }

        public int filterRows { private set; get; }
        public int filterColumns { private set; get; }

        public ImageFilter(float[,] filterArr)
        {
            filterArray = filterArr;
        }

        public Bitmap ApplyTo(Bitmap refImage)
        {
            Bitmap OutputImage = new Bitmap(refImage.Width, refImage.Height);

            for (int x = 0; x < refImage.Width; x++)
            {
                for (int y = 0; y < refImage.Height; y++)
                {
                    float r = 0.0f, g = 0.0f, b = 0.0f;
                    for (int i = 0; i < filterRows; i++)
                    {
                        for (int j = 0; j < filterColumns; j++)
                        {
                            int x2 = x + i - filterRows / 2;
                            int y2 = y + j - filterColumns / 2;
                            if (x2 >= 0 && x2 < refImage.Width && y2 >= 0 && y2 < refImage.Height)
                            {
                                Color pxColor = refImage.GetPixel(x2, y2);
                                r += pxColor.R * filterArray[i, j];
                                g += pxColor.G * filterArray[i, j];
                                b += pxColor.B * filterArray[i, j];
                            }
                        }
                    }
                    OutputImage.SetPixel(x, y, Color.FromArgb((int)r, (int)g, (int)b));
                }
            }

            return OutputImage;
        }

        public int[,] ApplyTo(int[,] refArray)
        {
            int[,] OutputArr = new int[refArray.GetLength(0), refArray.GetLength(1)];

            for (int x = 0; x < refArray.GetLength(0); x++)
            {
                for (int y = 0; y < refArray.GetLength(1); y++)
                {
                    float total = 0.0f;
                    for (int i = 0; i < filterRows; i++)
                    {
                        for (int j = 0; j < filterColumns; j++)
                        {
                            int x2 = x + i - filterRows / 2;
                            int y2 = y + j - filterColumns / 2;
                            if (x2 >= 0 && x2 < refArray.GetLength(0) && y2 >= 0 && y2 < refArray.GetLength(1))
                            {
                                total += refArray[x2, y2] * filterArray[i, j];
                            }
                        }
                    }
                    OutputArr[x, y] = (int)total;
                }
            }

            return OutputArr;
        }

        public int[,] SumApplyTo(Bitmap refImage)
        {
            int[,] OutputArr = new int[refImage.Width, refImage.Height];

            for (int x = 0; x < refImage.Width; x++)
            {
                for (int y = 0; y < refImage.Height; y++)
                {
                    float r = 0.0f, g = 0.0f, b = 0.0f;
                    for (int i = 0; i < filterRows; i++)
                    {
                        for (int j = 0; j < filterColumns; j++)
                        {
                            int x2 = x + i - filterRows / 2;
                            int y2 = y + j - filterColumns / 2;
                            if (x2 >= 0 && x2 < refImage.Width && y2 >= 0 && y2 < refImage.Height)
                            {
                                Color pxColor = refImage.GetPixel(x2, y2);
                                r += pxColor.R * filterArray[i, j];
                                g += pxColor.G * filterArray[i, j];
                                b += pxColor.B * filterArray[i, j];
                            }
                        }
                    }
                    OutputArr[x, y] = (int)((r + g + b) / 3.0f);
                }
            }

            return OutputArr;
        }

        public Color ApplyAt(Bitmap refImage, int x, int y)
        {
            float r = 0.0f, g = 0.0f, b = 0.0f;
            for (int i = 0; i < filterRows; i++)
            {
                for (int j = 0; j < filterColumns; j++)
                {
                    int x2 = x + i - filterRows / 2;
                    int y2 = y + j - filterColumns / 2;
                    if (x2 >= 0 && x2 < refImage.Width && y2 >= 0 && y2 < refImage.Height)
                    {
                        Color pxColor = refImage.GetPixel(x2, y2);
                        r += pxColor.R * filterArray[i, j];
                        g += pxColor.G * filterArray[i, j];
                        b += pxColor.B * filterArray[i, j];
                    }
                }
            }
            return Color.FromArgb((int)r, (int)g, (int)b);
        }

        public int ApplyAt(int[,] refArray, int x, int y)
        {
            float total = 0.0f;
            for (int i = 0; i < filterRows; i++)
            {
                for (int j = 0; j < filterColumns; j++)
                {
                    int x2 = x + i - filterRows / 2;
                    int y2 = y + j - filterColumns / 2;
                    if (x2 >= 0 && x2 < refArray.GetLength(0) && y2 >= 0 && y2 < refArray.GetLength(1))
                    {
                        total += refArray[x2, y2] * filterArray[i, j];
                    }
                }
            }
            return (int)total;
        }

        public int SumApplyAt(Bitmap refImage, int x, int y)
        {
            float r = 0.0f, g = 0.0f, b = 0.0f;
            for (int i = 0; i < filterRows; i++)
            {
                for (int j = 0; j < filterColumns; j++)
                {
                    int x2 = x + i - filterRows / 2;
                    int y2 = y + j - filterColumns / 2;
                    if (x2 >= 0 && x2 < refImage.Width && y2 >= 0 && y2 < refImage.Height)
                    {
                        Color pxColor = refImage.GetPixel(x2, y2);
                        r += pxColor.R * filterArray[i, j];
                        g += pxColor.G * filterArray[i, j];
                        b += pxColor.B * filterArray[i, j];
                    }
                }
            }
            return (int)((r + g + b) / 3.0f);
        }
    }

    public class Canny
    {
        private Bitmap _refImage { set; get; }
        public Bitmap ReferenceImage
        {
            set
            {
                _refImage = value;
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

        public ImageFilter GradientXFilter { set; get; }
        public ImageFilter GradientYFilter { set; get; }

        public Canny(EdgeDetectionMode mode)
        {
            this.mode = mode;
            ReferenceImage = new Bitmap(1, 1);
        }
        public Canny(Bitmap refImage, EdgeDetectionMode mode)
        {
            this.mode = mode;

            ReferenceImage = refImage;
            EdgeDetectThreshold = 128;
        }
        public Canny(Bitmap refImage, int threshold, EdgeDetectionMode mode)
        {
            this.mode = mode;

            ReferenceImage = refImage;
            EdgeDetectThreshold = threshold;
        }
        public Canny(EdgeDetectionMode mode, ImageFilter gradientXFilter, ImageFilter gradientYFilter)
        {
            this.mode = mode;

            EdgeDetectThreshold = 128;

            GradientXFilter = gradientXFilter;
            GradientYFilter = gradientYFilter;
        }
        public Canny(Bitmap refImage, EdgeDetectionMode mode, ImageFilter gradientXFilter, ImageFilter gradientYFilter)
        {
            this.mode = mode;

            ReferenceImage = refImage;
            EdgeDetectThreshold = 128;

            GradientXFilter = gradientXFilter;
            GradientYFilter = gradientYFilter;
        }
        public Canny(Bitmap refImage, int threshold, EdgeDetectionMode mode, ImageFilter gradientXFilter, ImageFilter gradientYFilter)
        {
            this.mode = mode;

            ReferenceImage = refImage;
            EdgeDetectThreshold = threshold;

            GradientXFilter = gradientXFilter;
            GradientYFilter = gradientYFilter;
        }

        private Color GetGrayscaleColor(int level)
        {
            return Color.FromArgb(level, level, level);
        }

        private void GenerateEdgeDetectBitmap()
        {
            if (ReferenceImage != null)
            {
                GradientOutputImage = new Bitmap(_refImage.Width, _refImage.Height);
                ScaledGradientOutputArray = new int[_refImage.Width, _refImage.Height];

                int[,] absolutePixelGradientOutput = new int[_refImage.Width, _refImage.Height];

                int minPixelValue = 0;
                int maxPixelValue = 0;

                switch (mode)
                {
                    case EdgeDetectionMode.RGB:
                        int[,,] absolutePixelGradientX3 = new int[_refImage.Width, _refImage.Height, 3];
                        int[,,] absolutePixelGradientY3 = new int[_refImage.Width, _refImage.Height, 3];

                        for (int x = 0; x < _refImage.Width; x++)
                        {
                            for (int y = 0; y < _refImage.Height; y++)
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    absolutePixelGradientX3[x, y, i] = 0;
                                    absolutePixelGradientY3[x, y, i] = 0;
                                }


                                if ((x == 0) || (x == (_refImage.Width - 1)))
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

                                if ((y == 0) || (y == (_refImage.Height - 1)))
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
                        int[,] absolutePixelGradientX = new int[_refImage.Width, _refImage.Height];
                        int[,] absolutePixelGradientY = new int[_refImage.Width, _refImage.Height];

                        for (int x = 0; x < _refImage.Width; x++)
                        {
                            for (int y = 0; y < _refImage.Height; y++)
                            {
                                absolutePixelGradientX[x, y] = 0;
                                absolutePixelGradientY[x, y] = 0;

                                if ((x == 0) || (x == (_refImage.Width - 1)))
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
                                if ((y == 0) || (y == (_refImage.Height - 1)))
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

                for (int x = 0; x < _refImage.Width; x++)
                {
                    for (int y = 0; y < _refImage.Height; y++)
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
            Bitmap outputImage = new Bitmap(_refImage.Width, _refImage.Height);

            for (int x = 0; x < _refImage.Width; x++)
            {
                for (int y = 0; y < _refImage.Height; y++)
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
