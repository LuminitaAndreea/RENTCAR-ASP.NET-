namespace Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Plate", c => c.String());
            AlterColumn("dbo.Reservations", "ReservStatsID", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "ReservStatsID", c => c.Int(nullable: false));
            DropColumn("dbo.Reservations", "Plate");
        }
    }
}
