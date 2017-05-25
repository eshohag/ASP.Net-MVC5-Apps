using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityRegistrationProcess.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [Required(ErrorMessage = "Field Cann't blank...")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Not allow a Number")]
       
        public string Name { get; set; }
        [Required(ErrorMessage = "Field Cann't blank...")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Invalid Email Address")]
        [StringLength(500,ErrorMessage = "String Length Max-500 Charecters ")]
       public string Email { get; set; }
        [Required(ErrorMessage = "Field Cann't blank...")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Field Cann't blank...")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Field Cann't blank...")]
        [Display(Name = "Designation")] 
        public int DesignationId { get; set; }
        [Required(ErrorMessage = "Field Cann't blank...")]
        [Display(Name = "Department")] 
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Field Cann't blank...")]
        [Display(Name = "Cridit To Be Taken")]
        [Range(0.0, Double.MaxValue,ErrorMessage = "Negative Number not Accepted")]
        public decimal CreditToBeTaken { get; set; }

        public decimal RemainingCredit { get; set; }
    }
}