using System;
using System.Collections.Generic;

namespace Band.Data.Entities
{
    public class ThanhVien
    {
        public int IdThanhVien { get; set; }

        public string NgheDanh { get; set; }

        public string TenKhaiSinh { get; set; }

        public DateTime NgaySinh { get; set; }

        public string QuocTich { get; set; }

        public DateTime DebutDate { get; set; }

        public string TieuSu { get; set; }

        public string Instagram { get; set; }

        public string Twitter { get; set; }
        public List<ThanhVienVsVaiTro> DsThanhVienVsVaiTro { set; get; }
        public List<ThanhVienVsHinhAnh> DsThanhVienVsHinhAnh { set; get; }
    }
}