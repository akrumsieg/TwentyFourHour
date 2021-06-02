using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHour.Models.ReplyModels
{
    public class ReplyListItem
    {
        public int ReplyId { get; set; }
        public string Content { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
