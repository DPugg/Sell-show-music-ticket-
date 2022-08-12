using Band.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.Show
{
    public class ShowStatiscalViewModel
    {
        public int IdShow { get; set; }
        public string TenShow { get; set; }
        public string DiaDiem { get; set; }
        public DateTime ThoiDiemMoBan { get; set; }
        public DateTime ThoiDiemBieuDien { get; set; }
        public List<TicketStatiscalViewModel> DsChiTietLoaiVe { get; set; }
    }
}
