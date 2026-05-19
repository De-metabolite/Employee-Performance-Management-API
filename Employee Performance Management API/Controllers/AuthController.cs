using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Employee_Performance_Management_API.DTOs;

using Employee_Performance_Management_API.Services;

namespace Employee_Performance_Management_API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {   private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto dto, DateTime date)
        {
            await _authService.RegisterAsync(dto);
            return Ok("Account Created Successfully.");
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> LoginAsync(LoginDto dto)
        { 
           var token =await _authService.LoginResponseDtoAsync(dto);
            return Ok(token);
        }
    }
}
