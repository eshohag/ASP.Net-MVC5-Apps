namespace GoContributeMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campaigns", "CategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Campaigns", "ContributionID", c => c.Int(nullable: false));
            CreateIndex("dbo.Campaigns", "CategoryID");
            CreateIndex("dbo.Campaigns", "ContributionID");
            AddForeignKey("dbo.Campaigns", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Campaigns", "ContributionID", "dbo.Contributions", "ContributionID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Campaigns", "ContributionID", "dbo.Contributions");
            DropForeignKey("dbo.Campaigns", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Campaigns", new[] { "ContributionID" });
            DropIndex("dbo.Campaigns", new[] { "CategoryID" });
            DropColumn("dbo.Campaigns", "ContributionID");
            DropColumn("dbo.Campaigns", "CategoryID");
        }
    }
}
