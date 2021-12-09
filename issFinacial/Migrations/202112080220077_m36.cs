namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m36 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleLoanEntries", "fatherName", c => c.String());
            AddColumn("dbo.VehicleLoanEntries", "address", c => c.String());
            AddColumn("dbo.VehicleLoanEntries", "phoneNo", c => c.String());
            AddColumn("dbo.VehicleLoanEntries", "age", c => c.String());
            CreateIndex("dbo.VehicleLoanEntries", "customerNameId");
            AddForeignKey("dbo.VehicleLoanEntries", "customerNameId", "dbo.Customers", "id", cascadeDelete: true);
            DropColumn("dbo.VehicleLoanEntries", "fatherNameId");
            DropColumn("dbo.VehicleLoanEntries", "addressId");
            DropColumn("dbo.VehicleLoanEntries", "phoneNoId");
            DropColumn("dbo.VehicleLoanEntries", "ageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleLoanEntries", "ageId", c => c.Int(nullable: false));
            AddColumn("dbo.VehicleLoanEntries", "phoneNoId", c => c.Int(nullable: false));
            AddColumn("dbo.VehicleLoanEntries", "addressId", c => c.Int(nullable: false));
            AddColumn("dbo.VehicleLoanEntries", "fatherNameId", c => c.Int(nullable: false));
            DropForeignKey("dbo.VehicleLoanEntries", "customerNameId", "dbo.Customers");
            DropIndex("dbo.VehicleLoanEntries", new[] { "customerNameId" });
            DropColumn("dbo.VehicleLoanEntries", "age");
            DropColumn("dbo.VehicleLoanEntries", "phoneNo");
            DropColumn("dbo.VehicleLoanEntries", "address");
            DropColumn("dbo.VehicleLoanEntries", "fatherName");
        }
    }
}
