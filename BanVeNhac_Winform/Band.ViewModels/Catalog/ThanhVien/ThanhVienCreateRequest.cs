using System;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace Band.ViewModels.Catalog.ThanhVien
{
    public class ThanhVienCreateRequest
    {
        public string NgheDanh { get; set; }
        public string TenKhaiSinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string QuocTich { get; set; }
        public DateTime DebutDate { get; set; }
        public string TieuSu { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public List<byte[]> DsAvatar { get; set; }
        public List<byte[]> DsCover { get; set; }
        public List<int>? DsIdVaiTro { get; set; }
        public List<string>? DsVaiTroMoi { get; set; }
    }
}