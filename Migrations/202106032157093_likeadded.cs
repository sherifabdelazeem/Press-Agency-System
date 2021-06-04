namespace NewsWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class likeadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Like", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "DisLike", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "DisLike");
            DropColumn("dbo.Posts", "Like");
        }
    }
}
