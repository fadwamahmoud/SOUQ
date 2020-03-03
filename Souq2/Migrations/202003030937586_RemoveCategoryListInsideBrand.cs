namespace Souq2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCategoryListInsideBrand : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Categories", new[] { "Brand_Id" });
            DropColumn("dbo.Categories", "Brand_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Brand_Id", c => c.Int());
            CreateIndex("dbo.Categories", "Brand_Id");
            AddForeignKey("dbo.Categories", "Brand_Id", "dbo.Brands", "Id");
        }
    }
}
