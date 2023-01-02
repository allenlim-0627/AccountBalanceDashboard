namespace AccountBalance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcreateddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountModels", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountModels", "CreatedDate");
        }
    }
}
