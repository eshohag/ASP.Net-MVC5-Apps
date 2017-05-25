using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityRegistrationProcess.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string RegNo { get; set; }
        [Required(ErrorMessage = "Please Give a Student Name")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Not allow a Number")]

        public string Name { get; set; }
       
        [Required(ErrorMessage = "Give Your Email Address...")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Invalid Email Address")]
        [StringLength(500, ErrorMessage = "String Length Max-500 Charecters ")]
        public string Email { get; set; }
         [Required(ErrorMessage = "Give Your Emergency Contact Number...")]
         [Display(Name = "Contact Number")] 
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Give your Joining Date..")]
        public DateTime Date { get; set; }
       [Required(ErrorMessage = "Give Your Address..")]

        public string Address { get; set; }
       [Required(ErrorMessage = "Select Department...")]
       [Display(Name = "Department")] 

        public string DepartmentCode { get; set; }

    }
}