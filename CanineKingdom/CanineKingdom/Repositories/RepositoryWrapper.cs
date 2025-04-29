using CanineKingdom.Models;
using CanineKingdom.Repositories.Interfaces;
using CanineKingdom.Infrastructure;

namespace CanineKingdom.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CanineDbContext _canineDbContext;
        private IUserServiceRepository? _userServiceRepository;

        public IUserServiceRepository UserServiceRepository
        {
            get
            {
                if (_userServiceRepository == null)
                {
                    _userServiceRepository = new UserServiceRepository(_canineDbContext);
                }

                return _userServiceRepository;
            }
        }

        public RepositoryWrapper(CanineDbContext canineDbContext)
        {
            _canineDbContext = canineDbContext;
        }

        public void Save()
        {
            _canineDbContext.SaveChanges();
        }
    }
}
