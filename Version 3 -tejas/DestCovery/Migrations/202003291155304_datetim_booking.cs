namespace DestCovery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetim_booking : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "Booking_Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "Booking_Date", c => c.DateTime(nullable: false));
        }
    }
}
