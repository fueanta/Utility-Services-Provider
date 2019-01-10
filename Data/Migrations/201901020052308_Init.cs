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
                "dbo.EmployeeInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Salary = c.Double(nullable: false),
                        Commission = c.Double(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        CityId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        JoiningDateTime = c.DateTime(nullable: false),
                        PhotoPath = c.String(),
                        Password = c.String(),
                        UserType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.LabourAssigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        RequestId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Requests", t => t.RequestId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        ServiceId = c.Int(),
                        ServiceDateTime = c.DateTime(nullable: false),
                        RequestStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.ServiceId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Description = c.String(maxLength: 150),
                        ProbableDurationInHours = c.Double(nullable: false),
                        ConsumerCharge = c.Double(nullable: false),
                        LabourCharge = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LabourInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wallet = c.Double(nullable: false),
                        UserId = c.Int(),
                        ServiceId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.ServiceId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        Amount = c.Double(nullable: false),
                        TransactionType = c.Int(nullable: false),
                        TransactionDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "UserId", "dbo.Users");
            DropForeignKey("dbo.LabourInfoes", "UserId", "dbo.Users");
            DropForeignKey("dbo.LabourInfoes", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.LabourAssigns", "UserId", "dbo.Users");
            DropForeignKey("dbo.LabourAssigns", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.Requests", "UserId", "dbo.Users");
            DropForeignKey("dbo.Requests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.EmployeeInfoes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Users", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Areas", "CityId", "dbo.Cities");
            DropIndex("dbo.Transactions", new[] { "UserId" });
            DropIndex("dbo.LabourInfoes", new[] { "ServiceId" });
            DropIndex("dbo.LabourInfoes", new[] { "UserId" });
            DropIndex("dbo.Requests", new[] { "ServiceId" });
            DropIndex("dbo.Requests", new[] { "UserId" });
            DropIndex("dbo.LabourAssigns", new[] { "RequestId" });
            DropIndex("dbo.LabourAssigns", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "AreaId" });
            DropIndex("dbo.Users", new[] { "CityId" });
            DropIndex("dbo.EmployeeInfoes", new[] { "UserId" });
            DropIndex("dbo.Areas", new[] { "CityId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.LabourInfoes");
            DropTable("dbo.Services");
            DropTable("dbo.Requests");
            DropTable("dbo.LabourAssigns");
            DropTable("dbo.Users");
            DropTable("dbo.EmployeeInfoes");
            DropTable("dbo.Cities");
            DropTable("dbo.Areas");
        }
    }
}
