namespace EShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateShoppingCartModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCarts", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShoppingCarts", "UserId");
        }
    }
}
