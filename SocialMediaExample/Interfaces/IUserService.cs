using SocialMediaExample.Entities;

namespace SocialMediaExample.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(string username, string password, bool isActive);
        Task<User> RegisterUserAsync(User user);
        Task<User> GetUserAsync(string username, string password);
        Task<User> GetUserByIdAsync(int id);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync(int pageNumber, int pageSize);
    }
}
