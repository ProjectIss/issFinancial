namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TblMasters", "CommisionAmount");
            DropColumn("dbo.TblMasters", "IntrestAmount");
            DropColumn("dbo.TblMasters", "DocumentCharges");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TblMasters", "DocumentCharges", c => c.String());
            AddColumn("dbo.TblMasters", "IntrestAmount", c => c.String());
            AddColumn("dbo.TblMasters", "CommisionAmount", c => c.String());
        }
    }
}
