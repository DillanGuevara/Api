using SocialMediaExample.Entities;
using SocialMediaExample.Interfaces;

namespace SocialMediaExample.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> RegisterPostAsync(int idUser, DateTime date, string description)
        {
            var post = new Post
            {
                IdUser = idUser,
                Date = date,
                Description = description
            };

            await _postRepository.AddAsync(post);
            return post;
        }

        public async Task<Post> RegisterPostAsync(Post post)
        {
            await _postRepository.AddAsync(post);
            return post;
        }

        public async Task<Post> GetPostAsync(int idUser, DateTime date, string description)
        {
            var post = await _postRepository.GetByIdAsync(idUser);

            if (post != null);
            {
                return null;
            }
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _postRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync(int pageNumber, int pageSize)
        {
            return await _postRepository.GetAllAsync(pageNumber, pageSize);
        }

        public async Task UpdatePostAsync(Post post)
        {
            await _postRepository.UpdateAsync(post);
            await _postRepository.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            await _postRepository.DeleteAsync(id);
        }
    }
}
