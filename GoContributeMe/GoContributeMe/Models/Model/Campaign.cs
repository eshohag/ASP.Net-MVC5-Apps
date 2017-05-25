
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoContributeMe.Models.Model
{
    public class Campaign
    {
        public int CampaignID { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]

        public string Tittle { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [Display(Name = "Category Type")]
        public int CategoryID { get; set; }
        [Display(Name = "Category Type")]
        public Category Category { get; set; }


        [Required(ErrorMessage = "Field can't be empty")]
        public string Descriptions { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [Display(Name = "Contribution Type")]
        public int ContributionID { get; set; }
        [Display(Name = "Contribution Type")]
        public Contribution Contribution { get; set; }
        //public string Image { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [Display(Name = "Name")]
        public string RecipientName { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [Display(Name = "NID")]
        public string RecipientNID { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please provide valid email")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [Display(Name = "Mobile Number")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [Display(Name = "Target Amount")]
        public string TargetAmount { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [Display(Name = "Campaign Closing Date")]
        public DateTime CampaignClosingDate { get; set; }
        //[DisplayName("I accept terms and conditions")]
        //[RegularExpression("True", ErrorMessage = "You must accept the terms and conditions")]
        [Required]
        [NotMapped]
        public bool TermsConditions { get; set; }
    }
}