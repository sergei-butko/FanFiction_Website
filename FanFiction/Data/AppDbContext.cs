using FanFiction.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FanFiction.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> User { get; set; }
        public DbSet<Story> Story { get; set; }
        public DbSet<Fandom> Fandom { get; set; }
        public DbSet<Chapter> Chapter { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<TagForStory> TagForStory { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("DefaultConnection");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}