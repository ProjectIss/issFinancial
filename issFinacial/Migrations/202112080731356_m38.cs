namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m38 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brokers", "siNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brokers", "siNo");
        }
    }
}
