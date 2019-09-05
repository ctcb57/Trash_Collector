namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "individualPickupDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "individualPickupDate", c => c.String());
            DropColumn("dbo.Customers", "Date");
        }
    }
}
