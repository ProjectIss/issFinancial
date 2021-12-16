namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m316 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VechicleLoanCollections", "SelectDueNumberId", "dbo.Installments");
            DropIndex("dbo.VechicleLoanCollections", new[] { "SelectDueNumberId" });
            AddColumn("dbo.VechicleLoanCollections", "SelectDueNumber", c => c.String());
            DropColumn("dbo.VechicleLoanCollections", "SelectDueNumberId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VechicleLoanCollections", "SelectDueNumberId", c => c.Int(nullable: false));
            DropColumn("dbo.VechicleLoanCollections", "SelectDueNumber");
            CreateIndex("dbo.VechicleLoanCollections", "SelectDueNumberId");
            AddForeignKey("dbo.VechicleLoanCollections", "SelectDueNumberId", "dbo.Installments", "id", cascadeDelete: true);
        }
    }
}
