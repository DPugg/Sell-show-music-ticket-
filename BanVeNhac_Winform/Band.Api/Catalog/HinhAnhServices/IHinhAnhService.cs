using Band.ViewModels.Catalog.Anh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Band.Api.Catalog.HinhAnhServices
{
    interface IHinhAnhService
    {
        Task<int> Create(AnhCreateRequest request);

        Task<int> Update(AnhCreateRequest request);

        Task<int> Delete(int thanhVienId);
    }
}
