using System.Collections.Generic;
using System.Linq;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;

namespace FanFiction.Data.Repository
{
    public class TagRepository : IAllTags
    {
        private readonly AppDbContext _appDbContext;

        public TagRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Tag> Tags => _appDbContext.Tag;
        public Tag GetObjectTag(int id) => _appDbContext.Tag.FirstOrDefault(p => p.Id == id);
    }
}