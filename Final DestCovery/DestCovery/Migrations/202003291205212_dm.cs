namespace DestCovery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Package_Tour", "Package_Id", "dbo.Package_Master");
            AddForeignKey("dbo.Package_Tour", "Package_Id", "dbo.Package_Master", "Package_Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Package_Tour", "Package_Id", "dbo.Package_Master");
            AddForeignKey("dbo.Package_Tour", "Package_Id", "dbo.Package_Master", "Package_Id");
        }
    }
}
