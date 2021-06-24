using System.Collections.Generic;
using FanFiction.Data.Models;

namespace FanFiction.Data.Interfaces
{
    public interface IAllStories
    {
        IEnumerable<Story> Stories { get; }
        Story GetObjectStory(int id);
    }
}