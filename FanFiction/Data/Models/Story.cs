namespace FanFiction.Data.Models
{
    public class Story
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Fandom { get; set; }
        public int Likes { get; set; }
        public float Rating { get; set; }
    }
}