using Microsoft.AspNetCore.Mvc;
using SocialMediaExample.Interfaces;
using SocialMediaExample.Models;
using SocialMediaExample.Services;

namespace SocialMediaExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public LoginController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Username and password are required.");
            }

            var user = await _userService.GetUserAsync(request.UserName, request.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = await _tokenService.GenerateTokenAsync(user);
            return Ok(new { token });
        }
    }
}
