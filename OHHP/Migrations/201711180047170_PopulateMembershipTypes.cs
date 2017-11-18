namespace OHHP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id, IsMember, DiscountRate) VALUES (1, 0 , 0)");
            Sql("INSERT INTO MembershipTypes(Id, IsMember, DiscountRate) VALUES (2, 1 , 66)");
        }
        
        public override void Down()
        {
        }
    }
}
