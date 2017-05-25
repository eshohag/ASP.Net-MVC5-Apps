using System.Data.Entity;
using UniversityApp.Models;

namespace UniversityApp.Context
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext() : base("AzureDatabaseConnect") { }    //Constrator 

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}