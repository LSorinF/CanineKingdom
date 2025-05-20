using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanineKingdom.Models
{
    public class CommentReaction : BaseClass
    {
        public int UserAccountNumber { get; set; }
        public ApplicationUser User { get; set; }

        public int? ArticleCommentId { get; set; }
        //public ArticleComment ArticleComment { get; set; }

        public ReactionType Reaction { get; set; }
    }
}
