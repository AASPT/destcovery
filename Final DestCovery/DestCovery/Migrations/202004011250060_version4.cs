namespace DestCovery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        cid = c.Int(nullable: false, identity: true),
                        person_name = c.String(),
                        person_email = c.String(),
                        person_mobile = c.String(),
                        person_msg = c.String(),
                    })
                .PrimaryKey(t => t.cid);
            
            DropColumn("dbo.Package_Master", "Package_Total_Travellers");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Package_Master", "Package_Total_Travellers", c => c.Int(nullable: false));
            DropTable("dbo.ContactUs");
        }
    }
}
