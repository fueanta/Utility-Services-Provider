namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FakeId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "FakeId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "FakeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "FakeId");
            DropColumn("dbo.Clients", "FakeId");
        }
    }
}
