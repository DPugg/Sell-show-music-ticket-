using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Band.Data.Entities
{

    public partial class HoaDon
    {
        public int IdHoaDon { get; set; }

        public int SoLuong { get; set; }
        public string SDT { get; set; }
        public DateTime NgayGiaoDich { get; set; }
        public KhachHang KhachHang { get; set; }
        public List<Ve> DsVe  { set; get; }
        

    }
}