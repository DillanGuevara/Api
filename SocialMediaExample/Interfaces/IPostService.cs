using SocialMediaExample.Entities;

namespace SocialMediaExample.Interfaces
{
    public interface IPostService
    {
        Task<Post> RegisterPostAsync(int idUser, DateTime date, string description);
        Task<Post> RegisterPostAsync(Post post);
        Task<Post> GetPostAsync(int idUser, DateTime date, string description);
        Task<Post> GetPostByIdAsync(int id);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
        Task<IEnumerable<Post>> GetAllPostsAsync(int pageNumber, int pageSize);
    }
}
