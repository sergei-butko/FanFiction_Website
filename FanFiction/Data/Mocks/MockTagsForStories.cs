using System.Collections.Generic;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;

namespace FanFiction.Data.Mocks
{
    public class MockTagsForStories : IAllTagsForStories
    {
        public IEnumerable<TagForStory> TagsForStory =>
            new List<TagForStory>
            {
                new TagForStory
                {
                    StoryId = 2,
                    TagId = 1
                },
                new TagForStory
                {
                    StoryId = 2,
                    TagId = 2
                },
                new TagForStory
                {
                    StoryId = 2,
                    TagId = 3
                }
            };
    }
}