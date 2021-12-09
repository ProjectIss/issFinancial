namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m311 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VechicleLoanCollections", "DueAmount", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VechicleLoanCollections", "DueAmount");
        }
    }
}
