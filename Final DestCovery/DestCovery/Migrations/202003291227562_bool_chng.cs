namespace DestCovery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bool_chng : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "Booking_Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "Booking_Status", c => c.Boolean(nullable: false));
        }
    }
}
