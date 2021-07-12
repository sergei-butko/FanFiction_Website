using System;
using System.ComponentModel.DataAnnotations;

namespace FanFiction.Data.Models
{
    public class Story
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)] public string ShortDescription { get; set; }
        public int? FandomId { get; set; }
        public Fandom Fandom { get; set; }
        public int Likes { get; set; }
        public float Rating { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}