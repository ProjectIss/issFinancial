namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m34 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "FatherName", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "FatherName");
        }
    }
}
