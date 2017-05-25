using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChEBUTEApps.Models
{
    public class Login
    {
        public int ID { get; set; }
    [Display(Name="User Name or Email")]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string Message { get; set; }
    }
}