using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        [Required]
        [Display(Name = "Course Code")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
    }
}