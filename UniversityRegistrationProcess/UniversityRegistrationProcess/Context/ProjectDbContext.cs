using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Context
{
    public class ProjectDbContext:DbContext
    {
        public ProjectDbContext()
            : base("StudentRegistrationProcess")
        {
            
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<AssignTeacher> AssignTeachers { get; set; }
        public DbSet<Student> Students { get; set; }
      
    }
}