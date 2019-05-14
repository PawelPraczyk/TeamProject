namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class e : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FixedExpenses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.FixedExpenses", new[] { "CategoryId" });
            DropColumn("dbo.FixedExpenses", "CategoryId");
            DropForeignKey("dbo.FixedExpenses", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.FixedExpenses", new[] { "User_Id" });
            DropColumn("dbo.FixedExpenses", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FixedExpenses", "CategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.FixedExpenses", "CategoryId");
            AddForeignKey("dbo.FixedExpenses", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddColumn("dbo.FixedExpenses", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.FixedExpenses", "User_Id");
            AddForeignKey("dbo.FixedExpenses", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
