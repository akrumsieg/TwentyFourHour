using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHour.Models
{
    public class CommentCreate
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        [MinLength(25, ErrorMessage = "Please make comment 100 characters long.")]
        [MaxLength(2000)]
        public string CommentText { get; set; }
    }
}
