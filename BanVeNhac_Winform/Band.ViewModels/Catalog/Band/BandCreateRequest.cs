using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.Band
{
    public class BandCreateRequest:BandUpdateRequest
    {
        public byte[] Logo { get; set; }
        public List<byte[]> ImageList { get; set; }
    }
}
