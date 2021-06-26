using System.Collections.Generic;
using System.Linq;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;

namespace FanFiction.Data.Repository
{
    public class StoryRepository : IAllStories
    {
        private readonly AppDbContext appDbContext;

        public StoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Story> Stories => appDbContext.Story;
        public Story GetObjectStory(int id) => appDbContext.Story.FirstOrDefault(p => p.Id == id);
    }
}