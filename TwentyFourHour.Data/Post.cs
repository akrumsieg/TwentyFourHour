using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHour.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public string PostTitle { get; set; }

        [Required]
        public string PostText { get; set; }

        public virtual List<Comment> ListOfComments { get; set; }
        
        public virtual List<Like> ListOfLikes { get; set; }
    }
}
