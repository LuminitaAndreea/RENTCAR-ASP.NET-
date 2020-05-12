namespace Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "CarID", "dbo.Cars");
            DropIndex("dbo.Reservations", new[] { "CarID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Reservations", "CarID");
            AddForeignKey("dbo.Reservations", "CarID", "dbo.Cars", "CarID", cascadeDelete: true);
        }
    }
}
