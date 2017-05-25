namespace GoContributeMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campaigns", "Descriptions", c => c.String(nullable: false));
            DropColumn("dbo.Campaigns", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Campaigns", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Campaigns", "Descriptions");
        }
    }
}
