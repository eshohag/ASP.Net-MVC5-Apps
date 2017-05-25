namespace HTMLHelperApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 10),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
