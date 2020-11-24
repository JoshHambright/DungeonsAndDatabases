namespace DungeonsAndDatabases.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Campaign", "DmGuid");
            AddForeignKey("dbo.Campaign", "DmGuid", "dbo.Player", "PlayerID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Campaign", "DmGuid", "dbo.Player");
            DropIndex("dbo.Campaign", new[] { "DmGuid" });
        }
    }
}
