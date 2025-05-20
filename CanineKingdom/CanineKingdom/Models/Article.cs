using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanineKingdom.Models
{
    public class Article : BaseClass
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishedAt { get; set; } = DateTime.UtcNow;

        public int AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        //public ICollection<ArticleComment> Comments { get; set; }
        public ICollection<ArticleReaction> Reactions { get; set; }
    }

}
