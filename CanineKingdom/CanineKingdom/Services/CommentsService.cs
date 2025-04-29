using CanineKingdom.Infrastructure;
using CanineKingdom.Models;
using CanineKingdom.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CanineKingdom.Services
{
    public class CommentService : ICommentService
    {
        private readonly CanineDbContext _context;

        public CommentService(CanineDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetCommentDetailsAsync(int? id)
        {
            if (id == null)
                return null;

            return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> CreateCommentAsync(Comment comment)
        {
            if (comment == null)
                return false;

            comment.CreatedAt = DateTime.Now;
            comment.ArticleId = 1; // Hardcoded or change if needed
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Comment> GetCommentForEditAsync(int? id)
        {
            if (id == null)
                return null;

            return await _context.Comments.FindAsync(id);
        }

        public async Task<bool> UpdateCommentAsync(int id, Comment comment)
        {
            if (id != comment.Id)
                return false;

            try
            {
                _context.Update(comment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CommentExistsAsync(comment.Id))
                    return false;
                else
                    throw;
            }
        }

        public async Task<Comment> GetCommentForDeleteAsync(int? id)
        {
            if (id == null)
                return null;

            return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
                return false;

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CommentExistsAsync(int id)
        {
            return await _context.Comments.AnyAsync(c => c.Id == id);
        }
    }
}
