using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Band.Data.Entities
{

    public partial class Show
    {
        public int IdShow { get; set; }
        public string TenShow { get; set; }
        public DateTime ThoiDiemBieuDien { get; set; }
        public DateTime ThoiDiemMoBan { get; set; }
        public string DiaDiem { get; set; }
        public int IdNhom { get; set; }
        public NhomNhac NhomNhac { get; set; }
        public List<ShowVsHinhAnh> DsShowVsHinhAnh { set; get; }
        public List<ChiTietLoaiVe> DsChiTietLoaiVe { set; get; }

    }
}