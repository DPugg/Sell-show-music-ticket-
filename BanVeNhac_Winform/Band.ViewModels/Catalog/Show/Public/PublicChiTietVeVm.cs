using Band.ViewModels.Catalog.LoaiVe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.Show.Public
{
    public class PublicChiTietVeVm: LoaiVeViewModel
    {
        public decimal Gia { get; set; }
        public int ConLai { get; set; }
    }
}
