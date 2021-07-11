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
                    UserId = "83aecb0a-65c0-4cd5-9179-a771444d5c70",
                    Title = "Беглец из прошлого",
                    ShortDescription = "Северус Снейп и Дилан Бэрк, волею судьбы попавший в тело Сириуса Блэка," +
                                       " пытаются выяснить, что произошло в 1981 году в Годриковой Лощине" +
                                       " с Поттерами и Волдемортом, заодно планируя слегка " +
                                       "навести порядок в магическом мире по своему усмотрению.",
                    FandomId = 1,
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