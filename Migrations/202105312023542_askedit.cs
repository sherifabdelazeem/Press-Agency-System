namespace NewsWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class askedit : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AskForPosts", "IsSaved");
            DropColumn("dbo.AskForPosts", "Like");
            DropColumn("dbo.AskForPosts", "DisLike");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AskForPosts", "DisLike", c => c.Int(nullable: false));
            AddColumn("dbo.AskForPosts", "Like", c => c.Int(nullable: false));
            AddColumn("dbo.AskForPosts", "IsSaved", c => c.Boolean(nullable: false));
        }
    }
}
