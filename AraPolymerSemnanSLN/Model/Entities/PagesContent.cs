using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Entities
{
    public class PagesContent
    {
        [Key]
        public int Serial { get; set; }
        [Required]
        public string PageName { get; set; }
        public string PageCaption { get; set; }
        public string Contents { get; set; }
    }
}
