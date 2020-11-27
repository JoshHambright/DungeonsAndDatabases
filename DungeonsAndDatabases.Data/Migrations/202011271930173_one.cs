namespace DungeonsAndDatabases.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loot",
                c => new
                    {
                        LootID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ValueInGP = c.Int(nullable: false),
                        Description = c.String(),
                        CampaignID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LootID)
                .ForeignKey("dbo.Campaign", t => t.CampaignID, cascadeDelete: true)
                .Index(t => t.CampaignID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loot", "CampaignID", "dbo.Campaign");
            DropIndex("dbo.Loot", new[] { "CampaignID" });
            DropTable("dbo.Loot");
        }
    }
}
