namespace Atelier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class materialListaddPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ListOfMaterials", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ListOfMaterials", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ListOfMaterials", "Type", c => c.Boolean(nullable: false));
            DropColumn("dbo.ListOfMaterials", "Price");
        }
    }
}
