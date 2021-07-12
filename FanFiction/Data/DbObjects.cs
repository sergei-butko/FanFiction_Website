using System;
using FanFiction.Data.Models;
using System.Linq;

namespace FanFiction.Data
{
    public class DbObjects
    {
        public static void Initial(AppDbContext context)
        {
            if (!context.Fandom.Any())
            {
                context.AddRange(
                    new Fandom {Name = "Harry Potter"});
            }

            if (!context.Story.Any())
            {
                context.AddRange(
                    new Story
                    {
                        UserId = "83aecb0a-65c0-4cd5-9179-a771444d5c70",
                        LastUpdateDate = DateTime.Now,
                        Title = "A fugitive from the past",
                        ShortDescription =
                            "Severus Snape and Dylan Burke, who by the will of fate fell into the body " +
                            "of Sirius Black, are trying to find out what happened in 1981 in " +
                            "Godric's Hollow with the Potters and Voldemort, at the same time planning " +
                            "to slightly restore order in the wizarding world at their discretion.",
                        FandomId = 1,
                        Likes = 182,
                        Rating = (float) 4.1
                    });
            }

            if (!context.Chapter.Any())
            {
                context.AddRange(
                    new Chapter
                    {
                        StoryId = 2,
                        SequentialNumber = 1,
                        Title = "Chapter 1",
                        Text = "Сознание прояснялось толчками в такт стуку сердца. " +
                               "Потоки крови, струившейся в венах, казалось, воскрешали не только скованное " +
                               "смертельным холодом тело, но и саму душу, возвращавшуюся из бездны небытия, " +
                               "захлестывая ее неимоверными ликованием и счастьем.",
                        Image = "",
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
                        Image = "",
                        Likes = 10
                    },
                    new Chapter
                    {
                        StoryId = 2,
                        SequentialNumber = 3,
                        Title = "Chapter 3",
                        Text = "В служивший тайным убежищем дом, затерянный среди практически " +
                               "девственных лесов, Северус аппарировал ближе к вечеру. Увидев нацеленную " +
                               "в него его же трофейную палочку, он лишь ухмыльнулся, сумев скрыть " +
                               "собственные опасения — Бэрк в свое время считался выдающимся магом, " +
                               "но как обстояли дела сейчас, требовалось еще выяснить.",
                        Image = "",
                        Likes = 18
                    });
            }

            if (!context.Tag.Any())
            {
                context.AddRange(
                    new Tag {Text = "Harry Potter"},
                    new Tag {Text = "Severus Snape"},
                    new Tag {Text = "Adventures"});
            }

            if (!context.TagForStory.Any())
            {
                context.AddRange(
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
                    });
            }

            if (!context.Comment.Any())
            {
                context.AddRange(
                    new Comment
                    {
                        StoryId = 2,
                        UserId = "83aecb0a-65c0-4cd5-9179-a771444d5c70",
                        Text = "Ух, экшн пошёл. Вы бы хоть предупредили в начале главы, " +
                               "а то как теперь следующей ждать? Все ногти сгрызу!"
                    });
            }

            context.SaveChanges();
        }
    }
}