namespace OHHP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoomType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Rooms", "RoomTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Rooms", "NumberOfBeds", c => c.Byte(nullable: false));
            AlterColumn("dbo.Rooms", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Rooms", "RoomTypeId");
            AddForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            AlterColumn("dbo.Rooms", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Rooms", "NumberOfBeds");
            DropColumn("dbo.Rooms", "RoomTypeId");
            DropTable("dbo.RoomTypes");
        }
    }
}
