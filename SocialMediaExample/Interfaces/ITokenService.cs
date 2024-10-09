using SocialMediaExample.Entities;

namespace SocialMediaExample.Services
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(User user);
    }
}
