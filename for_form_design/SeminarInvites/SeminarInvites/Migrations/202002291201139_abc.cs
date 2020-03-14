namespace SeminarInvites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GuestResponses",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        Phone = c.String(nullable: false),
                        WillAttend = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GuestResponses");
        }
    }
}
