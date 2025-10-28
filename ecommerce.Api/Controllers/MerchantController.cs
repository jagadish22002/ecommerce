using ecommerce.Models;
using ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantService _merchantService;

        public MerchantController(IMerchantService merchantService)
        {
            _merchantService = merchantService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateMerchant([FromBody] MerchantCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var created = await _merchantService.CreateMerchantAsync(dto);
                return Ok(created);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMerchants()
        {
            var merchants = await _merchantService.GetAllMerchantsAsync();
            return Ok(merchants);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetMerchantById(Guid id)
        {
            var merchant = await _merchantService.GetMerchantByIdAsync(id);
            if (merchant == null) return NotFound();
            return Ok(merchant);
        }
    }
}
