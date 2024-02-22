namespace FriendOrganizer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNickName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Friend", "NickName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Friend", "NickName");
        }
    }
}
