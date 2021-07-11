using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using FanFiction.Data;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;
using FanFiction.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace FanFiction.Controllers
{
    public class StoriesController : Controller
    {
        private static UserManager<IdentityUser> _userManager;
        
        private readonly IAllStories _allStories;
        private readonly IAllChapters _allChapters;
        private readonly IAllFandoms _allFandoms;
        private readonly AppDbContext _context;
        
        public StoriesController(IAllStories iAllStories, IAllChapters iAllChapters, IAllFandoms iAllFandoms, AppDbContext context)
        {
            _allStories = iAllStories;
            _allChapters = iAllChapters;
            _allFandoms = iAllFandoms;
            _context = context;
        }

        public ViewResult MyStories()
        {
            ViewBag.Title = "My Stories";
            StoriesListViewModel obj = new StoriesListViewModel
            {
                AllStories = _allStories.Stories,
                AllChapters = _allChapters.Chapters,
                AllFandoms = _allFandoms.Fandoms
            };
            return View(obj);
        }

        public IActionResult NewStory()
        {
            ViewBag.Title = "Create Story";
            StoriesListViewModel obj = new StoriesListViewModel {AllFandoms = _allFandoms.Fandoms};
            return View(obj);
        }
        
        [HttpPost]
        public IActionResult NewStory(string storyTitle, string storyShortDescription,
            string fandom, string[] tags, string[] chaptersTitles, string[] chaptersText, string image)
        {
            _context.AddRange(new Story
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                Title = storyTitle,
                ShortDescription = storyShortDescription,
                FandomId = _context.Fandom
                    .Where(f => f.Name == fandom).Select(f => f.Id).Single(),
                Likes = 0,
                Rating = 0,
                LastUpdateDate = DateTime.Now
            });
            
            for (int i = 1; i <= chaptersTitles.Length; i++)
            {
               new Chapter
                    {
                        StoryId = Convert.ToInt32(_context.Story
                            .Where(s => s.Title == storyTitle).Select(s => s.Id)),
                        SequentialNumber = i,
                        Title = chaptersTitles[i - 1],
                        Text = chaptersText[i - 1],
                        Image = image,
                        Likes = 0
                    };
            }
            _context.SaveChanges();

            return View("MyStories");
        }
    }
}