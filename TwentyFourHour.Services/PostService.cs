using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFourHour.Data;
using TwentyFourHour.Models.PostModels;

namespace TwentyFourHour.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                            e => new PostListItem
                            {
                                PostId = e.PostId,
                                PostTitle = e.PostTitle,
                                PostText = e.PostText,
                                ListOfComments = e.ListOfComments,
                                ListOfLikes = e.ListOfLikes
                            });

                return query.ToArray();
            }
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post
                {
                    AuthorId = _userId,
                    PostTitle = model.PostTitle,
                    PostText = model.PostText
                };
            
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
