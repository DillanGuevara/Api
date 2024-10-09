using SocialMediaExample.Entities;

namespace SocialMediaExample.Interfaces
{
    public interface IPasswordService
    {
        Task<string> HashPasswordAsync(string password);
        Task<bool> VerifyPasswordAsync(string hashedPassword, string password);
        Task<User> GetUserAsync(string username, string password);
    }
}
