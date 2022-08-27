using Band.ViewModels.Catalog.VaiTro;
using System;
using System.Collections.Generic;

namespace Band.ViewModels.Catalog.ThanhVien
{
    public class ThanhVienViewModel
    {
        public string NgheDanh { get; set; }

        public string TenKhaiSinh { get; set; }

        public DateTime NgaySinh { get; set; }

        public string QuocTich { get; set; }

        public DateTime DebutDate { get; set; }

        public string TieuSu { get; set; }

        public string Instagram { get; set; }
        public string TrangThai { get; set; }

        public string Twitter { get; set; }
        public byte[] Avatar { get; set; }
        public byte[] Cover { get; set; }
        public List<VaiTroViewModel> DsVaiTro { get; set; }
        /*public List<ThanhVienVsVaiTro> DsThanhVienVsVaiTro { set; get; }
        public List<ThanhVienVsHinhAnh> DsThanhVienVsHinhAnh { set; get; }*/
    }
}