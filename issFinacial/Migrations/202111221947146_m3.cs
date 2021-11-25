namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Installments", "loanAmount", c => c.String());
            DropColumn("dbo.Installments", "doanAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Installments", "doanAmount", c => c.String());
            DropColumn("dbo.Installments", "loanAmount");
        }
    }
}
