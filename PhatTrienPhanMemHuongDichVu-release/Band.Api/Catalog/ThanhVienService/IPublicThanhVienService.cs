using Band.ViewModels.Catalog.ThanhVien.Public;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Band.Api.Catalog.ThanhVienService
{
    public interface IPublicThanhVienService
    {
        Task<List<GetAllThanhVienViewModel>> GetAll();
        Task<GetByIdThanhVienViewModel> GetById(int idThanhVien);

    }
}