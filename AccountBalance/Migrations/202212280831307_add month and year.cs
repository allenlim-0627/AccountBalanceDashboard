namespace AccountBalance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmonthandyear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountModels", "Month", c => c.String());
            AddColumn("dbo.AccountModels", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountModels", "Year");
            DropColumn("dbo.AccountModels", "Month");
        }
    }
}
