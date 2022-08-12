using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.Show
{
    public class ImagesShowAddRequest
    {
        public int IdShow { get; set; }
        public int IdLoai { get; set; }
        public List<byte[]> DsAnh { get; set; }
    }
}
