using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Login> GetLoginByCredentials(UserLogin userlogin)
        {
            return await _unitOfWork.LoginRepository.GetLoginByCredentials(userlogin);
        }

        public async Task RegisterUser(Login login)
        {
            await _unitOfWork.LoginRepository.Add(login);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
