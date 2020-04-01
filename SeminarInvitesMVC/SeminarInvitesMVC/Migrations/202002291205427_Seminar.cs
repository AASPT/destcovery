namespace SeminarInvitesMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seminar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GuestResponses",
                c => new
                    {
                        responseID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        phone = c.String(),
                        willAttend = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.responseID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GuestResponses");
        }
    }
}
