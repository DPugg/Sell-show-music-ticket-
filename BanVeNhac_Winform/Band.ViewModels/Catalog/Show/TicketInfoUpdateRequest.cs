using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.Show
{
    public class TicketInfoUpdateRequest
    {
        public int IdShow { get; set; }
        public List<ChiTietVeViewModel> dsChiTietVe { get; set; }

    }
}
