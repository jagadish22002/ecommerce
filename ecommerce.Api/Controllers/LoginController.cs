using ecommerce.Data.Interfaces;
using ecommerce.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _loginService.LoginAsync(loginDto.Email, loginDto.Password);

            if (user == null)
                return Unauthorized(new { message = "Invalid email or password" });

            // Don’t return the password back
            return Ok(new
            {
                user.UserId,
                user.Username,
                user.Email,
                user.Location
            });
        }
    }
}
