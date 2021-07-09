using System.Collections.Generic;
using System.Linq;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;

namespace FanFiction.Data.Repository
{
    public class FandomRepository : IAllFandoms
    {
        private readonly AppDbContext _appDbContext;

        public FandomRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Fandom> Fandoms => _appDbContext.Fandom;
        public Fandom GetObjectFandom(int id) => _appDbContext.Fandom.FirstOrDefault(p => p.Id == id);
    }
}