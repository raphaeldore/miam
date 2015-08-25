namespace Miam.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suppressioncleetrangere : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Reviews", "WriterId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.UserRoles", "ApplicationUserId", "dbo.ApplicationUsers");
            DropIndex("dbo.Reviews", new[] { "RestaurantId" });
            DropIndex("dbo.Reviews", new[] { "WriterId" });
            DropIndex("dbo.UserRoles", new[] { "ApplicationUserId" });
            RenameColumn(table: "dbo.Reviews", name: "RestaurantId", newName: "Restaurant_Id");
            RenameColumn(table: "dbo.Reviews", name: "WriterId", newName: "Writer_Id");
            RenameColumn(table: "dbo.UserRoles", name: "ApplicationUserId", newName: "ApplicationUsers_Id");
            AlterColumn("dbo.Reviews", "Restaurant_Id", c => c.Int());
            AlterColumn("dbo.Reviews", "Writer_Id", c => c.Int());
            AlterColumn("dbo.UserRoles", "ApplicationUsers_Id", c => c.Int());
            CreateIndex("dbo.Reviews", "Restaurant_Id");
            CreateIndex("dbo.Reviews", "Writer_Id");
            CreateIndex("dbo.UserRoles", "ApplicationUsers_Id");
            AddForeignKey("dbo.Reviews", "Restaurant_Id", "dbo.Restaurants", "Id");
            AddForeignKey("dbo.Reviews", "Writer_Id", "dbo.ApplicationUsers", "Id");
            AddForeignKey("dbo.UserRoles", "ApplicationUsers_Id", "dbo.ApplicationUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "ApplicationUsers_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Reviews", "Writer_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Reviews", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.UserRoles", new[] { "ApplicationUsers_Id" });
            DropIndex("dbo.Reviews", new[] { "Writer_Id" });
            DropIndex("dbo.Reviews", new[] { "Restaurant_Id" });
            AlterColumn("dbo.UserRoles", "ApplicationUsers_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "Writer_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "Restaurant_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.UserRoles", name: "ApplicationUsers_Id", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.Reviews", name: "Writer_Id", newName: "WriterId");
            RenameColumn(table: "dbo.Reviews", name: "Restaurant_Id", newName: "RestaurantId");
            CreateIndex("dbo.UserRoles", "ApplicationUserId");
            CreateIndex("dbo.Reviews", "WriterId");
            CreateIndex("dbo.Reviews", "RestaurantId");
            AddForeignKey("dbo.UserRoles", "ApplicationUserId", "dbo.ApplicationUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reviews", "WriterId", "dbo.ApplicationUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reviews", "RestaurantId", "dbo.Restaurants", "Id", cascadeDelete: true);
        }
    }
}
