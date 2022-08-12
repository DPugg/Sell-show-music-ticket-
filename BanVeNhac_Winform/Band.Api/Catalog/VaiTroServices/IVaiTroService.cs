using Band.ViewModels.Catalog.VaiTro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Band.Api.Catalog.VaiTroServices
{
    public interface IVaiTroService
    {
        Task<int> Create(VaiTroCreateRequest request);
        List<VaiTroViewModel> GetAll();
    }
}
