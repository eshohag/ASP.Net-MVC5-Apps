using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Email { get; set; }
        public virtual Address Address { get; set; }
        [Required]

        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

    }
}