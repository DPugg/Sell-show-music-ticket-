using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.Show
{
    public class ShowViewModel
    {
        public string TenShow { get; set; }
        public DateTime ThoiDiemBieuDien { get; set; }
        public DateTime ThoiDiemMoBan { get; set; }
        public string DiaDiem { get; set; }
        public byte[] HinhAnh { get; set; }
        public List<ChiTietVeViewModel> DsChiTietLoaiVe { get; set; }
    }
}
