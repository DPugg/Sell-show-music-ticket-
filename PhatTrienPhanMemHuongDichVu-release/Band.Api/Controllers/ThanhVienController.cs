using Band.Api.Catalog.ThanhVienService;
using Band.ViewModels.Catalog.ThanhVien;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Band.Api.Controllers
{
    [Route("api/[controller]")] //facebook.com/api/thanhvien
    // https://localhost:44315/api/thanhvien/all
    [ApiController]
    public class ThanhVienController : ControllerBase
    {
        private readonly IPublicThanhVienService _publicThanhVienService;
        private readonly IManageThanhVienService _manageThanhVienService;

        public ThanhVienController(IPublicThanhVienService publicThanhVienService, IManageThanhVienService manageThanhVienService)
        {
            _publicThanhVienService = publicThanhVienService;
            _manageThanhVienService = manageThanhVienService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Test ok");
        }
        [HttpGet("idthanhvien")]
        public async Task<IActionResult> GetById(int idThanhVien)
        {
            var result = await _manageThanhVienService.GetById(idThanhVien);
            if (result == null)
                return BadRequest("Không thể tìm thấy thành viên");
            return Ok(result);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _manageThanhVienService.GetAll();
            if (result == null)
                return BadRequest("Cannot find product");
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ThanhVienCreateRequest request)
        {
            var result = await _manageThanhVienService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok(true);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ThanhVienUpdateRequestWithoutVaiTro request)
        {
            var result = await _manageThanhVienService.Update(request);
            return Ok(true);
        }
        [HttpPost("update-position")]
        public async Task<IActionResult> UpdatePosition(ThanhVienUpdatePositionRequest request)
        {
            var result = await _manageThanhVienService.UpdatePosition(request);
            if (result == 0)
                return BadRequest();
            return Ok(true);
        }
        [HttpPost("adding-images")]
        public async Task<IActionResult> AddingImages(HinhAnhThanhVienRequest request)
        {
            var result = await _manageThanhVienService.AddingImages(request);
            if (result == 0)
                return BadRequest();
            return Ok(true);
        }
        [HttpGet("avatar-thanh-vien")]
        public async Task<IActionResult> GetAllAvatarById(int idThanhVien)
        {
            var result = await _manageThanhVienService.GetAllAvatarById(idThanhVien);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
        [HttpGet("covers-thanh-vien")]
        public async Task<IActionResult> GetAllCoverById(int idThanhVien)
        {
            var result = await _manageThanhVienService.GetAllCoverById(idThanhVien);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpGet("all-hinh-anh-thanh-vien")]
        public async Task<IActionResult> GetThanhVienVsHinhAnh()
        {
            var result = await _manageThanhVienService.GetThanhVienVsHinhAnh();
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpDelete("delete-images")]
        public async Task<IActionResult> DeleteImages(List<int> request)
        {
            var result = await _manageThanhVienService.DeleteImages(request);
            if (result == 0)
                return BadRequest();
            return Ok(true);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int idThanhVien)
        {
            var result = await _manageThanhVienService.Delete(idThanhVien);
            if (result == 0)
                return BadRequest();
            return Ok(true);
        }




        /*****************************************************************
         * ****************************   PUBLIC    *************************************
         * *****************************************************************/
        [HttpGet("public/all")]
        public async Task<IActionResult> GetAllPublic()
        {
            var result = await _publicThanhVienService.GetAll();
            if (result == null)
                return BadRequest("Không tìm thấy thành viên nào");
            return Ok(result);
        }
        [HttpGet("public/by-id")]
        public async Task<IActionResult> GetByIdPublic(int idThanhVien)
        {
            var result = await _publicThanhVienService.GetById(idThanhVien);
            if (result == null)
                return Ok("Không tìm thấy thành viên nào");
            return Ok(result);
        }
    }
}
