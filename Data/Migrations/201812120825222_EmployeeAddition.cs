namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeAddition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Salary = c.Double(nullable: false),
                        Commission = c.Double(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        JoiningDate = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
