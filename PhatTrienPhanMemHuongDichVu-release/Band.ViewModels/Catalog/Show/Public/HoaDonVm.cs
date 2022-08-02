using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.Show.Public
{
    public class HoaDonVm
    {
        public int IdHoaDon { get; set; }

        public int SoLuong { get; set; }
        public string SDT { get; set; }
        public DateTime NgayGiaoDich { get; set; }
        public string TenShow { get; set; }
        public DateTime ThoiDiemBieuDien { get; set; }
        public string DiaDiem { get; set; }
        public string TenLoai { get; set; }
        public decimal Gia { get; set; }
        public List<string> DsMaSoVe { get; set; }
    }
}
