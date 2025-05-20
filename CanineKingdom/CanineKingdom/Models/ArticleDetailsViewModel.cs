namespace CanineKingdom.Models
{
    public class ArticleDetailsViewModel
    {
        public Article Article { get; set; }
        //public IEnumerable<ArticleComment> ArticleComments { get; set; }

        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
    }
}

