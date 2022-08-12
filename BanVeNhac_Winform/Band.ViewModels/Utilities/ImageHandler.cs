using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Band.ViewModels.Utilities
{
    public class ImageHandler : IImageHandler
    {
        public readonly ImageConverter _imageConverter;
        public ImageHandler()
        {
            _imageConverter = new ImageConverter();
        }
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
