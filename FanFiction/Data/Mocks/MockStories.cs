using System.Collections.Generic;
using System.Net.Sockets;
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
                    Title = "A fugitive from the past",
                    ShortDescription = "Short Description",
                    Fandom = "Harry Potter",
                    Tags =
                    {
                        new Tag { Text = "Harry Potter" },
                        new Tag { Text = "Severus Snape" },
                        new Tag { Text = "Adventures" }
                    },
                    Chapters =
                    {
                        new Chapter
                        {
                            Title = "Chapter 1",
                            Text = "Сознание прояснялось толчками в такт стуку сердца. " +
                                   "Потоки крови, струившейся в венах, казалось, воскрешали не только скованное " +
                                   "смертельным холодом тело, но и саму душу, возвращавшуюся из бездны небытия, " +
                                   "захлестывая ее неимоверными ликованием и счастьем.",
                            Image = "Image",
                            Likes = 12
                        },
                        new Chapter
                        {
                            Title = "Chapter 2",
                            Text = "Северус в своих апартаментах быстро заживил небольшую " +
                                   "рану на плече и привел в порядок мантию, несколько пострадавшую " +
                                   "после «прогулки» по туннелю до Визжащей хижины и обратно.",
                            Image = "Image",
                            Likes = 10
                        },
                        new Chapter
                        {
                            Title = "Chapter 3",
                            Text = "В служивший тайным убежищем дом, затерянный среди практически " +
                                   "девственных лесов, Северус аппарировал ближе к вечеру. Увидев нацеленную" +
                                   "в него его же трофейную палочку, он лишь ухмыльнулся, сумев скрыть " +
                                   "собственные опасения — Бэрк в свое время считался выдающимся магом, " +
                                   "но как обстояли дела сейчас, требовалось еще выяснить.",
                            Image = "Image",
                            Likes = 18
                        }
                    },
                    Comments =
                    {
                        new Comment 
                        { 
                            StoryId = 1,
                            UserId = 1,
                            Text = "Ух, экшн пошёл. Вы бы хоть предупредили в начале главы, " +
                                      "а то как теперь следующей ждать? Все ногти сгрызу!" 
                        }
                    },
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