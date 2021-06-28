using System.Collections.Generic;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;

namespace FanFiction.Data.Repository
{
    public class TagForStoryRepository : IAllTagsForStories
    {
        private readonly AppDbContext _appDbContext;

        public TagForStoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<TagForStory> TagsForStory => _appDbContext.TagForStory;
    }
}