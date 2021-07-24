namespace _2BHLM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserInfotable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "phonenum", c => c.String());
            AddColumn("dbo.UserInfoes", "address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "address");
            DropColumn("dbo.UserInfoes", "phonenum");
        }
    }
}
