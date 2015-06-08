namespace Miam.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "TestMigration", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "TestMigration");
        }
    }
}
