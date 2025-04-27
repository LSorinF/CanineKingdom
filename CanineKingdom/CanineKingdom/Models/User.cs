namespace CanineKingdom.Models
{
    public class User : BaseClass
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string? ProfilePicture { get; set; }
        public string Location { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}
