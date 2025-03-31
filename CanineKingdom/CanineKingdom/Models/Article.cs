namespace CanineKingdom.Models
{
    public class Article : BaseClass
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PublishedAt { get; set; }

        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
