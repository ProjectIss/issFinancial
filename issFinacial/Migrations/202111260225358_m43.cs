namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m43 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleLoanEntries", "totalDueAmount", c => c.String());
            DropColumn("dbo.VehicleLoanEntries", "totalloanAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleLoanEntries", "totalloanAmount", c => c.String());
            DropColumn("dbo.VehicleLoanEntries", "totalDueAmount");
        }
    }
}
