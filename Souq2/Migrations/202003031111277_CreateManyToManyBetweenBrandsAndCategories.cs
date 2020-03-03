namespace Souq2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateManyToManyBetweenBrandsAndCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryBrands",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Brand_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Brand_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Brands", t => t.Brand_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Brand_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryBrands", "Brand_Id", "dbo.Brands");
            DropForeignKey("dbo.CategoryBrands", "Category_Id", "dbo.Categories");
            DropIndex("dbo.CategoryBrands", new[] { "Brand_Id" });
            DropIndex("dbo.CategoryBrands", new[] { "Category_Id" });
            DropTable("dbo.CategoryBrands");
        }
    }
}
