using Band.ViewModels.Catalog.Show.Public;
using Band.ViewModels.Common;
using Bank.Api.BankServices;
using Bank.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpPost("get-balance")]
        public async Task<IActionResult> GetBalance(GetBalanceRequest request)
        {
            var balance = _bankService.GetBalance(request);
            return Ok(balance);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBalance(PayingRequest request)
        {
            var result = await _bankService.CreateTransaction(request);
            return Ok(result);
        }
    }
}
