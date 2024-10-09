using SocialMediaExample.Entities;
using System.Threading.Tasks;

namespace SocialMediaExample.Interfaces
{
    public interface ILoginService
    {
        string GetUserByUsername(object username);
        Task RegisterUser(Login login);
        void RegisterUser(User user);
    }
}