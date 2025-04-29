using CanineKingdom.Models;
using CanineKingdom.Repositories.Interfaces;
using CanineKingdom.Repositories;
using CanineKingdom.Infrastructure;

namespace CanineKingdom.Repositories
{
    public class BreedsServiceRepository : RepositoryBase<Breed>, IBreedsServiceRepository
    {
        public BreedsServiceRepository(CanineDbContext canineDbContext)
            : base(canineDbContext)
        {

        }
    }
}
