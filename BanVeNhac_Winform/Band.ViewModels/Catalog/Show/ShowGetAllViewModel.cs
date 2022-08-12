using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Catalog.Show
{
    public class ShowGetAllViewModel
    {
        public int IdShow { get; set; }
        public string TenShow { get; set; }
        public DateTime NgayBieuDien { get; set; }
        public string DisplayCombobox
        {
            get
            {
                return NgayBieuDien.Date.ToShortDateString() + "     " + TenShow;
            }
        }
    }
}
