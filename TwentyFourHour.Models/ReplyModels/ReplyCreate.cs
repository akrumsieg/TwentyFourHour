using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHour.Models.ReplyModels
{
    public class ReplyCreate
    {
        [Required]
        public int CommentId { get; set; }

        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(800)]
        public string  Content  { get; set; }
    }
}
