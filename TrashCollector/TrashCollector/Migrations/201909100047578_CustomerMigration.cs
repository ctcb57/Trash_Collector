namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "specialPickupDate", c => c.DateTime());
            AddColumn("dbo.Customers", "stateAbbreviation", c => c.String());
            DropColumn("dbo.Customers", "pickupDateSelected");
            DropColumn("dbo.Customers", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Date", c => c.DateTime());
            AddColumn("dbo.Customers", "pickupDateSelected", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "stateAbbreviation");
            DropColumn("dbo.Customers", "specialPickupDate");
        }
    }
}
