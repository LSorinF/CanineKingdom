using CanineKingdom.Infrastructure;
using CanineKingdom.Models;
using CanineKingdom.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CanineKingdom.Services
{
    public class ArticleService : IArticleService
    {
        private readonly CanineDbContext _context;

        public ArticleService(CanineDbContext context)
        {
            _context = context;
        }

        public async Task<List<Article>> GetAllArticlesAsync()
        {
            return await _context.Articles.Include(a => a.User).ToListAsync();
        }

        public async Task<List<Article>> SearchArticlesByTitleAsync(string searchString)
        {
            var query = _context.Articles.Include(a => a.User).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(a => a.Title.ToLower().Contains(searchString.ToLower()));
            }

            return await query.ToListAsync();
        }


        public async Task<Article> GetArticleDetailsAsync(int? id)
        {
            if (id == null)
                return null;

            return await _context.Articles.Include(a => a.User)
                                          .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> CreateArticleAsync(Article article)
        {
            if (article == null)
                return false;

            article.PublishedAt = DateTime.Now;
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Article> GetArticleForEditAsync(int? id)
        {
            if (id == null)
                return null;

            return await _context.Articles.FindAsync(id);
        }

        public async Task<bool> UpdateArticleAsync(int id, Article article)
        {
            if (id != article.Id)
                return false;

            try
            {
                _context.Articles.Update(article);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ArticleExistsAsync(article.Id))
                    return false;
                else
                    throw;
            }
        }

        public async Task<Article> GetArticleForDeleteAsync(int? id)
        {
            if (id == null)
                return null;

            return await _context.Articles.Include(a => a.User)
                                          .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> DeleteArticleAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
                return false;

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ArticleExistsAsync(int id)
        {
            return await _context.Articles.AnyAsync(a => a.Id == id);
        }
    }
}
