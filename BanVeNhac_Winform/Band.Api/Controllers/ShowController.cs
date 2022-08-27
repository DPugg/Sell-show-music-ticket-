using Band.Api.Catalog.LoaiVeServices;
using Band.Api.Catalog.ShowServices;
using Band.ViewModels.Catalog.Show;
using Band.ViewModels.Catalog.Show.Public;
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
    public class ShowController : ControllerBase
    {
        private readonly ILoaiVeService _loaiVeService;
        private readonly IManageShowService _manageShowService;
        private readonly IPublicShowService _publicShowService;
        public ShowController(ILoaiVeService loaiVeService, IManageShowService manageShowService, IPublicShowService publicShowService)
        {
            _loaiVeService = loaiVeService;
            _manageShowService = manageShowService;
            _publicShowService = publicShowService;
        }
        [HttpGet("loai-ve")]
        public async Task<IActionResult> GetAllLoaiVe()
        {
            var dsLoaiVe = _loaiVeService.GetAll();
            return Ok(dsLoaiVe);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var dsShow = _manageShowService.GetAll();
            return Ok(dsShow);
        }
        [HttpGet("all-img")]
        public async Task<IActionResult> GetAllImgById(int idShow)
        {
            var result = _manageShowService.GetAllImgById(idShow);
            return Ok(result);
        }
        [HttpPost("adding-images")]
        public async Task<IActionResult> AddingImages(ImagesShowAddRequest request)
        {
            var result = await _manageShowService.AddingImages(request);
            if (result == 0)
                return BadRequest();
            return Ok(true);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ShowCreateRequest request)
        {
            var result = await _manageShowService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok(true);
        }
        [HttpGet("byid")]
        public async Task<IActionResult> GetById(int idShow)
        {
            var result = await _manageShowService.GetById(idShow);
            if (result == null)
                return BadRequest("Không thể tìm thấy show");
            return Ok(result);
        }
        [HttpPut("show-info")]
        public async Task<IActionResult> UpdateShowInfo(ShowInfoUpdateRequest request)
        {
            var result = await _manageShowService.UpdateShowInfo(request);
            return Ok(true);
        }

        [HttpPut("ticket-info")]
        public async Task<IActionResult> UpdateTicketInfor(TicketInfoUpdateRequest request)
        {
            var result = await _manageShowService.UpdateTicketInfor(request);
            if (result <= 0)
            {   
                return BadRequest("khong tim thay ve");
            }
                
            return Ok(true);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int idShow)
        {
            var result = await _manageShowService.Delete(idShow);
            if (result <=0)
                return BadRequest();
            return Ok(true);
        }

        [HttpDelete("delete-images")]
        public async Task<IActionResult> DeleteImages(List<int> request)
        {
            var result = await _manageShowService.DeleteImages(request);
            if (result == 0)
                return BadRequest();
            return Ok(true);
        }

        [HttpPost("statiscal-paging")]
        public async Task<IActionResult> GetStatiscalPaging(StatiscalRequest request)
        {
            var result = await _manageShowService.GetStatiscalData(request);
            return Ok(result);
        }



        /*****************************************************************
         * ****************************   PUBLIC    *************************************
         * *****************************************************************/


        [HttpGet("public/all")]
        public async Task<IActionResult> GetAllPublic()
        {
            var result = await _publicShowService.GetAll();
            if (result == null)
                return BadRequest("Không tìm thấy show nào");
            return Ok(result);
        }

        [HttpGet("public/byid")]
        public async Task<IActionResult> GetByIdPublic(int idShow)
        {
            var result = await _publicShowService.GetById(idShow);
            if (result == null)
                return Ok("Không thể tìm thấy show");
            return Ok(result);
        }

        [HttpPost("booking")]
        public async Task<IActionResult> Booking(BookingRequest request)
        {
           
            var result = await _publicShowService.Booking(request);
            Console.Write("request   ==========" + request);
            return Ok(result);
        }
        [HttpPost("ReceiveCode")]
        public async Task<IActionResult> ReceiveCode(ReceiveCodeRequest request)
        {
            var result = await _publicShowService.ReceiveCode(request);
            Console.WriteLine("request=====" + request);
            return Ok(result);
        }

        [HttpGet("hoadon")]
        public async Task<IActionResult> GetHoaDonById(int idHoaDon)
        {
            var result = await _publicShowService.GetHoaDonById(idHoaDon);
            if (result == null)
                return BadRequest("Không thể tìm thấy show nào");
            return Ok(result);
        }
    }
}
