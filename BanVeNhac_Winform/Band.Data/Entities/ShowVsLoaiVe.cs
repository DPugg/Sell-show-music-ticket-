using System;
using System.Collections.Generic;
using System.Text;

namespace Band.Data.Entities
{
    public class ShowVsLoaiVe
    {
        public int IdShow { get; set; }
        public Show Show { get; set; }
        public int IdLoaiVe { get; set; }
        public LoaiVe LoaiVe { get; set; }
        public decimal Gia { get; set; }
        public int SoLuongBanRa { get; set; }
        public int ConLai { get; set; }
        public int IdShowVsLoaiVe { get; set; }
        public List<HoaDon> DsHoaDon { get; set; }

    }
}
