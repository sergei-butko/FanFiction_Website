using System.Collections.Generic;
using FanFiction.Data.Models;

namespace FanFiction.Data.Interfaces
{
    public interface IAllChapters
    {
        IEnumerable<Chapter> AllChapters { get; }
    }
}