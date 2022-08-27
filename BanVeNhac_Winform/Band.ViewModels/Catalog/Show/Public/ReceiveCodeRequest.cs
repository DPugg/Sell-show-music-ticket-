using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.Show.Public
{
    public class ReceiveCodeRequest
    {
        public string email { get; set; }
        public string MaXacNhan {get; set;}
        public decimal TotalCost { get; set; }
    }
}
