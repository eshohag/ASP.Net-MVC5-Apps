namespace UniversityApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            AddColumn("dbo.Students", "DepartmentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "DepartmentID");
            AddForeignKey("dbo.Students", "DepartmentID", "dbo.Departments", "DepartmentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DepartmentID" });
            DropColumn("dbo.Students", "DepartmentID");
            DropTable("dbo.Departments");
        }
    }
}
