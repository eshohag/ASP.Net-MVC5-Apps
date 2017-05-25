using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityRegistrationProcess.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Field Cann't blank...")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Minimum 5 characters long")]
        public string Code { get; set; }
         [Required(ErrorMessage = "Field Cann't blank...")]
        public string Name { get; set; }
         [Required(ErrorMessage = "Field Cann't blank...")]
         [Range(0.5, 5.0,ErrorMessage = "You must be ensure Cridit limit 0.5-5.0")]
        public decimal Credit { get; set; }
         [Required(ErrorMessage = "Field Cann't blank...")]
        public string Description { get; set; }
         [Required(ErrorMessage = "Field Cann't blank...")]
         [Display(Name = "Department")]  
        public int DepartmentId { get; set; }
         [Required(ErrorMessage = "Field Cann't blank...")]
         [Display(Name = "Semester")]  
        public int SemesterId { get; set; }

    }
}