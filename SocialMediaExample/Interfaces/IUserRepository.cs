using SocialMediaExample.Entities;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User> GetByUsernameAsync(string username);
    Task<User> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync(int pageNumber, int pageSize);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
    Task SaveChangesAsync();
}
