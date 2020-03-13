namespace SeminarInvitesMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatecolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GuestResponses", "gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GuestResponses", "gender");
        }
    }
}
