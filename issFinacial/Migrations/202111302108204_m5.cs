namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleLoanEntries", "totalAmount", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleLoanEntries", "totalAmount");
        }
    }
}
