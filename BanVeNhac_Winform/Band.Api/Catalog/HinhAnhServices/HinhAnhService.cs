using Band.Data.EF;
using Band.Data.Entities;
using Band.ViewModels.Catalog.Anh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Band.Api.Catalog.HinhAnhServices
{
    public class HinhAnhService : IHinhAnhService
    {
        private readonly BandDbContext _context;

        public HinhAnhService(BandDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(AnhCreateRequest request)
        {
            var hinhAnh = new HinhAnh()
            {
                Anh=request.Anh
                /*IdLoai=request.IdLoai*/
            };
            _context.HinhAnhDbo.Add(hinhAnh);
            await _context.SaveChangesAsync();
            return hinhAnh.IdLoai;
        }

        public Task<int> Delete(int thanhVienId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(AnhCreateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
