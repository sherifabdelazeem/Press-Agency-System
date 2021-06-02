namespace NewsWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asktable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AskForPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        PostId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.PostId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AskForPosts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AskForPosts", "PostId", "dbo.Posts");
            DropIndex("dbo.AskForPosts", new[] { "UserId" });
            DropIndex("dbo.AskForPosts", new[] { "PostId" });
            DropTable("dbo.AskForPosts");
        }
    }
}
