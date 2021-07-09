using System;

namespace FanFiction.Data.Models
{
    public class Story
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public int? FandomId { get; set; }
        public Fandom Fandom { get; set; }
        public int Likes { get; set; }
        public float Rating { get; set; }
    }
}