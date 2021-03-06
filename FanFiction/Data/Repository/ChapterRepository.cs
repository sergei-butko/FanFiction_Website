using System.Collections.Generic;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;

namespace FanFiction.Data.Repository
{
    public class ChapterRepository : IAllChapters
    {
        private readonly AppDbContext _appDbContext;

        public ChapterRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Chapter> Chapters => _appDbContext.Chapter;
    }
}