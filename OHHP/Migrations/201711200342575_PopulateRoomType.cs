namespace OHHP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRoomType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO RoomTypes(Id,Name) VALUES (1,'Private Room')");
            Sql("INSERT INTO RoomTypes(Id,Name) VALUES (2,'General Ward')");
            Sql("INSERT INTO RoomTypes(Id,Name) VALUES (3,'Doctors Examination Room')");
        }
        
        public override void Down()
        {
        }
    }
}
