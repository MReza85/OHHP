namespace OHHP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql(" UPDATE MembershipTypes SET Name ='Not A Member' WHERE Id = 1 ");
            Sql(" UPDATE MembershipTypes SET Name ='Member' WHERE Id = 2 ");
        }
        
        public override void Down()
        {
        }
    }
}
