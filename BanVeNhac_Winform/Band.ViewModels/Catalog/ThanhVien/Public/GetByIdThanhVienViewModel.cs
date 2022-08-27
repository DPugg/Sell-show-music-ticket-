using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.ThanhVien.Public
{
    public class GetByIdThanhVienViewModel
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
        public List<byte[]> Avatars { get; set; }
        public List<byte[]> Covers { get; set; }
        public List<string> DsVaiTro { get; set; }
    }
}
