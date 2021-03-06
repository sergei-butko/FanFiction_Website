using System.Collections.Generic;
using System.Linq;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;

namespace FanFiction.Data.Repository
{
    public class StoryRepository : IAllStories
    {
        private readonly AppDbContext _appDbContext;

        public StoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Story> Stories => _appDbContext.Story;
        public Story GetObjectStory(int id) => _appDbContext.Story.FirstOrDefault(p => p.Id == id);
    }
}