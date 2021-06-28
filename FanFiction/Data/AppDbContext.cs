using FanFiction.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FanFiction.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Story> Story { get; set; }
        public DbSet<Chapter> Chapter { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<TagForStory> TagForStory { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}