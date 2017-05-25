using GoContributeMe.Models.Model;

namespace GoContributeMe.Models.ViewModel
{
    public class ViewModelCampaign
    {
        public Contribution Contribution { get; set; }
        public Category Category { get; set; }
        public Campaign Campaign { get; set; }
    }
}