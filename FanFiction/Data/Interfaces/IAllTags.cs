using System.Collections.Generic;
using FanFiction.Data.Models;

namespace FanFiction.Data.Interfaces
{
    public interface IAllTags
    {
        IEnumerable<Tag> Tags { get; }
        Tag GetObjectTag(int id);
    }
}