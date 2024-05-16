namespace Atelier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComplicatingElements", "ProductId", c => c.Int());
            CreateIndex("dbo.ComplicatingElements", "ProductId");
            AddForeignKey("dbo.ComplicatingElements", "ProductId", "dbo.Products", "ProductId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComplicatingElements", "ProductId", "dbo.Products");
            DropIndex("dbo.ComplicatingElements", new[] { "ProductId" });
            DropColumn("dbo.ComplicatingElements", "ProductId");
        }
    }
}
