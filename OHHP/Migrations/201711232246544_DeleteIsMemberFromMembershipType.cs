namespace OHHP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteIsMemberFromMembershipType : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MembershipTypes", "IsMember");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "IsMember", c => c.Boolean(nullable: false));
        }
    }
}
