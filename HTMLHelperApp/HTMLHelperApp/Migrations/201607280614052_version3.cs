namespace HTMLHelperApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employees", "Gender", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.Employees", "Department", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Employees", "Address", c => c.String(nullable: false, maxLength: 300));
            DropColumn("dbo.Employees", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Employees", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Department", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false));
        }
    }
}
