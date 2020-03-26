namespace DestCovery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKAdded : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Bookings", "User_Id");
            AddForeignKey("dbo.Bookings", "User_Id", "dbo.User_Info", "User_Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "User_Id", "dbo.User_Info");
            DropIndex("dbo.Bookings", new[] { "User_Id" });
        }
    }
}
