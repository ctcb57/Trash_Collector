namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Employees", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "ApplicationUserId");
            CreateIndex("dbo.Employees", "ApplicationUserId");
            AddForeignKey("dbo.Customers", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Customers", "email");
            DropColumn("dbo.Customers", "password");
            DropColumn("dbo.Customers", "state");
            DropColumn("dbo.Customers", "userRole");
            DropColumn("dbo.Employees", "email");
            DropColumn("dbo.Employees", "password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "password", c => c.String());
            AddColumn("dbo.Employees", "email", c => c.String());
            AddColumn("dbo.Customers", "userRole", c => c.String());
            AddColumn("dbo.Customers", "state", c => c.String());
            AddColumn("dbo.Customers", "password", c => c.String());
            AddColumn("dbo.Customers", "email", c => c.String());
            DropForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "ApplicationUserId" });
            DropIndex("dbo.Customers", new[] { "ApplicationUserId" });
            DropColumn("dbo.Employees", "ApplicationUserId");
            DropColumn("dbo.Customers", "ApplicationUserId");
        }
    }
}
