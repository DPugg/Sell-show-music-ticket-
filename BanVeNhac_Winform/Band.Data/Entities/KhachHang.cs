using System;
using System.Collections.Generic;
using System.Text;

namespace Band.Data.Entities
{
    public class KhachHang
    {
        public string SDT { get; set; }
        public string Email { get; set; }
        public decimal SoDu { get; set; }
        public string TenKhachHang { get; set; }
        public string SoTaiKhoan { get; set; }
        public string NganHang { get; set; }
        public List<HoaDon> DsHoaDon { set; get; }
    }
}
