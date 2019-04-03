namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForExpenseAndCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Expenses", new[] { "User_Id" });
            AlterColumn("dbo.Expenses", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Expenses", "User_Id");
            AddForeignKey("dbo.Expenses", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Expenses", new[] { "User_Id" });
            AlterColumn("dbo.Expenses", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Expenses", "User_Id");
            AddForeignKey("dbo.Expenses", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
