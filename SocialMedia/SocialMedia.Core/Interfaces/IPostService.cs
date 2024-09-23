using SocialMedia.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.QueryFilters;
using SocialMedia.Core.CustomEntities;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        PagedList<Post> GetPosts(PostQueryFilter filters);
        Task<Post> GetPost(int id);
        Task InsertPost(Post post);
        Task<bool> UpdatePost(Post post);
        Task<bool> DeletePost(int id);
    }
}
