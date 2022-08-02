using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.ThanhVien
{
    public class ThanhVienUpdatePositionRequest
    {
        public int IdThanhVien { get; set; }
        public List<int>? DsIdVaiTro { get; set; }
        public List<string>? DsVaiTroMoi { get; set; }
    }
}
