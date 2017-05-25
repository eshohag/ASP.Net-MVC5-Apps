using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChEBUTEApps.Models
{
    public class NewUpload
    {
        public int ID { get; set; }
        [Required]
        public string Team { get; set; }
        [Required]

        public string Section { get; set; }
        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Required]
        [Display(Name = "Exam Name")]

        public string ExamName { get; set; }
        [Required]
        [Display(Name = "Total Mark")]

        public decimal TotalMark { get; set; }
    }
}