using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanineKingdom.Models
{
    public class Comment : BaseClass
    {

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }

        public string CommentText { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public User? User { get; set; }
        public Article? Article { get; set; }
    }
}
