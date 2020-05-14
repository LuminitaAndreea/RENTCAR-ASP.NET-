namespace Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Reservations");
            AddColumn("dbo.Reservations", "ReservationId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Reservations", "ReservationId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Reservations");
            DropColumn("dbo.Reservations", "ReservationId");
            AddPrimaryKey("dbo.Reservations", new[] { "UserId", "CarID" });
        }
    }
}
