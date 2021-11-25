namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Installments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        loanNumber = c.String(),
                        firstDueDate = c.String(),
                        dueStatus = c.String(),
                        dueAmount = c.String(),
                        doanAmount = c.String(),
                        numberofDue = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Installments");
        }
    }
}
