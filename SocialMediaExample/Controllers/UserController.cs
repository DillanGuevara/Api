using Microsoft.AspNetCore.Mvc;
using SocialMediaExample.Entities;
using SocialMediaExample.Interfaces;

namespace SocialMediaExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;

        public UserController(IUserService userService, IPasswordService passwordService)
        {
            _userService = userService;
            _passwordService = passwordService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }

            await _userService.RegisterUserAsync(user);
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var users = await _userService.GetAllUsersAsync(pageNumber, pageSize);

            if (!users.Any())
                return NotFound("No users found.");

            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            if (id != updatedUser.IdUser)
                return BadRequest("The user ID in the request doesn't match the ID in the user object.");

            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
                return NotFound("User not found.");

            existingUser.UserName = updatedUser.UserName;
            existingUser.IsActive = updatedUser.IsActive;

            if (!await _passwordService.VerifyPasswordAsync(existingUser.Password, updatedUser.Password))
            {
                existingUser.Password = await _passwordService.HashPasswordAsync(updatedUser.Password);
            }

            await _userService.UpdateUserAsync(existingUser);

            return Ok("The user update is correct.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
                return NotFound();

            await _userService.DeleteUserAsync(id);
            return Ok("The user delete is correct");
        }
    }
}
