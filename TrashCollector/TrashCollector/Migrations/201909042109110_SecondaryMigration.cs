namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondaryMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "firstName", c => c.String());
            AddColumn("dbo.Employees", "lastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "lastName");
            DropColumn("dbo.Employees", "firstName");
        }
    }
}
