using System.Collections.Generic;
using FanFiction.Data.Interfaces;
using FanFiction.Data.Models;

namespace FanFiction.Data.Repository
{
    public class CommentRepository : IAllComments
    {
        private readonly AppDbContext _appDbContext;

        public CommentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Comment> Comments => _appDbContext.Comment;
    }
}