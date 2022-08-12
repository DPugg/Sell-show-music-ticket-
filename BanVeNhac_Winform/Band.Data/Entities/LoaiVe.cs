using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Band.Data.Entities
{

    public partial class LoaiVe
    {
        public int IdLoaiVe { get; set; }
        public string TenLoai { get; set; }

        public string ChiTiet { get; set; }
        public List<ShowVsLoaiVe> DsShowVsLoaiVe { get; set; }

    }
}