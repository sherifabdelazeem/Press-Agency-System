namespace NewsWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ArticleType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Posts", "ArticleType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "ArticleType", c => c.String(nullable: false));
            DropTable("dbo.PostTypes");
        }
    }
}
