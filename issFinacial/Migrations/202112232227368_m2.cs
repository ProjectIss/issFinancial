namespace issFinacial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TblMasters", "EntryTime", c => c.DateTime());
            AddColumn("dbo.TblMasters", "DeleteTime", c => c.DateTime());
            DropColumn("dbo.TblMasters", "ETime");
            DropColumn("dbo.TblMasters", "DTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TblMasters", "DTime", c => c.DateTime());
            AddColumn("dbo.TblMasters", "ETime", c => c.DateTime());
            DropColumn("dbo.TblMasters", "DeleteTime");
            DropColumn("dbo.TblMasters", "EntryTime");
        }
    }
}
