using System.Collections.Generic;
using FanFiction.Data.Models;

namespace FanFiction.Data.Interfaces
{
    public interface IAllComments
    {
        IEnumerable<Comment> Comments { get; }
    }
}