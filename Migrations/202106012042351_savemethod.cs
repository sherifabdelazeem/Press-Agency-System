namespace NewsWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class savemethod : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SavePosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
            DropForeignKey("dbo.SavePosts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SavePosts", "PostId", "dbo.Posts");
            DropIndex("dbo.SavePosts", new[] { "UserId" });
            DropIndex("dbo.SavePosts", new[] { "PostId" });
            DropTable("dbo.SavePosts");
        }
    }
}
