using FanFiction.Data.Interfaces;
using FanFiction.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FanFiction.Controllers
{
    public class StoriesController : Controller
    {
        private readonly IAllStories _allStories;
        private readonly IAllChapters _allChapters;

        public StoriesController(IAllStories iAllStories, IAllChapters iAllChapters)
        {
            _allStories = iAllStories;
            _allChapters = iAllChapters;
        }

        public ViewResult Story()
        {
            ViewBag.Title = "Fanfic Page";
            StoriesListViewModel obj = new StoriesListViewModel {AllStories = _allStories.Stories, 
                AllChapters = _allChapters.Chapters};
            return View(obj);
        }
    }
}