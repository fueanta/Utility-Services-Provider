namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityId = c.Int(),
                        AreaId = c.Int(),
                        Name = c.String(),
                        Address = c.String(),
                        JoiningDate = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Phone = c.String(),
                        Password = c.String(),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Clients", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Areas", "CityId", "dbo.Cities");
            DropIndex("dbo.Clients", new[] { "AreaId" });
            DropIndex("dbo.Clients", new[] { "CityId" });
            DropIndex("dbo.Areas", new[] { "CityId" });
            DropTable("dbo.UserLogins");
            DropTable("dbo.Clients");
            DropTable("dbo.Cities");
            DropTable("dbo.Areas");
        }
    }
}
