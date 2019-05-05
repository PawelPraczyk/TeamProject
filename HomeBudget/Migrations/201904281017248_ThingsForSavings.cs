namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThingsForSavings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "PercentMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Categories", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "IfSavingsPercent", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Categories", "User_Id");
            AddForeignKey("dbo.Categories", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Categories", new[] { "User_Id" });
            DropColumn("dbo.AspNetUsers", "IfSavingsPercent");
            DropColumn("dbo.Categories", "User_Id");
            DropColumn("dbo.Categories", "PercentMoney");
        }
    }
}
