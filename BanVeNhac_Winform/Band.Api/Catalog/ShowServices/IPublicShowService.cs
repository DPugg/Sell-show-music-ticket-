using Band.ViewModels.Catalog.Show.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Band.Api.Catalog.ShowServices
{
    public interface IPublicShowService
    {
        Task<List<PublicShowGetAllVm>> GetAll();
        Task<PublicGetByIdShowVm> GetById(int idShow);
        Task<int> Booking(BookingRequest request);
        Task<int> ReceiveCode(ReceiveCodeRequest request);
        Task<HoaDonVm> GetHoaDonById(int idHoaDon);
    }
}
