namespace NewsWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class replyeditor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AskForPosts", "Reply", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AskForPosts", "Reply");
        }
    }
}
