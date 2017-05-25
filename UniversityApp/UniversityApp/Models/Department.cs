using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Models
{
    public class Department
    {
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<Student> Students { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}