using SocialMediaExample.Data;
using SocialMediaExample.Interfaces;
using SocialMediaExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace SocialMediaExample.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _context;

        public PostRepository(SocialMediaContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _context.Posts
                .FirstOrDefaultAsync(p => p.IdPost == id);
        }

        public async Task<IEnumerable<Post>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Posts
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task UpdateAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
