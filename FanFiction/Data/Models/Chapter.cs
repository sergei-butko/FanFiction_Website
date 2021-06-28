namespace FanFiction.Data.Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public int? StoryId { get; set; }
        public Story Story { get; set; }
        public int SequentialNumber { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public int Likes { get; set; }
    }
}