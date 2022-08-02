using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Band.Data.Entities
{
    public partial class VaiTro
    {
        public int IdVaiTro { get; set; }

        public string TenVaiTro { get; set; }
        public List<ThanhVienVsVaiTro> DsThanhVienVsVaiTro { set; get; }
    }
}