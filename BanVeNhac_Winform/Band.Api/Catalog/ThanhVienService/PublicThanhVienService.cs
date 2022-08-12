using Band.Data.EF;
using Band.ViewModels.Catalog.ThanhVien.Public;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Band.ViewModels.Utilities.SystemConstants;

namespace Band.Api.Catalog.ThanhVienService
{
    public class PublicThanhVienService : IPublicThanhVienService
    {
        private readonly BandDbContext _context;


        public PublicThanhVienService(BandDbContext context)
        {
            _context = context;
        }
        public async Task<List<GetAllThanhVienViewModel>> GetAll()
        {
            var dsThanhVien = await _context.ThanhVienDbo.Select(p => new { p.IdThanhVien, p.NgheDanh }).ToListAsync();
            List<GetAllThanhVienViewModel> dsThanhVienVm = new List<GetAllThanhVienViewModel>();
            foreach (var x in dsThanhVien)
            {
                var hinhAnhFromDb = await (from t in _context.ThanhVienDbo
                                             join ta in _context.ThanhVienVsHinhAnhDbo on t.IdThanhVien equals ta.IdThanhVien
                                             join a in _context.HinhAnhDbo on ta.IdAnh equals a.IdAnh
                                             where t.IdThanhVien.Equals(x.IdThanhVien) && a.IdLoai.Equals((int)ImageType.AVATAR_MEM)
                                             select a.Anh).FirstOrDefaultAsync();
                dsThanhVienVm.Add(new GetAllThanhVienViewModel()
                {
                    IdThanhVien = x.IdThanhVien,
                    NgheDanh = x.NgheDanh,
                    Avatar= hinhAnhFromDb
                });
            }
            return dsThanhVienVm;
        }

        public async Task<GetByIdThanhVienViewModel> GetById(int idThanhVien)
        {
            var thanhVien = await _context.ThanhVienDbo.FindAsync(idThanhVien);
            if (thanhVien == null) return null;
            var avatarsFromDb = await(from t in _context.ThanhVienDbo
                                     join ta in _context.ThanhVienVsHinhAnhDbo on t.IdThanhVien equals ta.IdThanhVien
                                     join a in _context.HinhAnhDbo on ta.IdAnh equals a.IdAnh
                                     where t.IdThanhVien.Equals(idThanhVien) && a.IdLoai.Equals((int)ImageType.AVATAR_MEM)
                                     select a.Anh).ToListAsync();
            var coversFromDb = await(from t in _context.ThanhVienDbo
                                    join ta in _context.ThanhVienVsHinhAnhDbo on t.IdThanhVien equals ta.IdThanhVien
                                    join a in _context.HinhAnhDbo on ta.IdAnh equals a.IdAnh
                                    where t.IdThanhVien.Equals(idThanhVien) && a.IdLoai.Equals((int)ImageType.COVER_MEM)
                                    select a.Anh).ToListAsync();

            /*var dsHinhAnh = new List<byte[]>();
            foreach (var x in dsHinhAnhFromDb)
            {
                dsHinhAnh.Add(new byte[]()
                {
                    IdVaiTro = x.IdVaiTro,
                    TenVaiTro = x.TenVaiTro
                });
            }*/

            var dsVaiTroFromDb = await(from t in _context.ThanhVienDbo
                                       join tv in _context.ThanhVienVsVaiTroDbo on t.IdThanhVien equals tv.IdThanhVien
                                       join v in _context.VaiTroDbo on tv.IdVaiTro equals v.IdVaiTro
                                       where t.IdThanhVien.Equals(idThanhVien)
                                       select v.TenVaiTro).ToListAsync();
            /*var dsVaiTro = new List<string>();
            foreach (var x in dsVaiTroFromDb)
            {
                dsVaiTro.Add(x);
            }*/
            GetByIdThanhVienViewModel thanhVienVm = new GetByIdThanhVienViewModel()
            {
                DebutDate = thanhVien.DebutDate,
                DsVaiTro = dsVaiTroFromDb,
                Avatars = avatarsFromDb,
                Covers = coversFromDb,
                Instagram = thanhVien.Instagram,
                NgaySinh = thanhVien.NgaySinh,
                NgheDanh = thanhVien.NgheDanh,
                QuocTich = thanhVien.QuocTich,
                TenKhaiSinh = thanhVien.TenKhaiSinh,
                TieuSu = thanhVien.TieuSu,
                Twitter = thanhVien.Twitter
            };
            return thanhVienVm;
        }
    }
}