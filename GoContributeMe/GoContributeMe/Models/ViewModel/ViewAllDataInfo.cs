using System;

namespace GoContributeMe.Models.ViewModel
{
    public class ViewAllDataInfo
    {
        public int ViewAllDataInfoID { get; set; }
        public int CampaignID { get; set; }

        public string Tittle { get; set; }

        public string CategoriesName { get; set; }
        public string ContributionsName { get; set; }


        public string Descriptions { get; set; }

        public string RecipientName { get; set; }


        public string RecipientNID { get; set; }

        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string TargetAmount { get; set; }
        public DateTime CampaignClosingDate { get; set; }
    }
}