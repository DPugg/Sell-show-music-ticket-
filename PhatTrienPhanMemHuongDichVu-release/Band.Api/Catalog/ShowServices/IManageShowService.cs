using Band.ViewModels.Catalog.Show;
using Band.ViewModels.Common;
using Band.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Band.Api.Catalog.ShowServices
{
    public interface IManageShowService
    {
        Task<int> Create(ShowCreateRequest request);
        List<ShowGetAllViewModel> GetAll();
        NewListOfByteArrayImage GetAllImgById(int idShow);
        Task<int> AddingImages(ImagesShowAddRequest request);
        Task<ShowViewModel> GetById(int idShow);
        Task<int> UpdateShowInfo(ShowInfoUpdateRequest request);
        Task<int> UpdateTicketInfor(TicketInfoUpdateRequest request);
        Task<int> Delete(int thanhVienId);
        Task<int> DeleteImages(List<int> listIdAnh);
        Task<PageResult<ShowStatiscalViewModel>> GetStatiscalData(StatiscalRequest request);
    }
}
