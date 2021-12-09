namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m32 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VechicleLoanCollections", "vehicleLoanId", c => c.Int(nullable: false));
            CreateIndex("dbo.VechicleLoanCollections", "vehicleLoanId");
            AddForeignKey("dbo.VechicleLoanCollections", "vehicleLoanId", "dbo.VehicleLoanEntries", "id", cascadeDelete: true);
            DropColumn("dbo.VechicleLoanCollections", "LoanNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VechicleLoanCollections", "LoanNumber", c => c.String());
            DropForeignKey("dbo.VechicleLoanCollections", "vehicleLoanId", "dbo.VehicleLoanEntries");
            DropIndex("dbo.VechicleLoanCollections", new[] { "vehicleLoanId" });
            DropColumn("dbo.VechicleLoanCollections", "vehicleLoanId");
        }
    }
}
