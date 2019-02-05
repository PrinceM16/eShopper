namespace EShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addProductAndCategoryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                {
                    CategoryId = c.Byte(nullable: false),
                    CategoryName = c.String(),
                })
                .PrimaryKey(t => t.CategoryId);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    ProductId = c.Int(nullable: false, identity: true),
                    ProductName = c.String(),
                    ProductImageUrl = c.String(),
                    Size = c.String(),
                    Color = c.String(),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    MyProperty = c.Int(nullable: false),
                    Category_CategoryId = c.Byte(),
                    Stock = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
