using Band.Api.Catalog.VaiTroServices;
using Band.ViewModels.Catalog.VaiTro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Band.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaiTroController : ControllerBase
    {
        private readonly IVaiTroService _vaiTroService;
        public VaiTroController(IVaiTroService vaiTroService)
        {
            _vaiTroService = vaiTroService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(VaiTroCreateRequest request)
        {
            var vaiTro = await _vaiTroService.Create(request);
            return Ok(vaiTro);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vaiTro = _vaiTroService.GetAll();
            return Ok(vaiTro);
        }
    }
}
