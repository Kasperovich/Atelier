namespace Atelier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListOfMaterialQuality : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ListOfMaterials", "Quantity", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ListOfMaterials", "Quantity", c => c.Single(nullable: false));
        }
    }
}
