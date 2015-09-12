namespace Miam.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MiamUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MiamRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        ApplicationUserId = c.Int(nullable: false),
                        MiamUsers_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MiamUsers", t => t.MiamUsers_Id, cascadeDelete: true)
                .Index(t => t.MiamUsers_Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Body = c.String(maxLength: 1024),
                        RestaurantId = c.Int(nullable: false),
                        WriterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .ForeignKey("dbo.MiamUsers", t => t.WriterId, cascadeDelete: true)
                .Index(t => t.RestaurantId)
                .Index(t => t.WriterId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestaurantContactDetails",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false),
                        FaxPhone = c.String(),
                        OfficePhone = c.String(),
                        TwitterAlias = c.String(),
                        Facebook = c.String(),
                        WebPage = c.String(),
                    })
                .PrimaryKey(t => t.RestaurantId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagRestaurants",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Restaurant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Restaurant_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Restaurant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "WriterId", "dbo.MiamUsers");
            DropForeignKey("dbo.TagRestaurants", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.TagRestaurants", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Reviews", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantContactDetails", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.MiamRoles", "MiamUsers_Id", "dbo.MiamUsers");
            DropIndex("dbo.TagRestaurants", new[] { "Restaurant_Id" });
            DropIndex("dbo.TagRestaurants", new[] { "Tag_Id" });
            DropIndex("dbo.RestaurantContactDetails", new[] { "RestaurantId" });
            DropIndex("dbo.Reviews", new[] { "WriterId" });
            DropIndex("dbo.Reviews", new[] { "RestaurantId" });
            DropIndex("dbo.MiamRoles", new[] { "MiamUsers_Id" });
            DropTable("dbo.TagRestaurants");
            DropTable("dbo.Tags");
            DropTable("dbo.RestaurantContactDetails");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Reviews");
            DropTable("dbo.MiamRoles");
            DropTable("dbo.MiamUsers");
        }
    }
}
