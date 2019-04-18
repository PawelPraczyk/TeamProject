namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedExpense : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FixedExpenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        CategoryId = c.Byte(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FixedExpenses", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FixedExpenses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.FixedExpenses", new[] { "User_Id" });
            DropIndex("dbo.FixedExpenses", new[] { "CategoryId" });
            DropTable("dbo.FixedExpenses");
        }
    }
}
