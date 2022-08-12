using Band.ViewModels.Catalog.ThanhVien;
using Band.ViewModels.Common;
using Band.ViewModels.Utilities;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace Band.Api.Catalog.ThanhVienService
{
    public interface IManageThanhVienService
    {
        Task<int> Create(ThanhVienCreateRequest request);

        Task<int> Update(ThanhVienUpdateRequestWithoutVaiTro request);
        Task<int> UpdatePosition(ThanhVienUpdatePositionRequest request);

        Task<int> Delete(int thanhVienId);

        Task<PageResult<ThanhVienViewModel>> GetAllPaging(GetThanhVienPagingRequest request);
        Task<ThanhVienViewModel> GetById(int idThanhVien);
        Task<List<ThanhVienGetAllViewModel>> GetAll();
        Task<int> AddingImages(HinhAnhThanhVienRequest request);
        Task<NewListOfByteArrayImage> GetAllAvatarById(int idThanhVien);
        Task<List<ThanhVienVsHinhAnhViewModel>> GetThanhVienVsHinhAnh();
        Task<int> DeleteImages(List<int> listIdAnh);
        Task<NewListOfByteArrayImage> GetAllCoverById(int idThanhVien);
    }
}