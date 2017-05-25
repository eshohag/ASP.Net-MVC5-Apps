using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChEBUTEApps.Models
{
    public class Notice
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Level Number")]
        public string LevelNumber { get; set; }
        [Required]
        [Display(Name = "Term Number")]
        public string TermNumber { get; set; }
        [Required]

        public string Section { get; set; }
        [Required]
        public string Description { get; set; }
    }
}