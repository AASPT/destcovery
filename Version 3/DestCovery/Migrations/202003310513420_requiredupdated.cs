namespace DestCovery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredupdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User_Info", "User_Name", c => c.String());
            AlterColumn("dbo.User_Info", "User_Aadhar", c => c.String());
            AlterColumn("dbo.User_Info", "User_Mobile", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User_Info", "User_Mobile", c => c.String(nullable: false));
            AlterColumn("dbo.User_Info", "User_Aadhar", c => c.String(nullable: false));
            AlterColumn("dbo.User_Info", "User_Name", c => c.String(nullable: false));
        }
    }
}
