using SocialMediaExample.Interfaces;
using SocialMediaExample.Entities;
using SocialMediaExample.Interfaces;
using System;
using System.Threading.Tasks;

namespace SocialMediaExample.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string GetUserByUsername(object username)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterUser(Login login)
        {
            if (login == null)
            {
                throw new ArgumentNullException(nameof(login));
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public void RegisterUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
