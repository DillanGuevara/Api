using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Responses;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;

        public LoginController(ILoginService loginService, IMapper mapper)
        {
            _loginService = loginService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            {
                var login = _mapper.Map<Login>(loginDto);
                await _loginService.RegisterUser(login);

                loginDto = _mapper.Map<LoginDTO>(login);
                var response = new ApiResponse<LoginDTO>(loginDto);
                return Ok(response);
            }
        }
    }
}
