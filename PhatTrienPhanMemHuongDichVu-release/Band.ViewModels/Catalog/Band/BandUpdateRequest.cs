using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.Band
{
    public class BandUpdateRequest
    {
        public string TenNhom { get; set; }

        public DateTime DebutDate { get; set; }

        public string CongTy { get; set; }

        public string ChiTiet { get; set; }

        public string Spotify { get; set; }

        public string AppleMusic { get; set; }

        public string Youtube { get; set; }
    }
}
