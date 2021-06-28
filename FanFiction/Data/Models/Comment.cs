﻿namespace FanFiction.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int? StoryId { get; set; }
        public Story Story { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
    }
}