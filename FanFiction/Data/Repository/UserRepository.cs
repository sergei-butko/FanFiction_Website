using System.Collections.Generic;
using System.Linq;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;

namespace FanFiction.Data.Repository
{
    public class UserRepository:IAllUsers
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<User> Users => _appDbContext.User;
        public User GetObjectUser(int id) => _appDbContext.User.FirstOrDefault(p => p.Id == id);
    }
}