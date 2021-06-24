using FanFiction.Data.Interfaces;
using FanFiction.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FanFiction.Controllers
{
    public class StoriesController : Controller
    {
        private readonly IAllStories _allStories;

        public StoriesController(IAllStories iAllStories)
        {
            _allStories = iAllStories;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Fanfic Page";
            StoriesListViewModel obj = new StoriesListViewModel {AllStories = _allStories.Stories};
            return View(obj);
        }
    }
}