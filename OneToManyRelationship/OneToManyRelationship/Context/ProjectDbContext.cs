using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OneToManyRelationship.Models;

namespace OneToManyRelationship.Context
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; } 
    }
}