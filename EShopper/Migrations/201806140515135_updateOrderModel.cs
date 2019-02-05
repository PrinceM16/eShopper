namespace EShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrderModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "TotalPrice", c => c.Double(nullable: false));
            DropColumn("dbo.Orders", "TotalAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "TotalAmount", c => c.Double(nullable: false));
            DropColumn("dbo.Orders", "TotalPrice");
            DropColumn("dbo.Orders", "OrderDate");
        }
    }
}
