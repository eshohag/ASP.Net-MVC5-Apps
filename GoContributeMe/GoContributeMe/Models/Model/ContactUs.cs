
using System;
using System.ComponentModel.DataAnnotations;

namespace GoContributeMe.Models.Model
{
    public class ContactUs
    {

        public int ContactUsID { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please provide valid email")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Field can't be empty description")]
        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}