namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m35 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleLoanEntries", "customerNameId", "dbo.Customers");
            DropIndex("dbo.VehicleLoanEntries", new[] { "customerNameId" });
            AddColumn("dbo.VehicleLoanEntries", "fatherNameId", c => c.Int(nullable: false));
            AddColumn("dbo.VehicleLoanEntries", "addressId", c => c.Int(nullable: false));
            AddColumn("dbo.VehicleLoanEntries", "phoneNoId", c => c.Int(nullable: false));
            AddColumn("dbo.VehicleLoanEntries", "ageId", c => c.Int(nullable: false));
            DropColumn("dbo.VehicleLoanEntries", "fatherName");
            DropColumn("dbo.VehicleLoanEntries", "address");
            DropColumn("dbo.VehicleLoanEntries", "phoneNo");
            DropColumn("dbo.VehicleLoanEntries", "age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleLoanEntries", "age", c => c.String());
            AddColumn("dbo.VehicleLoanEntries", "phoneNo", c => c.String());
            AddColumn("dbo.VehicleLoanEntries", "address", c => c.String());
            AddColumn("dbo.VehicleLoanEntries", "fatherName", c => c.String());
            DropColumn("dbo.VehicleLoanEntries", "ageId");
            DropColumn("dbo.VehicleLoanEntries", "phoneNoId");
            DropColumn("dbo.VehicleLoanEntries", "addressId");
            DropColumn("dbo.VehicleLoanEntries", "fatherNameId");
            CreateIndex("dbo.VehicleLoanEntries", "customerNameId");
            AddForeignKey("dbo.VehicleLoanEntries", "customerNameId", "dbo.Customers", "id", cascadeDelete: true);
        }
    }
}
