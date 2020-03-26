namespace DestCovery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Database_creation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin_Info",
                c => new
                    {
                        Admin_Id = c.Int(nullable: false, identity: true),
                        Admin_Name = c.String(nullable: false),
                        Admin_Email = c.String(nullable: false),
                        Admin_Password = c.String(nullable: false),
                        Admin_Mobile = c.String(nullable: false),
                        Admin_Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Admin_Id);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Booking_Id = c.Int(nullable: false, identity: true),
                        Package_Id = c.Int(nullable: false),
                        Tour_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                        Persons_Enrolled = c.Int(nullable: false),
                        Price_Per_Person = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estimated_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Booking_Date = c.DateTime(nullable: false),
                        Booking_Status = c.Boolean(nullable: false),
                        fk_for_Spot_Id_Spot_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Booking_Id)
                .ForeignKey("dbo.Package_Master", t => t.Package_Id, cascadeDelete: true)
                .ForeignKey("dbo.Package_Spots", t => t.fk_for_Spot_Id_Spot_Id)
                .ForeignKey("dbo.Package_Tour", t => t.Tour_Id, cascadeDelete: true)
                .Index(t => t.Package_Id)
                .Index(t => t.Tour_Id)
                .Index(t => t.fk_for_Spot_Id_Spot_Id);
            
            CreateTable(
                "dbo.Package_Master",
                c => new
                    {
                        Package_Id = c.Int(nullable: false, identity: true),
                        Package_Name = c.String(nullable: false),
                        Package_Tagline = c.String(),
                        Package_Description = c.String(),
                        Package_Price = c.Double(nullable: false),
                        Package_Total_Travellers = c.Int(nullable: false),
                        Package_Status = c.Boolean(nullable: false),
                        Package_Header_Image = c.String(),
                    })
                .PrimaryKey(t => t.Package_Id);
            
            CreateTable(
                "dbo.Package_Spots",
                c => new
                    {
                        Spot_Id = c.Int(nullable: false, identity: true),
                        Package_Id = c.Int(nullable: false),
                        Spot_Name = c.String(),
                        Spot_Description = c.String(),
                    })
                .PrimaryKey(t => t.Spot_Id)
                .ForeignKey("dbo.Package_Master", t => t.Package_Id, cascadeDelete: true)
                .Index(t => t.Package_Id);
            
            CreateTable(
                "dbo.Package_Tour",
                c => new
                    {
                        Tour_Id = c.Int(nullable: false, identity: true),
                        Package_Id = c.Int(nullable: false),
                        Tour_Start_Date = c.DateTime(nullable: false),
                        Tour_End_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Tour_Id)
                .ForeignKey("dbo.Package_Master", t => t.Package_Id, cascadeDelete: false)
                .Index(t => t.Package_Id);
            
            CreateTable(
                "dbo.Package_Grid_Image",
                c => new
                    {
                        Package_GridImg_Id = c.Int(nullable: false, identity: true),
                        Package_Id = c.Int(nullable: false),
                        Package_GridImg = c.String(),
                    })
                .PrimaryKey(t => t.Package_GridImg_Id)
                .ForeignKey("dbo.Package_Master", t => t.Package_Id, cascadeDelete: true)
                .Index(t => t.Package_Id);
            
            CreateTable(
                "dbo.Package_Review",
                c => new
                    {
                        Package_Review_Id = c.Int(nullable: false, identity: true),
                        Package_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                        Package_Comment = c.String(),
                        Package_Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Package_Review_Id)
                .ForeignKey("dbo.Package_Master", t => t.Package_Id, cascadeDelete: true)
                .ForeignKey("dbo.User_Info", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Package_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.User_Info",
                c => new
                    {
                        User_Id = c.Int(nullable: false, identity: true),
                        User_Image = c.String(),
                        User_Name = c.String(nullable: false),
                        User_Email = c.String(nullable: false),
                        User_Password = c.String(nullable: false),
                        User_Address = c.String(),
                        User_Dob = c.DateTime(nullable: false),
                        User_Aadhar = c.String(nullable: false),
                        User_Mobile = c.String(nullable: false),
                        User_Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Package_Review", "User_Id", "dbo.User_Info");
            DropForeignKey("dbo.Package_Review", "Package_Id", "dbo.Package_Master");
            DropForeignKey("dbo.Package_Grid_Image", "Package_Id", "dbo.Package_Master");
            DropForeignKey("dbo.Bookings", "Tour_Id", "dbo.Package_Tour");
            DropForeignKey("dbo.Package_Tour", "Package_Id", "dbo.Package_Master");
            DropForeignKey("dbo.Bookings", "fk_for_Spot_Id_Spot_Id", "dbo.Package_Spots");
            DropForeignKey("dbo.Package_Spots", "Package_Id", "dbo.Package_Master");
            DropForeignKey("dbo.Bookings", "Package_Id", "dbo.Package_Master");
            DropIndex("dbo.Package_Review", new[] { "User_Id" });
            DropIndex("dbo.Package_Review", new[] { "Package_Id" });
            DropIndex("dbo.Package_Grid_Image", new[] { "Package_Id" });
            DropIndex("dbo.Package_Tour", new[] { "Package_Id" });
            DropIndex("dbo.Package_Spots", new[] { "Package_Id" });
            DropIndex("dbo.Bookings", new[] { "fk_for_Spot_Id_Spot_Id" });
            DropIndex("dbo.Bookings", new[] { "Tour_Id" });
            DropIndex("dbo.Bookings", new[] { "Package_Id" });
            DropTable("dbo.User_Info");
            DropTable("dbo.Package_Review");
            DropTable("dbo.Package_Grid_Image");
            DropTable("dbo.Package_Tour");
            DropTable("dbo.Package_Spots");
            DropTable("dbo.Package_Master");
            DropTable("dbo.Bookings");
            DropTable("dbo.Admin_Info");
        }
    }
}
