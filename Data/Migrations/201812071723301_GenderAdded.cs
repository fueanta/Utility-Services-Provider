namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenderAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Gender");
        }
    }
}
