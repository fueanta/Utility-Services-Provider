namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCitiesNAreas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "JoiningDate", c => c.DateTime(nullable: false));
            Sql("INSERT INTO CITIES (Name) VALUES ('Dhaka')");
            Sql("INSERT INTO AREAS (Name, CityId) VALUES ('Basabo', 1)");
            Sql("INSERT INTO AREAS (Name, CityId) VALUES ('Bashundhara', 1)");
            Sql("INSERT INTO AREAS (Name, CityId) VALUES ('Mirpur', 1)");
            Sql("INSERT INTO AREAS (Name, CityId) VALUES ('Mohammadpur', 1)");

            Sql("INSERT INTO CITIES (Name) VALUES ('Chottogram')");
            Sql("INSERT INTO AREAS (Name, CityId) VALUES ('Andorkilla', 2)");
            Sql("INSERT INTO AREAS (Name, CityId) VALUES ('Chalk Bazar', 2)");
            Sql("INSERT INTO AREAS (Name, CityId) VALUES ('Bohoddor Hut', 2)");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "JoiningDate", c => c.String());
        }
    }
}
