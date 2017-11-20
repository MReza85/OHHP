namespace OHHP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdateToPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Birthdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Birthdate");
        }
    }
}
