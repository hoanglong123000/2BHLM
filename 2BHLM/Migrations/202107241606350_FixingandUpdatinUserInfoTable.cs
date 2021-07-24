namespace _2BHLM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingandUpdatinUserInfoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "Name");
        }
    }
}
