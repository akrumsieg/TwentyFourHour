using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFourHour.Data;
using TwentyFourHour.Models;

namespace TwentyFourHour.Services
{
    public class CommentService
    {
        private readonly Guid _authorId;

        public PostService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                AuthorId = model.AuthorId,
                CommentText = model.CommentText,
                CreatedUtc = DateTimeOffset.UtcNow
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
