namespace MvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guest",
                c => new
                    {
                        GuestId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GuestId);
            
            CreateTable(
                "dbo.Leg",
                c => new
                    {
                        LegId = c.Int(nullable: false, identity: true),
                        tripId = c.Int(nullable: false),
                        legName = c.String(),
                        startLocation = c.String(),
                        endLocation = c.String(),
                        LegtartDate = c.DateTime(nullable: false),
                        legEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LegId)
                .ForeignKey("dbo.Trip", t => t.tripId, cascadeDelete: true)
                .Index(t => t.tripId);
            
            CreateTable(
                "dbo.Trip",
                c => new
                    {
                        TripId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        startDate = c.DateTime(nullable: false),
                        endDate = c.DateTime(nullable: false),
                        minimunNumberOfGuests = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TripId);
            
            CreateTable(
                "dbo.LegGuest",
                c => new
                    {
                        Leg_LegId = c.Int(nullable: false),
                        Guest_GuestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Leg_LegId, t.Guest_GuestId })
                .ForeignKey("dbo.Leg", t => t.Leg_LegId, cascadeDelete: true)
                .ForeignKey("dbo.Guest", t => t.Guest_GuestId, cascadeDelete: true)
                .Index(t => t.Leg_LegId)
                .Index(t => t.Guest_GuestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leg", "tripId", "dbo.Trip");
            DropForeignKey("dbo.LegGuest", "Guest_GuestId", "dbo.Guest");
            DropForeignKey("dbo.LegGuest", "Leg_LegId", "dbo.Leg");
            DropIndex("dbo.Leg", new[] { "tripId" });
            DropIndex("dbo.LegGuest", new[] { "Guest_GuestId" });
            DropIndex("dbo.LegGuest", new[] { "Leg_LegId" });
            DropTable("dbo.LegGuest");
            DropTable("dbo.Trip");
            DropTable("dbo.Leg");
            DropTable("dbo.Guest");
        }
    }
}
