using SocialMedia.Core.Entities;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface ILoginService
    {
        Task<Login> GetLoginByCredentials(UserLogin userlogin);
        Task RegisterUser(Login login);
    }
}
