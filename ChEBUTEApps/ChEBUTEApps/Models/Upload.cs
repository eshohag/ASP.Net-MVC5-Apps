using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChEBUTEApps.Models
{
    public class Upload
    {
        public int ID { get; set; }
        [Required]
        public HttpPostedFileBase Files { get; set; }
        [Display(Name = "Specific ID")]
        public string SpecificID { get; set; }

        [Display(Name = "Start ID")]
        public string StartID { get; set; }


        [Display(Name = "Ending ID")]
        public string EndingID { get; set; }

        [Required]
        public int BatchID { get; set; }

    }
}