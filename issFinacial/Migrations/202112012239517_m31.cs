namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Installments", "loanAmount", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Installments", "loanAmount");
        }
    }
}
