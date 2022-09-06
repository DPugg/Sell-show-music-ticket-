using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace Band.Data.Entities
{
    public partial class Ve
    {
        public string MaSoVe { get; set; }
        public int IdShowVsLoaiVe { get; set; }
        public int IdHoaDon { get; set; }
        public HoaDon HoaDon { get; set; }
        public ChiTietLoaiVe ChiTietLoaiVe { get; set; }
        
    }
}