using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HTMLHelperApp.Models;

namespace HTMLHelperApp.Context
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        //public ProjectDbContext()
        //    : base("ProjectDbContext")
        //{
            
        //}
    }
}