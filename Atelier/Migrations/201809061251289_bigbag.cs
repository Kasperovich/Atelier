namespace Atelier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bigbag : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ComplicatingElements", "SetId", "dbo.Sets");
            DropForeignKey("dbo.FinishingWorks", "SetId", "dbo.Sets");
            DropForeignKey("dbo.ListOfMaterials", "SetId", "dbo.Sets");
            DropIndex("dbo.ComplicatingElements", new[] { "SetId" });
            DropIndex("dbo.FinishingWorks", new[] { "SetId" });
            DropIndex("dbo.ListOfMaterials", new[] { "SetId" });
            AddColumn("dbo.ComplicatingElements", "OrderId", c => c.Int(nullable: false));
            AddColumn("dbo.FinishingWorks", "OrderId", c => c.Int(nullable: false));
            AddColumn("dbo.ListOfMaterials", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.ComplicatingElements", "OrderId");
            CreateIndex("dbo.FinishingWorks", "OrderId");
            CreateIndex("dbo.ListOfMaterials", "OrderId");
            AddForeignKey("dbo.ComplicatingElements", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.FinishingWorks", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.ListOfMaterials", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
            DropColumn("dbo.ComplicatingElements", "SetId");
            DropColumn("dbo.FinishingWorks", "SetId");
            DropColumn("dbo.ListOfMaterials", "SetId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ListOfMaterials", "SetId", c => c.Int(nullable: false));
            AddColumn("dbo.FinishingWorks", "SetId", c => c.Int(nullable: false));
            AddColumn("dbo.ComplicatingElements", "SetId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ListOfMaterials", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.FinishingWorks", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.ComplicatingElements", "OrderId", "dbo.Orders");
            DropIndex("dbo.ListOfMaterials", new[] { "OrderId" });
            DropIndex("dbo.FinishingWorks", new[] { "OrderId" });
            DropIndex("dbo.ComplicatingElements", new[] { "OrderId" });
            DropColumn("dbo.ListOfMaterials", "OrderId");
            DropColumn("dbo.FinishingWorks", "OrderId");
            DropColumn("dbo.ComplicatingElements", "OrderId");
            CreateIndex("dbo.ListOfMaterials", "SetId");
            CreateIndex("dbo.FinishingWorks", "SetId");
            CreateIndex("dbo.ComplicatingElements", "SetId");
            AddForeignKey("dbo.ListOfMaterials", "SetId", "dbo.Sets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FinishingWorks", "SetId", "dbo.Sets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ComplicatingElements", "SetId", "dbo.Sets", "Id", cascadeDelete: true);
        }
    }
}
