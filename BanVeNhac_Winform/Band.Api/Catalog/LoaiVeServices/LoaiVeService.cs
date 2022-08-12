using Band.Data.EF;
using Band.ViewModels.Catalog.LoaiVe;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Band.Api.Catalog.LoaiVeServices
{
    public class LoaiVeService : ILoaiVeService
    {
        private readonly BandDbContext _context;

        public LoaiVeService(BandDbContext context)
        {
            _context = context;
        }
        public List<LoaiVeViewModel> GetAll()
        {
            var dsLoaiVe = _context.LoaiVeDbo.Select(p => new { p.IdLoaiVe, p.TenLoai, p.ChiTiet }).ToList();
            var result = new List<LoaiVeViewModel>();
            foreach(var x in dsLoaiVe)
            {
                result.Add(new LoaiVeViewModel()
                {
                    IdLoaiVe = x.IdLoaiVe,
                    TenLoai = x.TenLoai,
                    ChiTiet = x.ChiTiet
                });
            }
            return result;
        }
    }
}
