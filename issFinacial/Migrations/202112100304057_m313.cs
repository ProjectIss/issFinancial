namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m313 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VechicleLoanCollections", "NumberOfInstallmentsId", c => c.Int(nullable: false));
            AddColumn("dbo.VechicleLoanCollections", "numberofDue_id", c => c.Int());
            CreateIndex("dbo.VechicleLoanCollections", "numberofDue_id");
            AddForeignKey("dbo.VechicleLoanCollections", "numberofDue_id", "dbo.Installments", "id");
            DropColumn("dbo.VechicleLoanCollections", "NumberOfInstallments");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VechicleLoanCollections", "NumberOfInstallments", c => c.String());
            DropForeignKey("dbo.VechicleLoanCollections", "numberofDue_id", "dbo.Installments");
            DropIndex("dbo.VechicleLoanCollections", new[] { "numberofDue_id" });
            DropColumn("dbo.VechicleLoanCollections", "numberofDue_id");
            DropColumn("dbo.VechicleLoanCollections", "NumberOfInstallmentsId");
        }
    }
}
