namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Installments", "totalAmount", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Installments", "totalAmount");
        }
    }
}
