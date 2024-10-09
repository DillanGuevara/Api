using SocialMediaExample.Entities;
using SocialMediaExample.Interfaces;

namespace SocialMediaExample.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public UserService(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task<User> RegisterUserAsync(string username, string password, bool isActive)
        {
            var hashedPassword = await _passwordService.HashPasswordAsync(password);

            var user = new User
            {
                UserName = username,
                Password = hashedPassword,
                IsActive = isActive
            };

            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            user.Password = await _passwordService.HashPasswordAsync(user.Password);
            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<User> GetUserAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);

            if (user != null)
            {
                if (await _passwordService.VerifyPasswordAsync(user.Password, password))
                {
                    return user;
                }
            }

            return null;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(int pageNumber, int pageSize)
        {
            return await _userRepository.GetAllAsync(pageNumber, pageSize);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
