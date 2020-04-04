namespace DestCovery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeinstatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admin_Info", "Admin_Status", c => c.String());
            AlterColumn("dbo.Package_Master", "Package_Status", c => c.String());
            AlterColumn("dbo.User_Info", "User_Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User_Info", "User_Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Package_Master", "Package_Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Admin_Info", "Admin_Status", c => c.Boolean(nullable: false));
        }
    }
}
