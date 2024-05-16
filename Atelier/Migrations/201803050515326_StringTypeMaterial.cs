namespace Atelier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringTypeMaterial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materials", "StringType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Materials", "StringType");
        }
    }
}
