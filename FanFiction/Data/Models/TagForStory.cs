namespace FanFiction.Data.Models
{
    public class TagForStory
    {
        public int Id { get; set; }
        public int? StoryId { get; set; }
        public Story Story { get; set; }
        public int? TagId { get; set; }
        public Tag Tag { get; set; }
    }
}