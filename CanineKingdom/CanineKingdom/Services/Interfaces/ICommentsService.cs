using CanineKingdom.Models;

namespace CanineKingdom.Services.Interfaces
{
    public interface ICommentService
    {
        Task<List<Comment>> GetAllCommentsAsync();
        Task<Comment> GetCommentDetailsAsync(int? id);
        Task<bool> CreateCommentAsync(Comment comment);
        Task<Comment> GetCommentForEditAsync(int? id);
        Task<bool> UpdateCommentAsync(int id, Comment comment);
        Task<Comment> GetCommentForDeleteAsync(int? id);
        Task<bool> DeleteCommentAsync(int id);
        Task<bool> CommentExistsAsync(int id);
    }
}
