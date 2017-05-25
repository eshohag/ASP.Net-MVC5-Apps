using GoContributeMe.Models.Model;

namespace GoContributeMe.Models.ViewModel
{
    public class ContactUsUserViewModel
    {
        public User User { get; set; }
        public ContactUs ContactUs { get; set; }
        public Contribution Contribution { get; set; }
        public Category Category { get; set; }
        public Campaign Campaign { get; set; }
        public Subscriber Subscriber { get; set; }
    }
}