using System.Collections.Generic;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;

namespace FanFiction.Data.Mocks
{
    public class MockStories : IAllStories
    {
        public IEnumerable<Story> Stories =>
            new List<Story>
            {
                new Story
                {
                    UserId = 1,
                    Title = "A fugitive from the past",
                    ShortDescription = "Severus Snape and Dylan Burke, who by the will of fate fell into the body " +
                                       "of Sirius Black, are trying to find out what happened in 1981 in " +
                                       "Godric's Hollow with the Potters and Voldemort, at the same time planning " +
                                       "to slightly restore order in the wizarding world at their discretion.",
                    Fandom = "Harry Potter",
                    Likes = 182,
                    Rating = (float) 4.1
                }
            };

        public Story GetObjectStory(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}