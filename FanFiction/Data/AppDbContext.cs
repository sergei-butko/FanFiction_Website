using FanFiction.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FanFiction.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Story> Story { get; set; }
        public DbSet<Chapter> Chapter { get; set; }
    }
}