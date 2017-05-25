using GoContributeMe.Models.Model;
using System.Data.Entity;

namespace GoContributeMe.Context
{
    public class GoContributeMeDB : DbContext
    {

        //public DoctorsPointDb():base("Your Database name Link")
        //{

        //}
        public DbSet<User> User { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Contribution> Contribution { get; set; }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<Subscriber> Subscriber { get; set; }

        public System.Data.Entity.DbSet<GoContributeMe.Models.ViewModel.ViewAllDataInfo> ViewAllDataInfoes { get; set; }

    }
}