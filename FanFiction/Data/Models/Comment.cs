namespace FanFiction.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int? StoryId { get; set; }
        public Story Story { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
    }
}