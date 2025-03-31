namespace CanineKingdom.Models
{
    public class Favorite : BaseClass
    {
        public int UserId { get; set; }
        public int BreedId { get; set; }
        public string CreatedAt { get; set; }

        public User User { get; set; }
    }
}
