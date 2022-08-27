using System;

namespace Band.ViewModels.Catalog.ThanhVien
{
    public class ThanhVienUpdateRequestWithoutVaiTro
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
        public string TrangThai { get; set; }
    }
}