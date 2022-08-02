using Band.Data.EF;
using Band.Data.Entities;
using Band.ViewModels.Catalog.Show.Public;
using Band.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static Band.ViewModels.Utilities.SystemConstants;

namespace Band.Api.Catalog.ShowServices
{
    public class PublicShowService : IPublicShowService
    {
        private readonly BandDbContext _context;


        public PublicShowService(BandDbContext context)
        {
            _context = context;
        }
        public async Task<List<PublicShowGetAllVm>> GetAll()
        {
            var dsShow = await _context.ShowDbo.Where(p => p.ThoiDiemBieuDien > DateTime.Now 
                            && p.ThoiDiemBieuDien < DateTime.Now.AddMonths(1)).
                            Select(p => new { p.IdShow, p.TenShow, p.ThoiDiemBieuDien, p.ThoiDiemMoBan }).ToListAsync();
            var dsShowVm = new List<PublicShowGetAllVm>();
            var count = (dsShow.Count>3)? 3: dsShow.Count;
            for(int i=0; i<count; i++)
            {
                var hinhAnhFromDb = (from sa in _context.ShowVsHinhAnhDbo
                                          join a in _context.HinhAnhDbo on sa.IdAnh equals a.IdAnh
                                            where sa.IdShow.Equals(dsShow[i].IdShow) && a.IdLoai.Equals((int)ImageType.IMG_SHOW)
                                            select a.Anh).FirstOrDefault();
/*                var imgList = new List<byte[]>();
                foreach (var i in dsHinhAnhFromDb)
                {
                    imgList.Add(i);
                }*/
                dsShowVm.Add(new PublicShowGetAllVm()
                {
                    IdShow = dsShow[i].IdShow,
                    TenShow = dsShow[i].TenShow,
                    NgayBieuDien = dsShow[i].ThoiDiemBieuDien.Date,
                    ThoiDiemMoBan= dsShow[i].ThoiDiemMoBan,
                    HinhAnh= hinhAnhFromDb
                });
            }

            return dsShowVm;
        }

        public async Task<PublicGetByIdShowVm> GetById(int idShow)
        {
            var show = await _context.ShowDbo.FindAsync(idShow);
            if (show == null) return null;
            var dsHinhAnhFromDb = await (from sa in _context.ShowVsHinhAnhDbo
                                   join a in _context.HinhAnhDbo on sa.IdAnh equals a.IdAnh
                                   where sa.IdShow.Equals(idShow) && a.IdLoai.Equals((int)ImageType.IMG_SHOW)
                                   select a.Anh).ToListAsync();

            var dsChiTietVeFromDb = await (from l in _context.LoaiVeDbo
                                           join sl in _context.ShowVsLoaiVeDbo on l.IdLoaiVe equals sl.IdLoaiVe
                                           where sl.IdShow.Equals(idShow)
                                           select new { l.IdLoaiVe,l.TenLoai, l.ChiTiet, sl.Gia, sl.ConLai }).ToListAsync();

            var dsChiTietVe = new List<PublicChiTietVeVm>();
            foreach (var x in dsChiTietVeFromDb)
            {
                dsChiTietVe.Add(new PublicChiTietVeVm()
                {
                    IdLoaiVe = x.IdLoaiVe,
                    TenLoai=x.TenLoai,
                    ChiTiet =x.ChiTiet,
                    Gia = x.Gia,
                    ConLai=x.ConLai
                });
            }

            var dsHinhAnh = new List<byte[]>();
            foreach (var x in dsHinhAnhFromDb)
            {
                dsHinhAnh.Add(x);
            }

            var showVm = new PublicGetByIdShowVm()
            {
                IdShow=show.IdShow,
                DiaDiem = show.DiaDiem,
                TenShow = show.TenShow,
                ThoiDiemBieuDien = show.ThoiDiemBieuDien,
                ThoiDiemMoBan = show.ThoiDiemMoBan,
                DsHinhAnh=dsHinhAnh,
                DsLoaiVe = dsChiTietVe,
            };
            return showVm;
        }

        public async Task<int> Booking(BookingRequest request)
        {
            var show = await _context.ShowDbo.FindAsync(request.IdShow);
            if (show.ThoiDiemMoBan < DateTime.Now || show.ThoiDiemBieuDien > DateTime.Now.AddHours(1)) return (int)BookingErrorCode.OFF_HOURS;
            var tmpHoaDon = await (from h in _context.HoaDonDbo
                                   join sl in _context.ShowVsLoaiVeDbo on h.IdShowVsLoaiVe equals sl.IdShowVsLoaiVe
                                   where sl.IdShow.Equals(request.IdShow) && h.SDT.Equals(request.SDT)
                                   select h).FirstOrDefaultAsync();
            if (tmpHoaDon != null) return (int)BookingErrorCode.BOOKED;

            var chiTietVe = await _context.ShowVsLoaiVeDbo.FindAsync(request.IdShow, request.IdLoaiVe);
            if (chiTietVe.ConLai < request.SoLuong) return (int)BookingErrorCode.SOLD_OUT;

            string uri = "https://localhost:44323/api/bank/";
            var payingRequest = new PayingRequest()
            {
                SrcAccount = request.Account,
                DesAccount = BankAccount,
                Password = request.Password,
                Payment = request.SoLuong * chiTietVe.Gia

            };
            var json = JsonConvert.SerializeObject(payingRequest);
            
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = client.UploadString(uri, "POST", json);
            if (Int32.Parse(response) > 0)//Thanh toán thành công
            {
                var hoaDon = new HoaDon()
                {
                    SoLuong = request.SoLuong,
                    SDT = request.SDT,
                    ShowVsLoaiVe = chiTietVe,
                    NgayGiaoDich = DateTime.Now,
                    DsVe = new List<Ve>()
                };
                Random ran = new Random();
                int preRanNumber = -1;
                for (int i = 0; i < request.SoLuong; i++)
                {
                    int randomNum = ran.Next(1000);
                    while (randomNum == preRanNumber)
                        randomNum = ran.Next(1000);
                    hoaDon.DsVe.Add(new Ve()
                    {
                        HoaDon = hoaDon,
                        MaSoVe = i.ToString() + hoaDon.NgayGiaoDich.ToString("MMddyyyyhhmmssfffffff") + $"{randomNum}".PadLeft(3, '0')
                    });
                    preRanNumber = randomNum;
                }
                chiTietVe.ConLai -= request.SoLuong;
                await _context.AddAsync(hoaDon);
                /*await _context.AddRangeAsync(dsve);*/
                await _context.SaveChangesAsync();
                return hoaDon.IdHoaDon;
            }
                
            else return Int32.Parse(response);
        }

        public async Task<HoaDonVm> GetHoaDonById(int idHoaDon)
        {
            var hoaDon = await _context.HoaDonDbo.FindAsync(idHoaDon);
            var dsVeFromDb = await (from h in _context.HoaDonDbo
                                    join v in _context.VeDbo on h.IdHoaDon equals v.IDHoaDon
                                    where h.IdHoaDon.Equals(idHoaDon)
                                    select v.MaSoVe).ToListAsync();
            var showVsLoaiVe = await (from sv in _context.ShowVsLoaiVeDbo
                              join s in _context.ShowDbo on sv.IdShow equals s.IdShow
                              where sv.IdShowVsLoaiVe.Equals(hoaDon.IdShowVsLoaiVe)
                              select new { s.DiaDiem, s.TenShow, s.ThoiDiemBieuDien, sv.Gia, sv.IdLoaiVe }).FirstOrDefaultAsync();
            var loaiVe = await _context.LoaiVeDbo.FindAsync(showVsLoaiVe.IdLoaiVe);
            var dsVe = new List<string>();
            foreach(var x in dsVeFromDb)
            {
                dsVe.Add(x);
            }
            var result = new HoaDonVm()
            {
                DiaDiem = showVsLoaiVe.DiaDiem,
                DsMaSoVe = dsVe,
                Gia = showVsLoaiVe.Gia,
                IdHoaDon = hoaDon.IdHoaDon,
                NgayGiaoDich = hoaDon.NgayGiaoDich,
                SDT = hoaDon.SDT,
                SoLuong = hoaDon.SoLuong,
                TenLoai = loaiVe.TenLoai,
                TenShow = showVsLoaiVe.TenShow,
                ThoiDiemBieuDien = showVsLoaiVe.ThoiDiemBieuDien
            };
            return result;
        }
    }
}
