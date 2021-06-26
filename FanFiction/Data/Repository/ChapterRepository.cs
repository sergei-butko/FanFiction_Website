using System.Collections.Generic;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;

namespace FanFiction.Data.Repository
{
    public class ChapterRepository : IAllChapters
    {
        private readonly AppDbContext appDbContext;

        public ChapterRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Chapter> AllChapters => appDbContext.Chapter;
    }
}