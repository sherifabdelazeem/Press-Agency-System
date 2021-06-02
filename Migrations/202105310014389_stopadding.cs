namespace NewsWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stopadding : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "PostType_ID", "dbo.PostTypes");
            DropIndex("dbo.Posts", new[] { "PostType_ID" });
            RenameColumn(table: "dbo.Posts", name: "PostType_ID", newName: "CategoryId");
            AlterColumn("dbo.Posts", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "CategoryId");
            AddForeignKey("dbo.Posts", "CategoryId", "dbo.PostTypes", "ID", cascadeDelete: true);
            DropColumn("dbo.Posts", "TypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "TypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.PostTypes");
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            AlterColumn("dbo.Posts", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Posts", name: "CategoryId", newName: "PostType_ID");
            CreateIndex("dbo.Posts", "PostType_ID");
            AddForeignKey("dbo.Posts", "PostType_ID", "dbo.PostTypes", "ID");
        }
    }
}
