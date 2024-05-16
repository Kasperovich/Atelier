namespace Atelier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordernameProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "NameProduct", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "NameProduct");
        }
    }
}
