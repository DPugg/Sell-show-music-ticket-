using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Band.Data.Entities
{

    public partial class HinhAnh
    {

        public int IdAnh { get; set; }

        public byte[] Anh { get; set; }
        public int IdLoai { get; set; }
        public LoaiAnh LoaiAnh { get; set; }
        public List<ThanhVienVsHinhAnh> DsThanhVienVsHinhAnh { set; get; }
        public List<ShowVsHinhAnh> DsShowVsHinhAnh { set; get; }


    }
}