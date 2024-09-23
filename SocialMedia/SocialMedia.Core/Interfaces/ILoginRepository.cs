using SocialMedia.Core.Entities;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface ILoginRepository : IRepository<Login>
    {
        Task<Login> GetLoginByCredentials(UserLogin login);
    }
}
