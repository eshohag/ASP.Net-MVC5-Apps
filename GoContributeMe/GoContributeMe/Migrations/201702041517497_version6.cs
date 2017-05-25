namespace GoContributeMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campaigns", "RecipientName", c => c.String(nullable: false));
            DropColumn("dbo.Campaigns", "RecipientFirstName");
            DropColumn("dbo.Campaigns", "RecipientLastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Campaigns", "RecipientLastName", c => c.String(nullable: false));
            AddColumn("dbo.Campaigns", "RecipientFirstName", c => c.String(nullable: false));
            DropColumn("dbo.Campaigns", "RecipientName");
        }
    }
}
