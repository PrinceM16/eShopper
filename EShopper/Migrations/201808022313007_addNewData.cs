namespace EShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewData : DbMigration
    {
        public override void Up()
        {
            //Sql("INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (1, N'Women')");
            //Sql("INSERT [dbo].[Products] ([ProductName], [ProductImageUrl], [Size], [Color], [Price], [CategoryId], [Stock]) VALUES (N'Lacey Turtle Neck Rib Knit Jumper', N'/images/products/product-01.jpg', N'S', N'Red', CAST(25.00 AS Decimal(18, 2)), 1, 5)");
        }
        
        public override void Down()
        {
        }
    }
}
