using SocialMediaExample.Entities;

namespace SocialMediaExample.Interfaces
{
    public interface IPostRepository
    {
        Task AddAsync(Post post);
        Task<Post> GetByIdAsync(int id);
        Task<IEnumerable<Post>> GetAllAsync(int pageNumber, int pageSize);
        Task UpdateAsync(Post post);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
