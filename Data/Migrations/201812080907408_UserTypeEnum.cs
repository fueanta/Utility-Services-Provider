namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTypeEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserLogins", "UserType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserLogins", "UserType", c => c.String());
        }
    }
}
