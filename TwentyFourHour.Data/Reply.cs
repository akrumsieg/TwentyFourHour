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
        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(Comments))]
        public int CommentId { get; set; }
        public virtual Comment Comments { get; set; }
    }
}