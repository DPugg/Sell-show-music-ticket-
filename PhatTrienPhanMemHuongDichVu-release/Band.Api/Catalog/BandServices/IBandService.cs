using Band.ViewModels.Catalog.Band;
using Band.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Band.Api.Catalog.BandServices
{
    public interface IBandService
    {
        Task<int> Create(BandCreateRequest request);
        BandViewModel Get();
        Task<int> Update(BandUpdateRequest request);
        Task<NewListOfByteArrayImage> GetAllImg();
        Task<int> UpdateLogo(byte[] request);
        Task<int> DeleteImages(List<int> listIdAnh);
        Task<int> AddingImages(List<byte[]> dsAnh);
    }
}
