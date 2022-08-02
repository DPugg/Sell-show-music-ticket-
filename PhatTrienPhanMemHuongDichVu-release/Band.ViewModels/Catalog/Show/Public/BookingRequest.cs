using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.Show.Public
{
    public class BookingRequest
    {
        public int IdShow { get; set; }
        public int IdLoaiVe { get; set; }
        public int SoLuong { get; set; }
        public string SDT { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
    }
}
