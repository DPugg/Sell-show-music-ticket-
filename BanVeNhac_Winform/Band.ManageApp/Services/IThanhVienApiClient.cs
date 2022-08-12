using Band.ViewModels.Catalog.ThanhVien;
using Band.ViewModels.Catalog.VaiTro;
using Band.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Band.ManageApp.Services
{
    public interface IThanhVienApiClient
    {
        bool CreateThanhVien(ThanhVienCreateRequest request);
        List<ThanhVienGetAllViewModel> GetAll();
        List<VaiTroViewModel> GetAllVaiTro();
        bool UpdateThanhVien(ThanhVienUpdateRequestWithoutVaiTro request);
        bool UpdatePosition(ThanhVienUpdatePositionRequest request);
        ThanhVienViewModel GetById(int idThanhVien);
        bool AddingImages(HinhAnhThanhVienRequest request);
        List<ByteArrayImageObject> GetAllAvatarById(int idThanhVien);
        List<ByteArrayImageObject> GetAllCoverById(int idThanhVien);
        bool DeleteImages(List<int> request);
        bool Delete(int idThanhVien);
    }
}
