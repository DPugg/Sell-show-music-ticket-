using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.Show
{
    public class ShowInfoUpdateRequest
    {
        public int IdShow { get; set; }
        public string TenShow { get; set; }
        public DateTime NgayBieuDien { get; set; }
        public DateTime GioBieuDien { get; set; }
        public DateTime NgayMoBan { get; set; }
        public DateTime GioMoBan { get; set; }
        public string DiaDiem { get; set; }
        public int IdNhom { get; set; }
    }
}
