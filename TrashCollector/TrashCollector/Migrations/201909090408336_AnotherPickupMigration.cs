namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherPickupMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PickupTrackers",
                c => new
                    {
                        pickupId = c.Int(nullable: false, identity: true),
                        pickupDate = c.DateTime(),
                        employeeId = c.Int(nullable: false),
                        customerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pickupId)
                .ForeignKey("dbo.Customers", t => t.customerId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.employeeId, cascadeDelete: true)
                .Index(t => t.employeeId)
                .Index(t => t.customerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PickupTrackers", "employeeId", "dbo.Employees");
            DropForeignKey("dbo.PickupTrackers", "customerId", "dbo.Customers");
            DropIndex("dbo.PickupTrackers", new[] { "customerId" });
            DropIndex("dbo.PickupTrackers", new[] { "employeeId" });
            DropTable("dbo.PickupTrackers");
        }
    }
}
