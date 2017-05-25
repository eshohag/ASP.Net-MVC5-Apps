using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApp.Models
{
    public class Address
    {
        [Key, ForeignKey("Student")]
        public int StudentID { get; set; }
        [Required]
        public string District { get; set; }

        public virtual Student Student { get; set; }
    }
}