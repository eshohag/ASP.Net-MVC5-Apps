
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoContributeMe.Models.Model
{
    public class User
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please provide valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field can't be empty user Name")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
    }
}