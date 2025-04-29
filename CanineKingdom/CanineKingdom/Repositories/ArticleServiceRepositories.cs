using CanineKingdom.Models;
using CanineKingdom.Repositories.Interfaces;
using CanineKingdom.Repositories;
using CanineKingdom.Infrastructure;

namespace CanineKingdom.Repositories
{
    public class ArticleServiceRepository : RepositoryBase<Article>, IArticleServiceRepositories
    {
        public ArticleServiceRepository(CanineDbContext canineDbContext)
            : base(canineDbContext)
        {

        }
    }
}
