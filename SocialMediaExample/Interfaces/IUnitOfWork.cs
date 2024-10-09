using SocialMediaExample.Repositories;

namespace SocialMediaExample.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        Task SaveChangesAsync();
        void SaveChanges();
    }
}
