namespace SocialMediaExample.Entities
{
    public class Post
    {
        public int IdPost { get; set; }
        public int IdUser { get; set; }
        public DateTime Date { get; set; }
        public required string Description { get; set; }
    }
}
