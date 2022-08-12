using Band.Data.EF;
using Band.Data.Entities;
using Band.ViewModels.Catalog.Band;
using Band.ViewModels.Catalog.ThanhVien;
using Band.ViewModels.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Band.ViewModels.Utilities.SystemConstants;

namespace Band.Api.Catalog.BandServices
{
    public class BandService : IBandService
    {
        private readonly BandDbContext _context;

        public BandService(BandDbContext context)
        {
            _context = context;
        }

        public async Task<NewListOfByteArrayImage> GetAllImg()
        {
            var dsHinhAnhFromDb = await (from a in _context.HinhAnhDbo
                                   where a.IdLoai.Equals((int)ImageType.IMG_BAND)
                                   select a).ToListAsync();
            var result = new NewListOfByteArrayImage();
            foreach (var x in dsHinhAnhFromDb)
            {
                result.Add(new ByteArrayImageObject(x.IdAnh, x.Anh));
            }
            return result;
        }

        public async Task<int> Update(BandUpdateRequest request)
        {
            var band = _context.NhomNhacDbo.FirstOrDefault();
            band.Youtube = request.Youtube;
            band.TenNhom = request.TenNhom;
            band.Spotify = request.Spotify;
            band.DebutDate = request.DebutDate;
            band.AppleMusic = request.AppleMusic;
            band.ChiTiet = request.ChiTiet;
            band.CongTy = request.CongTy;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateLogo(byte[] request)
        {
            var band = _context.NhomNhacDbo.FirstOrDefault();
            band.Logo = request;
            return await _context.SaveChangesAsync();
        }

        BandViewModel IBandService.Get()
        {
            var band = _context.NhomNhacDbo.FirstOrDefault();
            if (band == null) return null;
            var image = (from h in _context.HinhAnhDbo
                         where h.IdLoai.Equals((int)ImageType.IMG_BAND)
                         select h.Anh).FirstOrDefault();
            var result = new BandViewModel()
            {
                AppleMusic = band.AppleMusic,
                ChiTiet = band.ChiTiet,
                CongTy = band.CongTy,
                DebutDate = band.DebutDate,
                Logo = band.Logo,
                Spotify = band.Spotify,
                TenNhom = band.TenNhom,
                Youtube = band.Youtube,
                Image = image
            };
            return result;
        }

        public async Task<int> DeleteImages(List<int> listIdAnh)
        {
            var dsHinhAnh = new List<HinhAnh>();
            foreach (var i in listIdAnh)
            {
                dsHinhAnh.Add(await _context.HinhAnhDbo.FindAsync(i));
            }

            _context.HinhAnhDbo.RemoveRange(dsHinhAnh);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddingImages(List<byte[]> dsAnh)
        {
            List<HinhAnh> dsHinhAnh = new List<HinhAnh>();
            foreach (byte[] img in dsAnh)
            {
                dsHinhAnh.Add(new HinhAnh()
                {
                    Anh = img,
                    IdLoai = (int)ImageType.IMG_BAND
                });
            }
            await _context.HinhAnhDbo.AddRangeAsync(dsHinhAnh);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Create(BandCreateRequest request)
        {
            //Thêm hình ảnh vào bảng hình ảnh trước
            List<HinhAnh> dsHinhAnh = new List<HinhAnh>();
            foreach (byte[] img in request.ImageList)
            {
                dsHinhAnh.Add(new HinhAnh()
                {
                    Anh = img,
                    IdLoai = (int)ImageType.IMG_BAND
                });
            }
            var band = new NhomNhac()
            {
                AppleMusic=request.AppleMusic,
                ChiTiet=request.ChiTiet,
                CongTy=request.CongTy,
                DebutDate=request.DebutDate,
                Logo=request.Logo,
                Spotify=request.Spotify,
                TenNhom=request.TenNhom,
                Youtube=request.Youtube
            };

            await _context.HinhAnhDbo.AddRangeAsync(dsHinhAnh);
            await _context.NhomNhacDbo.AddAsync(band);
            return await _context.SaveChangesAsync();
        }
    }
}
