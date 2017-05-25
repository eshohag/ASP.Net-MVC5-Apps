namespace GoContributeMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version81 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ViewAllDataInfoes",
                c => new
                    {
                        ViewAllDataInfoID = c.Int(nullable: false, identity: true),
                        CampaignID = c.Int(nullable: false),
                        Tittle = c.String(),
                        CategoriesName = c.String(),
                        ContributionsName = c.String(),
                        Descriptions = c.String(),
                        RecipientName = c.String(),
                        RecipientNID = c.String(),
                        Email = c.String(),
                        MobileNo = c.String(),
                        TargetAmount = c.String(),
                        CampaignClosingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ViewAllDataInfoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ViewAllDataInfoes");
        }
    }
}
