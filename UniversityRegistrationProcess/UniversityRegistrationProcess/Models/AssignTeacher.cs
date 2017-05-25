using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityRegistrationProcess.Models
{
    public class AssignTeacher
    {
        [Key]
        public int CourseAssignTeacherId { get; set; }
        [Required(ErrorMessage = "Select Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
         [Required(ErrorMessage = "Select Department")]
         [DisplayName("Teacher")]
        public int TeacherId { get; set; }
         public int CourseId { get; set; }
        [DisplayName("Credit To Be Taken")]
         public decimal CreditToBeTaken { get; set; }
        [DisplayName("Remaining Credit")]
        public decimal RemainingCredit { get; set; }
        [Required(ErrorMessage = "Select Course")]
        [DisplayName("Course")]
        public string CourseCode { get; set; }
        public string Name { get; set; }
        public decimal Credit { get; set; }


    }
}