using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.LoaiVe
{
    public class DetailLoaiVeViewModel
    {
        public int IdLoaiVe { get; set; }
        public string ChiTiet { get; set; }
        public override string ToString()
        {
            return ChiTiet;
        }
    }
}
