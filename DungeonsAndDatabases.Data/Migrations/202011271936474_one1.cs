namespace DungeonsAndDatabases.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Loot", "ValueInGP", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Loot", "ValueInGP", c => c.Int(nullable: false));
        }
    }
}
