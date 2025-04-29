using CanineKingdom.Models;
using CanineKingdom.Repositories.Interfaces;
using CanineKingdom.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CanineKingdom.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CanineDbContext CanineDbContext { get; set; }

        public RepositoryBase(CanineDbContext canineDbContext)
        {
            this.CanineDbContext = canineDbContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.CanineDbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.CanineDbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.CanineDbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.CanineDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.CanineDbContext.Set<T>().Remove(entity);
        }
    }
}
