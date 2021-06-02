namespace NewsWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blind : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.EditViewModels");

        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EditViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        UserImage = c.String(nullable: false),
                        CurrentPassword = c.String(nullable: false),
                        NewPassword = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
