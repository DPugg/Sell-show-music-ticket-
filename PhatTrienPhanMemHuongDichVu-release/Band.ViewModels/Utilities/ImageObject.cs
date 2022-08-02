using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Band.ViewModels.Utilities
{
    public class ImageObject
    {

        public int? IdAnh { get; set; }
        public Image Anh { get; set; }
        public ImageObject(ByteArrayImageObject x) {
            IdAnh = x.IdAnh.Value;
            Anh = x.CovertToImage();
        }
        public ImageObject(Image image)
        {
            this.Anh = image;
        }

        public byte[] CovertToByteArray()
        {
            var handler = new ImageHandler();
            var result = handler.ImageToByteArray(this.Anh);
            return result;
        }
    }
}
