namespace Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Reservations", "CarID");
            AddForeignKey("dbo.Reservations", "CarID", "dbo.Cars", "CarID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "CarID", "dbo.Cars");
            DropIndex("dbo.Reservations", new[] { "CarID" });
        }
    }
}
