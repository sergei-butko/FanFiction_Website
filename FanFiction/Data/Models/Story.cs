using System.Collections.Generic;

namespace FanFiction.Data.Models
{
    public class Story
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Fandom { get; set; }
        public List<string> Tags { get; set; }
        public List<Chapter> Chapters { get; set; }
        public List<string> Comments { get; set; }
        public int Likes { get; set; }
        public float Rating { get; set; }
    }
}