using System;
using System.Collections.Generic;
using System.Text;

namespace Band.Data.Entities
{
    public class ThanhVienVsHinhAnh
    {
        public int IdThanhVien { get; set; }
        public ThanhVien ThanhVien { get; set; }
        public int IdAnh { get; set; }
        public HinhAnh HinhAnh { get; set; }

    }
}
