using System;

namespace Band.ViewModels.Catalog.Band
{
    public class BandViewModel : BandUpdateRequest
    {
        public byte[] Logo { get; set; } 
        public byte[] Image { get; set; }
    }
}