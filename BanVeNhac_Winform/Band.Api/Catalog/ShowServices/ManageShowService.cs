using Band.Data.EF;
using Band.Data.Entities;
using Band.ViewModels.Catalog.Show;
using Band.ViewModels.Common;
using Band.ViewModels.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Band.ViewModels.Utilities.SystemConstants;

namespace Band.Api.Catalog.ShowServices
{
    public class ManageShowService : IManageShowService
    {
        private readonly BandDbContext _context;


        public ManageShowService(BandDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddingImages(ImagesShowAddRequest request)
        {
            List<HinhAnh> dsHinhAnh = new List<HinhAnh>();
            /*List<ThanhVienVsHinhAnh> dsThanhVienVsHinhAnh = new List<ThanhVienVsHinhAnh>();*/
            foreach (byte[] img in request.DsAnh)
            {
                dsHinhAnh.Add(new HinhAnh()
                {
                    Anh = img,
                    IdLoai = request.IdLoai
                });
            }
            List<ShowVsHinhAnh> dsShowVsHinhAnh = new List<ShowVsHinhAnh>();
            foreach (var img in dsHinhAnh)
            {
                ShowVsHinhAnh showVsHinhAnh = new ShowVsHinhAnh()
                {
                    HinhAnh = img,
                    IdShow = request.IdShow
                };
                dsShowVsHinhAnh.Add(showVsHinhAnh);
            }
            await _context.HinhAnhDbo.AddRangeAsync(dsHinhAnh);
            await _context.ShowVsHinhAnhDbo.AddRangeAsync(dsShowVsHinhAnh);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ShowCreateRequest request)
        {
            //Thêm hình ảnh vào bảng hình ảnh trước
            List<HinhAnh> dsHinhAnh = new List<HinhAnh>();
            foreach (byte[] img in request.DsHinhAnh)
            {
                dsHinhAnh.Add(new HinhAnh()
                {
                    Anh = img,
                    IdLoai = (int)ImageType.IMG_SHOW
                });
            }
            /*var show = new Show();
            show.DiaDiem = request.DiaDiem;
            show.TenShow = request.TenShow;
            show.ThoiDiemBieuDien = request.NgayBieuDien.Date.Add(request.GioBieuDien.TimeOfDay);
            show.DsShowVsHinhAnh = new List<ShowVsHinhAnh>();
            show.DsShowVsLoaiVe = new List<ShowVsLoaiVe>();*/
            var show = new Show()
            {
                DiaDiem = request.DiaDiem,
                TenShow = request.TenShow,
                ThoiDiemBieuDien = request.NgayBieuDien.Date.Add(request.GioBieuDien.TimeOfDay),
                ThoiDiemMoBan = request.NgayMoBan.Date.Add(request.GioMoBan.TimeOfDay),
                DsShowVsHinhAnh = new List<ShowVsHinhAnh>(),
                DsShowVsLoaiVe = new List<ShowVsLoaiVe>()
            };
            foreach (var img in dsHinhAnh)
            {
                ShowVsHinhAnh showVsHinhAnh = new ShowVsHinhAnh()
                {
                    HinhAnh = img,
                    Show = show
                };
                show.DsShowVsHinhAnh.Add(showVsHinhAnh);
            }
            foreach (var vt in request.DsChiTietLoaiVe)
            {
                ShowVsLoaiVe showVsLoaiVe = new ShowVsLoaiVe()
                {
                    Show=show,
                    IdLoaiVe=vt.IdLoaiVe,
                    Gia=vt.Gia,
                    SoLuongBanRa=vt.SoLuongBanRa,
                    ConLai=vt.SoLuongBanRa
                };
                show.DsShowVsLoaiVe.Add(showVsLoaiVe);
            }
            await _context.HinhAnhDbo.AddRangeAsync(dsHinhAnh);
            await _context.ShowDbo.AddAsync(show);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int idShow)
        {
            var dsHoaDon = await(from sl in _context.ShowVsLoaiVeDbo
                                 join h in _context.HoaDonDbo on sl.IdShowVsLoaiVe equals h.IdShowVsLoaiVe
                                 where sl.IdShow.Equals(idShow)
                                 select sl).ToListAsync();
            if (dsHoaDon.Count > 0) return -1;

            /*await _context.ThanhVienDbo.FindAsync(thanhVienId);*/
            var dsShowVsHinhAnhFromDb = await(from s in _context.ShowVsHinhAnhDbo
                                        where s.IdShow.Equals(idShow)
                                        select s).ToListAsync();
            var dsHinhAnhFromDb = new List<HinhAnh>();
            foreach(var x in dsShowVsHinhAnhFromDb)
            {
                dsHinhAnhFromDb.Add(await _context.HinhAnhDbo.FindAsync(x.IdAnh));
            }
            var dsChiTietVeFromDb= await (from s in _context.ShowVsLoaiVeDbo
                                          where s.IdShow.Equals(idShow)
                                          select s).ToListAsync();
            var show = await _context.ShowDbo.FindAsync(idShow);
            /*            if (thanhVien == null) throw*/
            _context.ShowDbo.Remove(show);
            _context.ShowVsHinhAnhDbo.RemoveRange(dsShowVsHinhAnhFromDb);
            _context.HinhAnhDbo.RemoveRange(dsHinhAnhFromDb);
            _context.ShowVsLoaiVeDbo.RemoveRange(dsChiTietVeFromDb);
            return await _context.SaveChangesAsync();
        }

        public List<ShowGetAllViewModel> GetAll()
        {
            var dsShow = _context.ShowDbo.Where(p => p.ThoiDiemBieuDien > DateTime.Now).Select(p => new { p.IdShow, p.TenShow, p.ThoiDiemBieuDien }).ToList();
/*            _context.ShowDbo.Where(p => p.ThoiDiemBieuDien > DateTime.Now).Select(p => new { p.IdShow, p.TenShow, p.ThoiDiemBieuDien}).ToList();
*/            List<ShowGetAllViewModel> dsShowVm = new List<ShowGetAllViewModel>();
            foreach (var x in dsShow)
            {
                dsShowVm.Add(new ShowGetAllViewModel()
                {
                    IdShow=x.IdShow,
                    TenShow=x.TenShow,
                    NgayBieuDien=x.ThoiDiemBieuDien.Date
                });
            }
            return dsShowVm;
        }

        public NewListOfByteArrayImage GetAllImgById(int idShow)
        {
            var dsHinhAnhFromDb = (from sa in _context.ShowVsHinhAnhDbo
                                   join a in _context.HinhAnhDbo on sa.IdAnh equals a.IdAnh
                                   where sa.IdShow.Equals(idShow) && a.IdLoai.Equals((int)ImageType.IMG_SHOW)
                                   select a).ToList();
            var result = new NewListOfByteArrayImage();
            foreach (var x in dsHinhAnhFromDb)
            {
                result.Add(new ByteArrayImageObject(x.IdAnh, x.Anh));
            }
            return result;
        }

        public async Task<ShowViewModel> GetById(int idShow)
        {
            var show = await _context.ShowDbo.FindAsync(idShow);
            var imgFromDb = await(from s in _context.ShowDbo
                                     join sa in _context.ShowVsHinhAnhDbo on s.IdShow equals sa.IdShow
                                     join a in _context.HinhAnhDbo on sa.IdAnh equals a.IdAnh
                                     where s.IdShow.Equals(idShow) && a.IdLoai.Equals((int)ImageType.IMG_SHOW)
                                     select a.Anh).FirstOrDefaultAsync();

            var dsChiTietVeFromDb = await(from l in _context.LoaiVeDbo
                                       join sl in _context.ShowVsLoaiVeDbo on l.IdLoaiVe equals sl.IdLoaiVe
                                       where sl.IdShow.Equals(idShow)
                                       select new { l.IdLoaiVe, sl.Gia, sl.SoLuongBanRa }).ToListAsync();
            var dsChiTietVe = new List<ChiTietVeViewModel>();
            foreach (var x in dsChiTietVeFromDb)
            {
                dsChiTietVe.Add(new ChiTietVeViewModel()
                {
                    IdLoaiVe=x.IdLoaiVe,
                    Gia=x.Gia,
                    SoLuongBanRa=x.SoLuongBanRa
                });
            }
            /*ShowViewModel showVm = new ShowViewModel();
            showVm.DiaDiem = show.DiaDiem;
            showVm.HinhAnh = imgFromDb;
            showVm.TenShow = show.TenShow;
            showVm.ThoiDiemBieuDien = show.ThoiDiemBieuDien;
            showVm.ThoiDiemMoBan = show.ThoiDiemMoBan;
            showVm.DsChiTietLoaiVe = dsChiTietVe;*/
            ShowViewModel showVm = new ShowViewModel()
            {
                DiaDiem = show.DiaDiem,
                HinhAnh = imgFromDb,
                TenShow = show.TenShow,
                ThoiDiemBieuDien = show.ThoiDiemBieuDien,
                ThoiDiemMoBan = show.ThoiDiemMoBan,
                DsChiTietLoaiVe = dsChiTietVe,                
            };
            return showVm;
        }

        public async Task<int> UpdateShowInfo(ShowInfoUpdateRequest request)
        {
            var show = await _context.ShowDbo.FindAsync(request.IdShow);
            show.TenShow = request.TenShow;
            show.ThoiDiemBieuDien = request.NgayBieuDien.Date.Add(request.GioBieuDien.TimeOfDay);
            show.ThoiDiemMoBan = request.NgayMoBan.Date.Add(request.GioMoBan.TimeOfDay);
            show.DiaDiem = request.DiaDiem;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateTicketInfor(TicketInfoUpdateRequest request)
        {
            var dsShowVsLoaiVe = await (from sl in _context.ShowVsLoaiVeDbo
                                         where sl.IdShow.Equals(request.IdShow)
                                         select sl).ToListAsync();

            foreach(var x in dsShowVsLoaiVe)
            {
                if (_context.HoaDonDbo.Any(hd => hd.IdShowVsLoaiVe == x.IdShowVsLoaiVe)) return -1;
            }

            var dsChiTietVe = new List<ShowVsLoaiVe>();
            foreach(var x in request.dsChiTietVe)
            {
                dsChiTietVe.Add(new ShowVsLoaiVe()
                {
                    IdShow = request.IdShow,
                    Gia = x.Gia,
                    IdLoaiVe = x.IdLoaiVe,
                    SoLuongBanRa = x.SoLuongBanRa,
                    ConLai=x.SoLuongBanRa
                });
            }
            
            _context.ShowVsLoaiVeDbo.RemoveRange(dsShowVsLoaiVe);
            await _context.ShowVsLoaiVeDbo.AddRangeAsync(dsChiTietVe);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteImages(List<int> listIdAnh)
        {
            var dsHinhAnh = new List<HinhAnh>();
            foreach (var i in listIdAnh)
            {
                dsHinhAnh.Add(await _context.HinhAnhDbo.FindAsync(i));
            }

            var dsShowVsHinhAnh = new List<ShowVsHinhAnh>();
            foreach (var i in listIdAnh)
            {
                dsShowVsHinhAnh.Add((from h in _context.ShowVsHinhAnhDbo
                                          where h.IdAnh.Equals(i)
                                          select h).FirstOrDefault());
            }
            _context.ShowVsHinhAnhDbo.RemoveRange(dsShowVsHinhAnh);
            _context.HinhAnhDbo.RemoveRange(dsHinhAnh);
            return await _context.SaveChangesAsync();
        }

        public async Task<PageResult<ShowStatiscalViewModel>> GetStatiscalData(StatiscalRequest request)
        {
            var query = _context.ShowDbo.Where(p => p.ThoiDiemBieuDien > request.FromDate
                            && p.ThoiDiemBieuDien < request.ToDate).
                            Select(p => new { p.IdShow, p.TenShow, p.ThoiDiemBieuDien, p.ThoiDiemMoBan, p.DiaDiem });

            int totalRow = await query.CountAsync();
            var dsShow = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ShowStatiscalViewModel()
                {
                    IdShow = x.IdShow,
                    TenShow = x.TenShow,
                    DiaDiem=x.DiaDiem,
                    ThoiDiemMoBan=x.ThoiDiemMoBan,
                    ThoiDiemBieuDien = x.ThoiDiemBieuDien,
                    DsChiTietLoaiVe=new List<TicketStatiscalViewModel>()
                }).ToListAsync();

            foreach(var x in dsShow)
            {
                var dsVe = await _context.ShowVsLoaiVeDbo.Where(p => p.IdShow.Equals(x.IdShow)).ToListAsync();
                foreach(var y in dsVe)
                {
                    x.DsChiTietLoaiVe.Add(new TicketStatiscalViewModel()
                    {
                        Gia = y.Gia,
                        ConLai = y.ConLai,
                        SoLuongBanRa = y.SoLuongBanRa
                    });
                }
            }

            var pageResult = new PageResult<ShowStatiscalViewModel>()
            {
                TotalRecord = totalRow,
                List = dsShow
            };
            return pageResult;
        }
    }
}
