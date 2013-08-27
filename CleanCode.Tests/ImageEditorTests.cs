using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using CleanCode.Duplication;
using NUnit.Framework;

namespace CleanCode.Tests
{
    [TestFixture]
    public class ImageEditorTests
    {
        private ImageEditor _imageEditor;

        [SetUp]
        public void SetUp()
        {
            var image = new Bitmap(15, 30);
            _imageEditor = new ImageEditor(image);
        }

        [Test]
        public void ShouldNotScaleImageWhenSameSize()
        {
            GivenIHaveAnImage();

            WhenIScaleImageWidthTo(14.999f);

            ThenTheImageWidthIs(15);
        }

        [Test]
        public void ShouldScaleImageWhenNotSameSize()
        {
            GivenIHaveAnImage();

            WhenIScaleImageWidthTo(5);

            ThenTheImageWidthIs(5).AndTheHeightIs(10);
        }

        [Test]
        public void ShouldRotateImage()
        {
            _imageEditor.Rotate(90);

            Assert.That(_imageEditor.Image.Width, Is.EqualTo(30));
        }

        private void GivenIHaveAnImage()
        {
            
        }

        private ThenImage ThenTheImageWidthIs(int expectedWidth)
        {
            Assert.That(_imageEditor.Image.Width, Is.EqualTo(expectedWidth));
            return new ThenImage(_imageEditor);
        }

        private void WhenIScaleImageWidthTo(float desiredWidth)
        {
            _imageEditor.ScaleToOneDimension(desiredWidth);
        }
    }

    internal class ThenImage
    {
        private readonly ImageEditor _imageEditor;

        public ThenImage(ImageEditor imageEditor)
        {
            _imageEditor = imageEditor;
        }

        public void AndTheHeightIs(int expectedHeight)
        {
            Assert.That(_imageEditor.Image.Height, Is.EqualTo(expectedHeight));
        }
    }
}
