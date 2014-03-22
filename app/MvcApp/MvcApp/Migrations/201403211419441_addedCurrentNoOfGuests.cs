namespace MvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCurrentNoOfGuests : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trip", "currentNumberofGuests", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trip", "currentNumberofGuests");
        }
    }
}
