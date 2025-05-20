using CanineKingdom.Models;

namespace CanineKingdom.Services.Interfaces
{
    public interface IArticleService
    {
        Task<List<Article>> GetAllAsync();
        Task<Article> GetByIdAsync(int id);
        Task CreateAsync(Article article);
        Task UpdateAsync(Article article);
        Task DeleteAsync(int id);
        Task ReactToArticleAsync(int articleId, string userId, ReactionType reaction);
        //Task AddCommentAsync(int articleId, string content);
        //Task<IEnumerable<ArticleComment>> GetCommentsAsync(int articleId);
        //Task<int> CountReactionsAsync(int articleId, ReactionType reactionType);
    }
}
