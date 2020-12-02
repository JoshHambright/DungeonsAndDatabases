namespace DungeonsAndDatabases.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogEntry",
                c => new
                    {
                        LogID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        DateUpdated = c.DateTimeOffset(precision: 7),
                        CampaignID = c.Int(nullable: false),
                        PlayerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LogID)
                .ForeignKey("dbo.Campaign", t => t.CampaignID, cascadeDelete: true)
                .ForeignKey("dbo.Player", t => t.PlayerID, cascadeDelete: true)
                .Index(t => t.CampaignID)
                .Index(t => t.PlayerID);
            
            CreateTable(
                "dbo.Campaign",
                c => new
                    {
                        CampaignID = c.Int(nullable: false, identity: true),
                        CampaignName = c.String(nullable: false),
                        GameSystem = c.String(),
                        DmGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CampaignID)
                .ForeignKey("dbo.Player", t => t.DmGuid, cascadeDelete: false)
                .Index(t => t.DmGuid);
            
            CreateTable(
                "dbo.Loot",
                c => new
                    {
                        LootID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ValueInGP = c.Double(nullable: false),
                        Description = c.String(),
                        CampaignID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LootID)
                .ForeignKey("dbo.Campaign", t => t.CampaignID, cascadeDelete: true)
                .Index(t => t.CampaignID);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        PlayerID = c.Guid(nullable: false),
                        PlayerName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerID);
            
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        CharacterID = c.Int(nullable: false, identity: true),
                        CharacterName = c.String(nullable: false),
                        Race = c.String(nullable: false),
                        Class = c.String(nullable: false),
                        Level = c.String(nullable: false),
                        PlayerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterID)
                .ForeignKey("dbo.Player", t => t.PlayerID, cascadeDelete: true)
                .Index(t => t.PlayerID);
            
            CreateTable(
                "dbo.Equipment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Notes = c.String(),
                        EquipmentType = c.Int(nullable: false),
                        CharacterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Character", t => t.CharacterID, cascadeDelete: true)
                .Index(t => t.CharacterID);
            
            CreateTable(
                "dbo.Membership",
                c => new
                    {
                        CampaignId = c.Int(nullable: false),
                        CharacterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CampaignId, t.CharacterID })
                .ForeignKey("dbo.Campaign", t => t.CampaignId, cascadeDelete: true)
                .ForeignKey("dbo.Character", t => t.CharacterID, cascadeDelete: true)
                .Index(t => t.CampaignId)
                .Index(t => t.CharacterID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.LogEntry", "PlayerID", "dbo.Player");
            DropForeignKey("dbo.LogEntry", "CampaignID", "dbo.Campaign");
            DropForeignKey("dbo.Membership", "CharacterID", "dbo.Character");
            DropForeignKey("dbo.Membership", "CampaignId", "dbo.Campaign");
            DropForeignKey("dbo.Campaign", "DmGuid", "dbo.Player");
            DropForeignKey("dbo.Character", "PlayerID", "dbo.Player");
            DropForeignKey("dbo.Equipment", "CharacterID", "dbo.Character");
            DropForeignKey("dbo.Loot", "CampaignID", "dbo.Campaign");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Membership", new[] { "CharacterID" });
            DropIndex("dbo.Membership", new[] { "CampaignId" });
            DropIndex("dbo.Equipment", new[] { "CharacterID" });
            DropIndex("dbo.Character", new[] { "PlayerID" });
            DropIndex("dbo.Loot", new[] { "CampaignID" });
            DropIndex("dbo.Campaign", new[] { "DmGuid" });
            DropIndex("dbo.LogEntry", new[] { "PlayerID" });
            DropIndex("dbo.LogEntry", new[] { "CampaignID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Membership");
            DropTable("dbo.Equipment");
            DropTable("dbo.Character");
            DropTable("dbo.Player");
            DropTable("dbo.Loot");
            DropTable("dbo.Campaign");
            DropTable("dbo.LogEntry");
        }
    }
}
