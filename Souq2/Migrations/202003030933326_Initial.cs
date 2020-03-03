namespace Souq2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Brand_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.Brand_Id)
                .Index(t => t.Brand_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                        PriceAfterSale = c.Single(nullable: false),
                        Image = c.String(),
                        FK_CategoryId = c.Int(nullable: false),
                        FK_BrandId = c.Int(nullable: false),
                        FK_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.FK_BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.FK_CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.FK_UserId, cascadeDelete: true)
                .Index(t => t.FK_CategoryId)
                .Index(t => t.FK_BrandId)
                .Index(t => t.FK_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "FK_UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "FK_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "FK_BrandId", "dbo.Brands");
            DropForeignKey("dbo.Categories", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "FK_UserId" });
            DropIndex("dbo.Products", new[] { "FK_BrandId" });
            DropIndex("dbo.Products", new[] { "FK_CategoryId" });
            DropIndex("dbo.Categories", new[] { "Brand_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
        }
    }
}
