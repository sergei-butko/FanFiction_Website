using System.Collections.Generic;
using FanFiction.Data.Models;

namespace FanFiction.ViewModels
{
    public class StoriesListViewModel
    {
        public IEnumerable<Story> AllStories { get; init; }
        public IEnumerable<Chapter> AllChapters { get; init; }
    }
}