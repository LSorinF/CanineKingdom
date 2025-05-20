using CanineKingdom.Infrastructure;
using CanineKingdom.Models;
using CanineKingdom.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CanineKingdom.Services
{
    public class CommentService : ICommentService
    {
        private readonly CanineDbContext _repository;

        public CommentService(CanineDbContext context)
        {
            _repository = context;
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _repository.Comments.ToListAsync();
        }

        public async Task<Comment> GetCommentDetailsAsync(int? id)
        {
            if (id == null)
                return null;

            return await _repository.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> CreateCommentAsync(Comment comment)
        {
            if (comment == null)
                return false;

            comment.CreatedAt = DateTime.Now;
            comment.ArticleId = 1; // Hardcoded or change if needed
            _repository.Comments.Add(comment);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<Comment> GetCommentForEditAsync(int? id)
        {
            if (id == null)
                return null;

            return await _repository.Comments.FindAsync(id);
        }

        public async Task<bool> UpdateCommentAsync(int id, Comment comment)
        {
            if (id != comment.Id)
                return false;

            try
            {
                _repository.Update(comment);
                await _repository.SaveChangesAsync();
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

            return await _repository.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            var comment = await _repository.Comments.FindAsync(id);
            if (comment == null)
                return false;

            _repository.Comments.Remove(comment);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CommentExistsAsync(int id)
        {
            return await _repository.Comments.AnyAsync(c => c.Id == id);
        }
    }
}
