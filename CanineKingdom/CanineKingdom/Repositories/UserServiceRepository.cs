using CanineKingdom.Models;
using CanineKingdom.Repositories.Interfaces;
using CanineKingdom.Repositories;
using CanineKingdom.Infrastructure;

namespace CanineKingdom.Repositories
{
    public class UserServiceRepository : RepositoryBase<User>, IUserServiceRepository
    {
        public UserServiceRepository(CanineDbContext canineDbContext)
            : base(canineDbContext)
        {

        }
    }
}
