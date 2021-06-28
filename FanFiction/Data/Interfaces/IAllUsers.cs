using System.Collections.Generic;
using FanFiction.Data.Models;

namespace FanFiction.Data.Interfaces
{
    public interface IAllUsers
    {
        IEnumerable<User> Users { get; }
        User GetObjectUser(int id);
    }
}