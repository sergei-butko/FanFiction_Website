using System.Collections.Generic;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;

namespace FanFiction.Data.Mocks
{
    public class MockComments : IAllComments
    {
        public IEnumerable<Comment> Comments =>
            new List<Comment>
            {
                new Comment
                {
                    StoryId = 1,
                    UserId = 1,
                    Text = "Ух, экшн пошёл. Вы бы хоть предупредили в начале главы, " +
                           "а то как теперь следующей ждать? Все ногти сгрызу!"
                }
            };
    }
}