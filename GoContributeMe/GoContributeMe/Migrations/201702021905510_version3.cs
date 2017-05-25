namespace GoContributeMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Campaigns", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Campaigns", "ContributionID", "dbo.Contributions");
            DropIndex("dbo.Campaigns", new[] { "CategoryID" });
            DropIndex("dbo.Campaigns", new[] { "ContributionID" });
            DropColumn("dbo.Campaigns", "CategoryID");
            DropColumn("dbo.Campaigns", "ContributionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Campaigns", "ContributionID", c => c.Int(nullable: false));
            AddColumn("dbo.Campaigns", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Campaigns", "ContributionID");
            CreateIndex("dbo.Campaigns", "CategoryID");
            AddForeignKey("dbo.Campaigns", "ContributionID", "dbo.Contributions", "ContributionID", cascadeDelete: true);
            AddForeignKey("dbo.Campaigns", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
        }
    }
}
