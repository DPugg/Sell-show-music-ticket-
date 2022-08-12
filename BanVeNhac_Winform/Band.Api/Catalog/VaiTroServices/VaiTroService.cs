using Band.Data.EF;
using Band.Data.Entities;
using Band.ViewModels.Catalog.VaiTro;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Band.Api.Catalog.VaiTroServices
{
    public class VaiTroService : IVaiTroService
    {
        private readonly BandDbContext _context;

        public VaiTroService(BandDbContext context)
        {
            _context = context;
        }
        
        public async Task<int> Create([FromForm] VaiTroCreateRequest request)
        {
            var vaiTro = new VaiTro()
            {
                TenVaiTro = request.TenVaiTro
            };
            _context.VaiTroDbo.Add(vaiTro);
            return await _context.SaveChangesAsync();
        }

        public List<VaiTroViewModel> GetAll()
        {
            var dsVaiTro= _context.VaiTroDbo.Select(p=>new { p.IdVaiTro,p.TenVaiTro}).ToList();
            var result = new List<VaiTroViewModel>();
            foreach(var x in dsVaiTro)
            {
                result.Add(new VaiTroViewModel()
                {
                    IdVaiTro = x.IdVaiTro,
                    TenVaiTro = x.TenVaiTro
                });
            }
            return result;
        }
    }
}
