namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m39 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Installments", "phoneNumbers", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Installments", "phoneNumbers");
        }
    }
}
