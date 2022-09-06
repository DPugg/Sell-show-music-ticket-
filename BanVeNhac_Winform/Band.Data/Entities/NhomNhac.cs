using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Band.Data.Entities
{
    public partial class NhomNhac
    {
        public int IdNhom { get; set; }
        public string TenNhom { get; set; }

        public DateTime DebutDate { get; set; }

        public string CongTy { get; set; }

        public string ChiTiet { get; set; }

        public string Spotify { get; set; }

        public string AppleMusic { get; set; }

        public string Youtube { get; set; }

        public byte[] Logo { get; set; }
        public List<Show> DsShow { set; get; }
    }
}