using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.Show.Public
{
    public class PublicShowGetAllVm: ShowGetAllViewModel
    {
        public DateTime ThoiDiemMoBan { get; set; }
        public byte[] HinhAnh { get; set; }
        public List<PublicChiTietVeVm> DsLoaiVe { get; set; }

    }
}
