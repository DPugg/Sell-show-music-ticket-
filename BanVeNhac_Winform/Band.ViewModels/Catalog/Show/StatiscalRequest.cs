using Band.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.Show
{
    public class StatiscalRequest : PagingRequestBase
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
