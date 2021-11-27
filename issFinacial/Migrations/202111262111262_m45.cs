namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m45 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VechicleLoanCollections", "VechicleNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VechicleLoanCollections", "VechicleNumber");
        }
    }
}
