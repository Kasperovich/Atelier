namespace Atelier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComplicatingElements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Count = c.Int(nullable: false),
                        PriceOne = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SetId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sets", t => t.SetId)
                .Index(t => t.SetId);
            
            CreateTable(
                "dbo.Sets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinimumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderId = c.Int(),
                        ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.FinishingWorks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Unit = c.String(),
                        Count = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SetId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Sets", t => t.SetId)
                .Index(t => t.SetId);
            
            CreateTable(
                "dbo.ListOfMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Single(nullable: false),
                        Type = c.Boolean(nullable: false),
                        MaterialId = c.Int(),
                        SetId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.MaterialId)
                .ForeignKey("dbo.Sets", t => t.SetId)
                .Index(t => t.MaterialId)
                .Index(t => t.SetId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaterialId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        ReceiptNumber = c.String(),
                        DateOfReceipt = c.DateTime(nullable: false),
                        ClosingDate = c.DateTime(nullable: false),
                        FormOfPayment = c.Boolean(nullable: false),
                        CustomerName = c.String(),
                        CostomerMaterial = c.String(),
                        CountCustomerMaterial = c.Single(nullable: false),
                        PriceCustomerMaterial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CountProduct = c.Int(nullable: false),
                        SizeProduct = c.Int(nullable: false),
                        LongProduct1 = c.Int(nullable: false),
                        LongProduct2 = c.Int(nullable: false),
                        LongSleeve = c.Int(nullable: false),
                        Coefficient = c.Single(nullable: false),
                        Workerid = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Workers", t => t.Workerid)
                .Index(t => t.Workerid);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        WorkerId = c.Int(nullable: false, identity: true),
                        FIO = c.String(),
                        Shortname = c.String(),
                    })
                .PrimaryKey(t => t.WorkerId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sets", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "Workerid", "dbo.Workers");
            DropForeignKey("dbo.Sets", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.ListOfMaterials", "SetId", "dbo.Sets");
            DropForeignKey("dbo.ListOfMaterials", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.FinishingWorks", "SetId", "dbo.Sets");
            DropForeignKey("dbo.ComplicatingElements", "SetId", "dbo.Sets");
            DropIndex("dbo.Orders", new[] { "Workerid" });
            DropIndex("dbo.ListOfMaterials", new[] { "SetId" });
            DropIndex("dbo.ListOfMaterials", new[] { "MaterialId" });
            DropIndex("dbo.FinishingWorks", new[] { "SetId" });
            DropIndex("dbo.Sets", new[] { "ProductId" });
            DropIndex("dbo.Sets", new[] { "OrderId" });
            DropIndex("dbo.ComplicatingElements", new[] { "SetId" });
            DropTable("dbo.Products");
            DropTable("dbo.Workers");
            DropTable("dbo.Orders");
            DropTable("dbo.Materials");
            DropTable("dbo.ListOfMaterials");
            DropTable("dbo.FinishingWorks");
            DropTable("dbo.Sets");
            DropTable("dbo.ComplicatingElements");
        }
    }
}
