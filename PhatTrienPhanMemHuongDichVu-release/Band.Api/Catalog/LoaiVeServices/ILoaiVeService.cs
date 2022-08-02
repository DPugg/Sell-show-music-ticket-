using Band.ViewModels.Catalog.LoaiVe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Band.Api.Catalog.LoaiVeServices
{
    public interface ILoaiVeService
    {
        List<LoaiVeViewModel> GetAll();
    }
}
