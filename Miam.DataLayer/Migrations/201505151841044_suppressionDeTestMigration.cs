namespace Miam.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suppressionDeTestMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tags", "TestMigration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "TestMigration", c => c.String());
        }
    }
}
