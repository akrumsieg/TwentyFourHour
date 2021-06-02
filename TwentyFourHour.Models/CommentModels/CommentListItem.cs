using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHour.Models.CommentModels
{
    public class CommentListItem
    {
        public int CommentId { get; set; }
        public Guid AuthorId { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        [Required]
        [MinLength(100, ErrorMessage = "Please make comment 100 characters long.")]
        [MaxLength(2000)]
        public string CommentText { get; set; }
    }
}
