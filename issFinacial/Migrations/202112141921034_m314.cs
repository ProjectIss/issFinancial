namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m314 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Installments", "loanNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Installments", "loanNumber", c => c.String());
        }
    }
}
