using System.Collections.Generic;

namespace Band.ViewModels.Common
{
    public class PageResult<T>
    {
        public int TotalRecord { get; set; }
        public List<T> List { get; set; }
    }
}