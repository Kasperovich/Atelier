namespace Atelier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderIsClised : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "isClosed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "isClosed");
        }
    }
}
