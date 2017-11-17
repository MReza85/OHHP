namespace OHHP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribedToPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "IsSubscirbedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "IsSubscirbedToNewsletter");
        }
    }
}
