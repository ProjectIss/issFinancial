namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m315 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VechicleLoanCollections", "SelectDueNumberId", c => c.Int(nullable: false));
            CreateIndex("dbo.VechicleLoanCollections", "SelectDueNumberId");
            AddForeignKey("dbo.VechicleLoanCollections", "SelectDueNumberId", "dbo.Installments", "id", cascadeDelete: true);
            DropColumn("dbo.VechicleLoanCollections", "SelectDueNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VechicleLoanCollections", "SelectDueNumber", c => c.String());
            DropForeignKey("dbo.VechicleLoanCollections", "SelectDueNumberId", "dbo.Installments");
            DropIndex("dbo.VechicleLoanCollections", new[] { "SelectDueNumberId" });
            DropColumn("dbo.VechicleLoanCollections", "SelectDueNumberId");
        }
    }
}
