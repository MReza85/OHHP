namespace OHHP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJournalToPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Journal", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Journal");
        }
    }
}
