using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChEBUTEApps.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Profile Picture")]
        public string ProfilePic { get; set; }
        [Required]
        public string Designation { get; set; }
    }
}