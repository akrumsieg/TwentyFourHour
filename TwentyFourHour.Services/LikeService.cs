using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFourHour.Data;
using TwentyFourHour.Models.LikeModels;

namespace TwentyFourHour.Services
{
    public class LikeService
    {
        //field
        private readonly Guid _userId;

        //constructor
        public LikeService(Guid userId)
        {
            _userId = userId;
        }

        //methods
        //create
        public bool CreateLike(LikeCreate model)
        {
            var entity = new Like()
            {
                PostId = model.PostId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


    }
}
