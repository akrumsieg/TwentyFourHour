﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHour.Data
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }
        [Required]
        public string ReplyText { get; set; }
        [Required]
        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
