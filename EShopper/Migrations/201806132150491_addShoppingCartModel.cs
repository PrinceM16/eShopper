namespace EShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addShoppingCartModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Color = c.String(),
                        Size = c.String(),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "ProductId", "dbo.Products");
            DropIndex("dbo.ShoppingCarts", new[] { "ProductId" });
            DropTable("dbo.ShoppingCarts");
        }
    }
}
