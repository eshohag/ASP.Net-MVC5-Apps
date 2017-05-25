namespace UniversityApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Addresses", new[] { "StudentId" });
            CreateIndex("dbo.Addresses", "StudentID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Addresses", new[] { "StudentID" });
            CreateIndex("dbo.Addresses", "StudentId");
        }
    }
}
