using System.Collections.Generic;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;

namespace FanFiction.Data.Mocks
{
    public class MockChapters : IAllChapters
    {
        public IEnumerable<Chapter> Chapters =>
            new List<Chapter>
            {
                new Chapter
                {
                    StoryId = 2,
                    SequentialNumber = 1,
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
                    StoryId = 2,
                    SequentialNumber = 2,
                    Title = "Chapter 2",
                    Text = "Северус в своих апартаментах быстро заживил небольшую " +
                           "рану на плече и привел в порядок мантию, несколько пострадавшую " +
                           "после «прогулки» по туннелю до Визжащей хижины и обратно.",
                    Image = "Image",
                    Likes = 10
                },
                new Chapter
                {
                    StoryId = 2,
                    SequentialNumber = 3,
                    Title = "Chapter 3",
                    Text = "В служивший тайным убежищем дом, затерянный среди практически " +
                           "девственных лесов, Северус аппарировал ближе к вечеру. Увидев нацеленную" +
                           "в него его же трофейную палочку, он лишь ухмыльнулся, сумев скрыть " +
                           "собственные опасения — Бэрк в свое время считался выдающимся магом, " +
                           "но как обстояли дела сейчас, требовалось еще выяснить.",
                    Image = "Image",
                    Likes = 18
                }
            };
    }
}