namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleLoanEntries", "typeOfLoan", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleLoanEntries", "typeOfLoan");
        }
    }
}
