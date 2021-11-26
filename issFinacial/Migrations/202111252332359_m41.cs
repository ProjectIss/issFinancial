namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m41 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Installments", "Intrest", c => c.String());
            DropColumn("dbo.Installments", "loanAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Installments", "loanAmount", c => c.String());
            DropColumn("dbo.Installments", "Intrest");
        }
    }
}
