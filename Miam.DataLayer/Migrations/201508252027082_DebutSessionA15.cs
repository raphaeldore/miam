namespace Miam.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DebutSessionA15 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Reviews", "Writer_Id", "dbo.ApplicationUsers");
            AddColumn("dbo.Reviews", "Writer_Id1", c => c.Int());
            AddColumn("dbo.Reviews", "Restaurant_Id1", c => c.Int());
            CreateIndex("dbo.Reviews", "Writer_Id1");
            CreateIndex("dbo.Reviews", "Restaurant_Id1");
            AddForeignKey("dbo.Reviews", "Restaurant_Id1", "dbo.Restaurants", "Id");
            AddForeignKey("dbo.Reviews", "Restaurant_Id", "dbo.Restaurants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reviews", "Writer_Id1", "dbo.ApplicationUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Writer_Id1", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Reviews", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Reviews", "Restaurant_Id1", "dbo.Restaurants");
            DropIndex("dbo.Reviews", new[] { "Restaurant_Id1" });
            DropIndex("dbo.Reviews", new[] { "Writer_Id1" });
            DropColumn("dbo.Reviews", "Restaurant_Id1");
            DropColumn("dbo.Reviews", "Writer_Id1");
            AddForeignKey("dbo.Reviews", "Writer_Id", "dbo.ApplicationUsers", "Id");
            AddForeignKey("dbo.Reviews", "Restaurant_Id", "dbo.Restaurants", "Id");
        }
    }
}
