namespace DestCovery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "fk_for_Spot_Id_Spot_Id", "dbo.Package_Spots");
            DropIndex("dbo.Bookings", new[] { "fk_for_Spot_Id_Spot_Id" });
            DropColumn("dbo.Bookings", "fk_for_Spot_Id_Spot_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "fk_for_Spot_Id_Spot_Id", c => c.Int());
            CreateIndex("dbo.Bookings", "fk_for_Spot_Id_Spot_Id");
            AddForeignKey("dbo.Bookings", "fk_for_Spot_Id_Spot_Id", "dbo.Package_Spots", "Spot_Id");
        }
    }
}
