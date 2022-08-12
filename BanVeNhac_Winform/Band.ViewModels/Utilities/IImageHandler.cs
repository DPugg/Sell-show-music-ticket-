using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Band.ViewModels.Utilities
{
    public interface IImageHandler
    {
        byte[] ImageToByteArray(Image imageIn);
    }
}
