namespace NewsWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class askupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AskForPosts", "IsSaved", c => c.Boolean(nullable: false));
            AddColumn("dbo.AskForPosts", "Like", c => c.Int(nullable: false));
            AddColumn("dbo.AskForPosts", "DisLike", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AskForPosts", "DisLike");
            DropColumn("dbo.AskForPosts", "Like");
            DropColumn("dbo.AskForPosts", "IsSaved");
        }
    }
}
