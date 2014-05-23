using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;

namespace CleanCode.Duplication
{
    public class ImageEditor
    {
        private Image _image;

        public ImageEditor(Image image)
        {
            this._image = image;
        }

        public void ScaleToOneDimension(float desiredDimension)
        {
            if (isTooCloseToImageWidth(desiredDimension))
                return;

            float scalingFactor = CalculateScalingFactor(desiredDimension);

            Image scaledImage = ScaleImage(scalingFactor);

            ReplaceImage(scaledImage);
        }

        private System.Drawing.Image ScaleImage(float scalingFactor)
        {
            return ImageUtilities.GetScaledImage(_image, scalingFactor);
        }

        private float CalculateScalingFactor(float desiredDimension)
        {
            float scalingFactor = desiredDimension / _image.Width;
            scalingFactor = TruncateTo2Digits(scalingFactor);
            return scalingFactor;
        }

        private static float TruncateTo2Digits(float number)
        {
            return (float)(Math.Floor(number * 100) * 0.01f);
        }

        private bool isTooCloseToImageWidth(float desiredDimension)
        {
            return Math.Abs(desiredDimension - _image.Width) < 0.01f;
        }

        private void ReplaceImage(Image transformedImage)
        {
            _image.Dispose();
            GC.Collect();
            _image = transformedImage;
        }

        public void Rotate(int degrees)
        {
            Image rotatedImage = ImageUtilities.GetRotatedImage(_image, degrees);

            ReplaceImage(rotatedImage);
        }

        public Image Image
        {
            get { return _image; }
        }
    }

    public class ImageUtilities
    {
        public static Image GetScaledImage(Image image, float scalingFactor)
        {
            return new Bitmap(image, ScaleDimension(image.Width, scalingFactor), ScaleDimension(image.Height, scalingFactor));
        }

        private static int ScaleDimension(int dimension, float scalingFactor)
        {
            return (int)Math.Round(dimension * scalingFactor);
        }

        public static Image GetRotatedImage(Image image, int degrees)
        {
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return new Bitmap(image);
        }
    }
}
