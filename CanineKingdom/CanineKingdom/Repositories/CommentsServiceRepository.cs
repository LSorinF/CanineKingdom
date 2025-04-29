using CanineKingdom.Models;
using CanineKingdom.Repositories.Interfaces;
using CanineKingdom.Repositories;
using CanineKingdom.Infrastructure;

namespace CanineKingdom.Repositories
{
    public class CommentsServiceRepository : RepositoryBase<Comment>, ICommentsServiceRepository
    {
        public CommentsServiceRepository(CanineDbContext canineDbContext)
            : base(canineDbContext)
        {

        }
    }
}
