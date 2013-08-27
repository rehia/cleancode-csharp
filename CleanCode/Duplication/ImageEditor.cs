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
            if (Math.Abs(desiredDimension - _image.Width) < 0.01f)
                return;

            float scalingFactor = desiredDimension / _image.Width;
            scalingFactor = (float)(Math.Floor(scalingFactor * 100) * 0.01f);

            Image scaledImage = ImageUtilities.GetScaledImage(_image, scalingFactor);

            _image.Dispose();
            GC.Collect();
            _image = scaledImage;
        }

        public void Rotate(int degrees)
        {
            Image rotatedImage = ImageUtilities.GetRotatedImage(_image, degrees);

            _image.Dispose();
            GC.Collect();
            _image = rotatedImage;
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
