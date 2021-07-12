using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using FanFiction.Data;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;
using FanFiction.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FanFiction.Controllers
{
    public class StoriesController : Controller
    {
        private static UserManager<IdentityUser> _userManager;

        private readonly IAllStories _allStories;
        private readonly IAllChapters _allChapters;
        private readonly IAllFandoms _allFandoms;
        private readonly AppDbContext _context;

        public StoriesController(IAllStories iAllStories, IAllChapters iAllChapters, IAllFandoms iAllFandoms,
            AppDbContext context)
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

        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Edit Story";
            if (id == null)
            {
                return new NotFoundResult();
            }

            Story story = _context.Story.Find(id);
            if (story != null)
            {
                return View(story);
            }

            return new NotFoundResult();
        }

        [HttpPost]
        public ActionResult Edit(Story story)
        {
            _context.Entry(story).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("MyStories");
        }

        [HttpPost]
        public IActionResult NewStory(string storyTitle, string storyShortDescription,
            string fandom, string[] tags)
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
            _context.SaveChanges();

            return RedirectToAction("MyStories");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Story story = _context.Story.Find(id);
            if (story == null)
            {
                return new NotFoundResult();
            }

            return View(story);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Story story = _context.Story.Find(id);
            if (story == null)
            {
                return new NotFoundResult();
            }

            _context.Story.Remove(story);
            _context.SaveChanges();
            return RedirectToAction("MyStories");
        }
    }
}