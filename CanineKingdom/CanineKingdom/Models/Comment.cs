using System.ComponentModel.DataAnnotations.Schema;

namespace CanineKingdom.Models
{
    public class Comment 
    {
        public int Id { get; set; }
        public int ArticleId { get; set; } 
        [ForeignKey("ArticleId")]
        public string CommentText { get; set; }
        public string CreatedAt { get; set; }

        public Article Articles { get; set; }
    }
}
