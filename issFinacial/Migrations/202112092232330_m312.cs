namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m312 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VechicleLoanCollections", "TotaldueAmount", c => c.Single(nullable: false));
            DropColumn("dbo.VechicleLoanCollections", "TotalAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VechicleLoanCollections", "TotalAmount", c => c.Single(nullable: false));
            DropColumn("dbo.VechicleLoanCollections", "TotaldueAmount");
        }
    }
}
