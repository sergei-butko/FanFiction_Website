using System.Collections.Generic;
using FanFiction.Data.Models;

namespace FanFiction.Data.Interfaces
{
    public interface IAllTagsForStories
    {
        IEnumerable<TagForStory> TagsForStory { get; }
    }
}