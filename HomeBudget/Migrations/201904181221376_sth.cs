namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FixedExpenses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.FixedExpenses", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.FixedExpenses", new[] { "CategoryId" });
            DropIndex("dbo.FixedExpenses", new[] { "User_Id" });
            DropTable("dbo.FixedExpenses");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.FixedExpenses", "User_Id");
            CreateIndex("dbo.FixedExpenses", "CategoryId");
            AddForeignKey("dbo.FixedExpenses", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FixedExpenses", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
