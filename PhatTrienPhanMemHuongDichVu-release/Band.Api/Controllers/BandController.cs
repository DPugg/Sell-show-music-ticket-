using Band.Api.Catalog.BandServices;
using Band.ViewModels.Catalog.Band;
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
    public class BandController : ControllerBase
    {
        private readonly IBandService _bandService;
        public BandController(IBandService bandService)
        {
            _bandService = bandService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(BandCreateRequest request)
        {
            var result = await _bandService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok(true);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = _bandService.Get();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(BandUpdateRequest request)
        {
            var result = await _bandService.Update(request);
            if (result == 0)
                return BadRequest();
            return Ok(true);
        }

        [HttpGet("img")]
        public async Task<IActionResult> GetAllImg()
        {
            var result = await _bandService.GetAllImg();
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("update-image")]
        public async Task<IActionResult> UpdateLogo(byte[] request)
        {
            var result = await _bandService.UpdateLogo(request);
            if (result == 0)
                return BadRequest();
            return Ok(true);
        }

        [HttpPost("adding-images")]
        public async Task<IActionResult> AddingImages(List<byte[]> dsAnh)
        {
            var result = await _bandService.AddingImages(dsAnh);
            if (result == 0)
                return BadRequest();
            return Ok(true);
        }

        [HttpDelete("delete-images")]
        public async Task<IActionResult> DeleteImages(List<int> request)
        {
            var result = await _bandService.DeleteImages(request);
            if (result == 0)
                return BadRequest();
            return Ok(true);
        }
    }
}
