namespace AccountBalance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addusermodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserPassword = c.String(),
                        Roles = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserModels");
        }
    }
}
