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

        //public async Task<List<Article>> GetAllAsync()
        //{
        //    return await _context.Articles
        //        .Include(a => a.Author)
        //        .Include(a => a.Reactions)
        //        .Include(a => a.Comments)
        //            .ThenInclude(c => c.Reactions)
        //        .ToListAsync();
        //}

        //public async Task<Article> GetByIdAsync(int id)
        //{
        //    return await _context.Articles
        //        .Include(a => a.Author)
        //        .Include(a => a.Reactions)
        //        .Include(a => a.Comments)
        //            .ThenInclude(c => c.Author)
        //        .Include(a => a.Comments)
        //            .ThenInclude(c => c.Reactions)
        //        .FirstOrDefaultAsync(a => a.Id == id);
        //}

        public async Task CreateAsync(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Article article)
        {
            _context.Articles.Update(article);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
            }
        }

        //public async Task AddCommentAsync(int articleId, string content)
        //{
        //    var comment = new ArticleComment
        //    {
        //        ArticleId = articleId,
        //        Content = content,
        //        PostedAt = DateTime.UtcNow
        //    };

        //    _context.ArticleComments.Add(comment);
        //    await _context.SaveChangesAsync();
        //}

        public async Task ReactToArticleAsync(int articleId, string authorId, ReactionType reaction)
        {
            var existing = await _context.ArticleReactions
                .FirstOrDefaultAsync(r => r.ArticleId == articleId && r.UserId == authorId);

            if (existing == null)
            {
                _context.ArticleReactions.Add(new ArticleReaction
                {
                    ArticleId = articleId,
                    UserId = authorId,
                    Reaction = reaction
                });
            }
            else
            {
                existing.Reaction = reaction;
                _context.ArticleReactions.Update(existing);
            }

            await _context.SaveChangesAsync();
        }

        //public async Task<IEnumerable<ArticleComment>> GetCommentsAsync(int articleId)
        //{
        //    return await _context.ArticleComments
        //        .Where(c => c.ArticleId == articleId)
        //        .Include(c => c.Author)
        //        .Include(c => c.Reactions)
        //        .OrderByDescending(c => c.PostedAt)
        //        .ToListAsync();
        //}

        public async Task<int> CountReactionsAsync(int articleId, ReactionType reactionType)
        {
            return await _context.ArticleReactions
                .CountAsync(r => r.ArticleId == articleId && r.Reaction == reactionType);
        }

        public Task<List<Article>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
