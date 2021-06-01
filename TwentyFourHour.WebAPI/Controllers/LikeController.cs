using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TwentyFourHour.Models.LikeModels;
using TwentyFourHour.Services;

namespace TwentyFourHour.WebAPI.Controllers
{
    [Authorize]
    public class LikeController : ApiController
    {
        private LikeService CreateLikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LikeService(userId);
            return service;
        }

        //create
        public IHttpActionResult Post(LikeCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateLikeService();
            if (!service.CreateLike(model)) return InternalServerError();
            return Ok("Like was successfully created!");
        }
    }
}
