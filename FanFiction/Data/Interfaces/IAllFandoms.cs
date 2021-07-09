using System.Collections.Generic;
using FanFiction.Data.Models;

namespace FanFiction.Data.Interfaces
{
    public interface IAllFandoms
    {
        IEnumerable<Fandom> Fandoms { get; }
        Fandom GetObjectFandom(int id);
    }
}