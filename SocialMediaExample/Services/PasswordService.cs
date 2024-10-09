using SocialMediaExample.Entities;
using SocialMediaExample.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace SocialMediaExample.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IUserRepository _userRepository; // Declara la variable de instancia

        // Inyecta IUserRepository a través del constructor
        public PasswordService(IUserRepository userRepository)
        {
            _userRepository = userRepository; // Asigna la variable de instancia
        }

        public async Task<string> HashPasswordAsync(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return await Task.FromResult(Convert.ToBase64String(hash));
            }
        }

        public async Task<bool> VerifyPasswordAsync(string hashedPassword, string password)
        {
            var hashedInputPassword = await HashPasswordAsync(password);
            return hashedInputPassword == hashedPassword;
        }

        // Implementación del método GetUserAsync
        public async Task<User> GetUserAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user != null)
            {
                var isPasswordValid = await VerifyPasswordAsync(user.Password, password);
                return isPasswordValid ? user : null;
            }
            return null;
        }
    }
}
