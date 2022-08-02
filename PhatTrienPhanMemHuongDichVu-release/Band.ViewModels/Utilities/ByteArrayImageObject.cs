using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Band.ViewModels.Utilities
{
    public class ByteArrayImageObject
    {
        public int? IdAnh { get; set; }
        public byte[] Anh { get; set; }
        public ByteArrayImageObject() { }
        public ByteArrayImageObject(ImageObject x)
        {
            IdAnh = x.IdAnh.Value;
            Anh = x.CovertToByteArray();
        }
        public ByteArrayImageObject(int idAnh, byte[] img)
        {
            IdAnh = idAnh;
            Anh = img;
        }
        public Image CovertToImage()
        {
            var handler = new ImageHandler();
            var result= handler._imageConverter.ConvertFrom(this.Anh);
            return (Image)result;
        }
        
    }
}
