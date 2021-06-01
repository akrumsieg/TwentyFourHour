using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFourHour.Data;

namespace TwentyFourHour.Models.PostModels
{
    public class PostListItem
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostText { get; set; }
        public virtual List<Comment> ListOfComments { get; set; }
        public virtual List<Like> ListOfLikes { get; set; }
    }
}
