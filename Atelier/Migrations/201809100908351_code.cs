namespace Atelier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class code : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materials", "Code", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Code", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "Code", c => c.Int(nullable: false));
            DropColumn("dbo.Workers", "ShortName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workers", "ShortName", c => c.String());
            DropColumn("dbo.Workers", "Code");
            DropColumn("dbo.Products", "Code");
            DropColumn("dbo.Materials", "Code");
        }
    }
}
