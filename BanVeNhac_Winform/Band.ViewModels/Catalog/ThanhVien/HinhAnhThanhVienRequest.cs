using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.ThanhVien
{
    public class HinhAnhThanhVienRequest
    {
        public int IdThanhVien { get; set; }
        public int IdLoai { get; set; }
        public List<byte[]> DsAnh { get; set; }

    }
}
