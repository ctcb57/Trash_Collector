namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "firstName", c => c.String());
            AddColumn("dbo.Customers", "lastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "lastName");
            DropColumn("dbo.Customers", "firstName");
        }
    }
}
