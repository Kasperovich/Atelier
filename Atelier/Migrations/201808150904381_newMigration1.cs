namespace Atelier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CustomerMaterial", c => c.String());
            DropColumn("dbo.Orders", "CostomerMaterial");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CostomerMaterial", c => c.String());
            DropColumn("dbo.Orders", "CustomerMaterial");
        }
    }
}
