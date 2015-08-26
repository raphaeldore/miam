namespace Miam.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajoutRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "ApplicationUsers_Id", "dbo.ApplicationUsers");
            DropIndex("dbo.UserRoles", new[] { "ApplicationUsers_Id" });
            AlterColumn("dbo.UserRoles", "ApplicationUsers_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.UserRoles", "ApplicationUsers_Id");
            AddForeignKey("dbo.UserRoles", "ApplicationUsers_Id", "dbo.ApplicationUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "ApplicationUsers_Id", "dbo.ApplicationUsers");
            DropIndex("dbo.UserRoles", new[] { "ApplicationUsers_Id" });
            AlterColumn("dbo.UserRoles", "ApplicationUsers_Id", c => c.Int());
            CreateIndex("dbo.UserRoles", "ApplicationUsers_Id");
            AddForeignKey("dbo.UserRoles", "ApplicationUsers_Id", "dbo.ApplicationUsers", "Id");
        }
    }
}
