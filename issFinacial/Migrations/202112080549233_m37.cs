namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m37 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "FatherName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "FatherName", c => c.Int(nullable: false));
        }
    }
}
