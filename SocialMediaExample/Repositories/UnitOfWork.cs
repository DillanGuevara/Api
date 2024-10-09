using SocialMediaExample.Data;
using SocialMediaExample.Entities;
using SocialMediaExample.Interfaces;

namespace SocialMediaExample.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaContext _context;
        private IUserRepository _userRepository;

        public UnitOfWork(SocialMediaContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
