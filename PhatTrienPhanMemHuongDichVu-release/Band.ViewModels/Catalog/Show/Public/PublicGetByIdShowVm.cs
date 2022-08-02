using Band.ViewModels.Catalog.Show;
using Band.ViewModels.Catalog.Show.Public;
using System;
using System.Collections.Generic;

namespace Band.Api.Catalog.ShowServices
{
    public class PublicGetByIdShowVm
    {
        public int IdShow { get; set; }
        public string TenShow { get; set; }
        public DateTime ThoiDiemBieuDien { get; set; }
        public DateTime ThoiDiemMoBan { get; set; }
        public string DiaDiem { get; set; }
        public List<PublicChiTietVeVm> DsLoaiVe { get; set; }
        public List<byte[]> DsHinhAnh { get; set; }
    }
}