namespace EShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProductModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            RenameColumn(table: "dbo.Products", name: "Category_CategoryId", newName: "CategoryId");
            AlterColumn("dbo.Products", "CategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            DropColumn("dbo.Products", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "MyProperty", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AlterColumn("dbo.Products", "CategoryId", c => c.Byte());
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_CategoryId");
            CreateIndex("dbo.Products", "Category_CategoryId");
            AddForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
