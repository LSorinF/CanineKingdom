namespace CanineKingdom.Models
{
    public class Review : BaseClass
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string PublishedAt { get; set; }

        public User User { get; set; }
    }
}
