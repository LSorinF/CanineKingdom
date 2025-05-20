using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanineKingdom.Models
{
    public class Comment : BaseClass
    {
        [Required]
        public string CommentText { get; set; }  // ✅ Renamed from Content

        public DateTime PostedAt { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }       // ✅ Renamed from AuthorId
        public ApplicationUser User { get; set; } // ✅ Renamed from Author

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public ICollection<CommentReaction> Reactions { get; set; }
    }

}
