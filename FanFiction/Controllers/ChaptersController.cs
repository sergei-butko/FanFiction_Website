using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FanFiction.Data;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;
using FanFiction.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FanFiction.Controllers
{
    public class ChaptersController : Controller
    {
        private static UserManager<IdentityUser> _userManager;

        private readonly IAllStories _allStories;
        private readonly IAllChapters _allChapters;
        private readonly AppDbContext _context;

        public ChaptersController(IAllStories iAllStories, IAllChapters iAllChapters, AppDbContext context)
        {
            _allStories = iAllStories;
            _allChapters = iAllChapters;
            _context = context;
        }

        public IActionResult AddChapter()
        {
            ViewBag.Title = "Add Chapter";
            StoriesListViewModel obj = new StoriesListViewModel
            {
                AllStories = _allStories.Stories,
                AllChapters = _allChapters.Chapters
            };
            return View(obj);
        }

        public IActionResult StoryChapters(int storyId)
        {
            ViewBag.Title = "Story Chapters";
            List<Chapter> chapters = _context.Chapter.Where(c => c.StoryId == storyId).ToList();
            return View(chapters);
        }

        [HttpPost]
        public IActionResult AddChapter(string storyTitle, string chapterTitle, string chapterText, string image)
        {
            image ??= "";
            List<Chapter> chapters = _allChapters.Chapters.ToList();
            List<Story> stories = _allStories.Stories.ToList();

            var num = from c in chapters
                join s in stories on c.StoryId equals s.Id
                where s.Title == storyTitle
                orderby c.SequentialNumber
                select c.SequentialNumber;
            
                Chapter chapter = new Chapter
                {
                    StoryId = _context.Story.Where(s => s.Title == storyTitle).Select(s => s.Id).FirstOrDefault(),
                    SequentialNumber = 1,
                    Title = chapterTitle,
                    Text = chapterText,
                    Image = image,
                    Likes = 0
                };
            _context.AddRange(chapter);
            _context.SaveChanges();

            return RedirectToAction("MyStories", "Stories");
        }

        public ActionResult Read(int id)
        {
            Chapter chapter = _context.Chapter.FirstOrDefault(c => c.Id == id);
            return View(chapter);
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Edit Chapter";
            if (id == null)
            {
                return new NotFoundResult();
            }

            Chapter chapter = _context.Chapter.Find(id);
            if (chapter != null)
            {
                return View(chapter);
            }

            return new NotFoundResult();
        }

        [HttpPost]
        public ActionResult Edit(Chapter chapter)
        {
            _context.Entry(chapter).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("MyStories", "Stories");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Chapter chapter = _context.Chapter.Find(id);
            if (chapter == null)
            {
                return new NotFoundResult();
            }

            return View(chapter);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Chapter chapter = _context.Chapter.Find(id);
            if (chapter == null)
            {
                return new NotFoundResult();
            }

            _context.Chapter.Remove(chapter);
            _context.SaveChanges();
            return RedirectToAction("StoryChapters");
        }
    }
}