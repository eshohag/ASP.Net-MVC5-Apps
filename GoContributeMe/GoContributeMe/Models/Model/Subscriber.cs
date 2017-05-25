
using System.ComponentModel.DataAnnotations;

namespace GoContributeMe.Models.Model
{
    public class Subscriber
    {
        public int SubscriberID { get; set; }
        [Required]
        public string Email { get; set; }
    }
}