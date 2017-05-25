using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HTMLHelperApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Provide your name")]
        [StringLength(10, MinimumLength = 3)]
        [DisplayName("Employee Name")]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Provide your email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please provide valid email")]
        public string Email { get; set; }
        [StringLength(6)]
        [Required(ErrorMessage = "Select gender")]
        public string Gender { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "Select department")]
        public string Department { get; set; }
        [StringLength(300)]
        [Required(ErrorMessage = "Provide your address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Provide your password")]
        [StringLength(10, MinimumLength = 6)]
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
    }
}