namespace Atelier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class materialunitadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materials", "unit", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Materials", "unit");
        }
    }
}
