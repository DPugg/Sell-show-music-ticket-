using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Band.Data.Entities
{
    public partial class LoaiAnh
    {

        public int IdLoai { get; set; }
        public string Loai { get; set; }
        public List<HinhAnh> DsHinhAnh { set; get; }
    }
}