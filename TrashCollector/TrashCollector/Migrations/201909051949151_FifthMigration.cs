namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifthMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Date", c => c.DateTime());
            AlterColumn("dbo.Customers", "AccountSuspensionStartDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "AccountSuspensionEndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "AccountSuspensionEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "AccountSuspensionStartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "Date", c => c.DateTime(nullable: false));
        }
    }
}
