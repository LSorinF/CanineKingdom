namespace CanineKingdom.Models
{
    public class Breed : BaseClass
    {
        public string Name { get; set; }
        public string Size { get; set; }

        public string Origin { get; set; }
        public string HairSize {  get; set; }

        public int Lifespan { get; set; }

        public string Classification { get; set; }
    }
}
