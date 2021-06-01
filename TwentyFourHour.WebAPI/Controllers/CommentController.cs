using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TwentyFourHour.Services;

namespace TwentyFourHour.WebAPI.Controllers
{
    public class CommentController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var authorId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(authorId);
            return commentService;
        }
    }
}
