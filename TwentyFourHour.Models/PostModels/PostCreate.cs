using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHour.Models.PostModels
{
    public class PostCreate
    {
        [Required]
        public string PostTitle { get; set; }
        
        [Required]
        public string PostText { get; set; }
    }
}
