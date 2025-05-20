using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanineKingdom.Models
{
    public class ArticleReaction : BaseClass
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int UserAccountNumber { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public ReactionType Reaction { get; set; }

    }
    public enum ReactionType
    {
        Like,
        Dislike
    }
}
