using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FanFiction.Data;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;
using FanFiction.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace FanFiction.Controllers
{
    public class StoriesController : Controller
    {
        private readonly IAllStories _allStories;
        private readonly IAllChapters _allChapters;
        private readonly IAllFandoms _allFandoms;

        public StoriesController(IAllStories iAllStories, IAllChapters iAllChapters, IAllFandoms iAllFandoms)
        {
            _allStories = iAllStories;
            _allChapters = iAllChapters;
            _allFandoms = iAllFandoms;
        }

        public ViewResult MyStories()
        {
            ViewBag.Title = "My Stories";
            StoriesListViewModel obj = new StoriesListViewModel
            {
                AllStories = _allStories.Stories,
                AllChapters = _allChapters.Chapters
            };
            return View(obj);
        }

        public IActionResult NewStory()
        {
            ViewBag.Title = "Create Story";
            StoriesListViewModel obj = new StoriesListViewModel {AllFandoms = _allFandoms.Fandoms};
            return View(obj);
        }

        private UserManager<IdentityUser> _userManager;

        public IActionResult Create(AppDbContext context, string storyTitle, string storyShortDescription,
            string fandom, string[] chaptersTitles, string[] chaptersText, string image)
        {
            context.AddRange(
                new Story
                {
                    UserId = Convert.ToInt32(_userManager.GetUserId(User)),
                    LastUpdateDate = DateTime.Now,
                    Title = storyTitle,
                    ShortDescription = storyShortDescription,
                    FandomId = Convert.ToInt32(context.Fandom
                        .Where(f => f.Name == fandom).Select(f => f.Id)),
                    Likes = 0,
                    Rating = 0
                });
            context.SaveChanges();

            for (int i = 1; i <= chaptersTitles.Length; i++)
            {
                context.AddRange(
                    new Chapter
                    {
                        StoryId = Convert.ToInt32(context.Story
                            .Where(s => s.Title == storyTitle).Select(s => s.Id)),
                        SequentialNumber = i,
                        Title = chaptersTitles[i - 1],
                        Text = chaptersText[i - 1],
                        Image = image,
                        Likes = 0
                    });
            }
            context.SaveChanges();

            return View("MyStories");
        }
    }
}