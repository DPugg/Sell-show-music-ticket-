using System;
using System.Collections.Generic;
using System.Text;

namespace Band.Data.Entities
{
    public class ThanhVienVsVaiTro
    {
        public int IdThanhVien { get; set; }
        public ThanhVien ThanhVien { set; get; }
        public int IdVaiTro { get; set; }
        public VaiTro VaiTro { set; get; }
    }
}
