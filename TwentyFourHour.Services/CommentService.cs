using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFourHour.Data;
using TwentyFourHour.Models;
using TwentyFourHour.Models.CommentModels;

namespace TwentyFourHour.Services
{
    public class CommentService
    {
        private readonly Guid _authorId;

        public CommentService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                AuthorId = _authorId,
                CommentText = model.CommentText,
                CreatedUtc = DateTimeOffset.UtcNow
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments
                    .Where(e => e.AuthorId == _authorId)
                    .Select(
                        e =>
                            new CommentListItem
                            {
                                CommentId = e.CommentId,
                                CommentText = e.CommentText,
                                CreatedUtc = e.CreatedUtc
                            }
                            );
                return query.ToArray();
            }
        }

        public CommentDetail GetCommentByPost(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.CommentId == id && e.AuthorId == _authorId);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        CommentText = entity.CommentText,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
    }
}

