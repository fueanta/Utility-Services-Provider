namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionOfLabours : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Labours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wallet = c.Double(nullable: false),
                        CityId = c.Int(),
                        AreaId = c.Int(),
                        FakeId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        JoiningDate = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId)
                .Index(t => t.AreaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Labours", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Labours", "AreaId", "dbo.Areas");
            DropIndex("dbo.Labours", new[] { "AreaId" });
            DropIndex("dbo.Labours", new[] { "CityId" });
            DropTable("dbo.Labours");
        }
    }
}
