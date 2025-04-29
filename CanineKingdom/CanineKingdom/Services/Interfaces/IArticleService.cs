using CanineKingdom.Models;

namespace CanineKingdom.Services.Interfaces
{
    public interface IArticleService
    {
        Task<List<Article>> GetAllArticlesAsync();
        Task<List<Article>> SearchArticlesByTitleAsync(string searchString);
        Task<Article> GetArticleDetailsAsync(int? id);
        Task<bool> CreateArticleAsync(Article article);
        Task<Article> GetArticleForEditAsync(int? id);
        Task<bool> UpdateArticleAsync(int id, Article article);
        Task<Article> GetArticleForDeleteAsync(int? id);
        Task<bool> DeleteArticleAsync(int id);
        Task<bool> ArticleExistsAsync(int id);
    }
}
