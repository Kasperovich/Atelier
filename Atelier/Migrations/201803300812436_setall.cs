namespace Atelier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setall : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ComplicatingElements", "SetId", "dbo.Sets");
            DropForeignKey("dbo.FinishingWorks", "SetId", "dbo.Sets");
            DropForeignKey("dbo.ListOfMaterials", "SetId", "dbo.Sets");
            DropForeignKey("dbo.Sets", "OrderId", "dbo.Orders");
            DropIndex("dbo.ComplicatingElements", new[] { "SetId" });
            DropIndex("dbo.Sets", new[] { "OrderId" });
            DropIndex("dbo.FinishingWorks", new[] { "SetId" });
            DropIndex("dbo.ListOfMaterials", new[] { "SetId" });
            AlterColumn("dbo.ComplicatingElements", "SetId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sets", "OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.FinishingWorks", "SetId", c => c.Int(nullable: false));
            AlterColumn("dbo.ListOfMaterials", "SetId", c => c.Int(nullable: false));
            CreateIndex("dbo.ComplicatingElements", "SetId");
            CreateIndex("dbo.Sets", "OrderId");
            CreateIndex("dbo.FinishingWorks", "SetId");
            CreateIndex("dbo.ListOfMaterials", "SetId");
            AddForeignKey("dbo.ComplicatingElements", "SetId", "dbo.Sets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FinishingWorks", "SetId", "dbo.Sets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ListOfMaterials", "SetId", "dbo.Sets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sets", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sets", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.ListOfMaterials", "SetId", "dbo.Sets");
            DropForeignKey("dbo.FinishingWorks", "SetId", "dbo.Sets");
            DropForeignKey("dbo.ComplicatingElements", "SetId", "dbo.Sets");
            DropIndex("dbo.ListOfMaterials", new[] { "SetId" });
            DropIndex("dbo.FinishingWorks", new[] { "SetId" });
            DropIndex("dbo.Sets", new[] { "OrderId" });
            DropIndex("dbo.ComplicatingElements", new[] { "SetId" });
            AlterColumn("dbo.ListOfMaterials", "SetId", c => c.Int());
            AlterColumn("dbo.FinishingWorks", "SetId", c => c.Int());
            AlterColumn("dbo.Sets", "OrderId", c => c.Int());
            AlterColumn("dbo.ComplicatingElements", "SetId", c => c.Int());
            CreateIndex("dbo.ListOfMaterials", "SetId");
            CreateIndex("dbo.FinishingWorks", "SetId");
            CreateIndex("dbo.Sets", "OrderId");
            CreateIndex("dbo.ComplicatingElements", "SetId");
            AddForeignKey("dbo.Sets", "OrderId", "dbo.Orders", "OrderId");
            AddForeignKey("dbo.ListOfMaterials", "SetId", "dbo.Sets", "Id");
            AddForeignKey("dbo.FinishingWorks", "SetId", "dbo.Sets", "Id");
            AddForeignKey("dbo.ComplicatingElements", "SetId", "dbo.Sets", "Id");
        }
    }
}
