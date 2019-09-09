namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "longitute", c => c.Double(nullable: false));
            AddColumn("dbo.Customers", "latitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "latitude");
            DropColumn("dbo.Customers", "longitute");
        }
    }
}
