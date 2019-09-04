namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondaryMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "pickupDateSelected", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "individualPickupDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "individualPickupDate");
            DropColumn("dbo.Customers", "pickupDateSelected");
        }
    }
}
