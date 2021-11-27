namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m44 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VechicleLoanCollections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CollectionDate = c.DateTime(),
                        PaymentType = c.String(),
                        LoanNumber = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        PhoneNo = c.String(),
                        VehicleName = c.String(),
                        VehicleMake = c.String(),
                        NumberOfInstallments = c.String(),
                        SelectDueNumber = c.String(),
                        DueDate = c.DateTime(),
                        PrincipleAmount = c.Single(nullable: false),
                        IntrestAmount = c.Single(nullable: false),
                        TotalAmount = c.Single(nullable: false),
                        LateDays = c.DateTime(),
                        LateDaysAmount = c.Single(nullable: false),
                        Penalty = c.String(),
                        Discount = c.Single(nullable: false),
                        NetAmount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VechicleLoanCollections");
        }
    }
}
