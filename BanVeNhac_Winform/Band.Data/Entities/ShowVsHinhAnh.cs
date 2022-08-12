using System;
using System.Collections.Generic;
using System.Text;

namespace Band.Data.Entities
{
    public class ShowVsHinhAnh
    {
        public int IdShow { get; set; }
        public Show Show { set; get; }
        public int IdAnh { get; set; }
        public HinhAnh HinhAnh { get; set; }
    }
}
