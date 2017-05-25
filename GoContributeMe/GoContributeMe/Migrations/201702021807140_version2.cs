namespace GoContributeMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        CampaignID = c.Int(nullable: false, identity: true),
                        Tittle = c.String(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        ContributionID = c.Int(nullable: false),
                        RecipientFirstName = c.String(nullable: false),
                        RecipientLastName = c.String(nullable: false),
                        RecipientNID = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        MobileNo = c.String(nullable: false),
                        TargetAmount = c.String(nullable: false),
                        CampaignClosingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CampaignID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Contributions", t => t.ContributionID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.ContributionID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Contributions",
                c => new
                    {
                        ContributionID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ContributionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Campaigns", "ContributionID", "dbo.Contributions");
            DropForeignKey("dbo.Campaigns", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Campaigns", new[] { "ContributionID" });
            DropIndex("dbo.Campaigns", new[] { "CategoryID" });
            DropTable("dbo.Contributions");
            DropTable("dbo.Categories");
            DropTable("dbo.Campaigns");
        }
    }
}
