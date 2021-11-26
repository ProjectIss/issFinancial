namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m42 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Installments", "DueDate", c => c.String());
            DropColumn("dbo.Installments", "DueDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Installments", "DueDate", c => c.String());
            DropColumn("dbo.Installments", "DueDate");
        }
    }
}
