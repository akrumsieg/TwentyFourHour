using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFourHour.Data;
using TwentyFourHour.Models.ReplyModels;

namespace TwentyFourHour.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;
        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    AuthorId = _userId,
                    ReplyText = model.Content,
                    CommentId = model.CommentId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyListItem> GetRepliesByCommentId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.CommentId == id)
                        .Select(e =>
                        new ReplyListItem
                        {
                            ReplyId = e.ReplyId,
                            Content = e.ReplyText
                        });
                return query.ToArray();
            }
        }
        public IEnumerable<ReplyListItem> GetRepliesByAuthorId()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                            e =>
                                new ReplyListItem
                                {
                                    ReplyId = e.ReplyId,
                                    Content = e.ReplyText
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
