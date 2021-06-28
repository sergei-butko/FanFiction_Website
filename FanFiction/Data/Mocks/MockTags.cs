using System.Collections.Generic;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;

namespace FanFiction.Data.Mocks
{
    public class MockTags : IAllTags
    {
        public IEnumerable<Tag> Tags =>
            new List<Tag>
            {
                new Tag {Text = "Harry Potter"},
                new Tag {Text = "Severus Snape"},
                new Tag {Text = "Adventures"}
            };

        public Tag GetObjectTag(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}