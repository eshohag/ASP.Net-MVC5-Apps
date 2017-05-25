using HTMLHelperApp.Models;

namespace HTMLHelperApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HTMLHelperApp.Context.ProjectDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HTMLHelperApp.Context.ProjectDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.Employees.AddOrUpdate(
            //    new Employee { Name = "Akram", Gender = "Male", Department = "HR", Email = "akram@mail.com", Address = "Bangladesh", Password = "123456", ConfirmPassword = "123456" }
            //    );
        }
    }
}
