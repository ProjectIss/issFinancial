namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TblMasters", "CommisionAmount", c => c.String());
            AddColumn("dbo.TblMasters", "IntrestAmount", c => c.String());
            AddColumn("dbo.TblMasters", "DocumentCharges", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TblMasters", "DocumentCharges");
            DropColumn("dbo.TblMasters", "IntrestAmount");
            DropColumn("dbo.TblMasters", "CommisionAmount");
        }
    }
}
