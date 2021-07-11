using System.Collections.Generic;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;

namespace FanFiction.Data.Mocks
{
    public class MockUsers : IAllUsers
    {
        public IEnumerable<User> Users =>
            new List<User>
            {
                new User
                {
                    Name = "Ivan Petrov",
                    Email = "i.petrov@example.com"
                }
            };

        public User GetObjectUser(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}