namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateIncomeTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryIncomes",
                c => new
                {
                    Id = c.Byte(nullable: false),
                    Name = c.String(nullable: false),
                    //Color = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Incomes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    CategoryId = c.Byte(nullable: false),
                    User_Id = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryIncomes", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.User_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Incomes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Incomes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Incomes", new[] { "User_Id" });
            DropIndex("dbo.Incomes", new[] { "CategoryId" });
            DropTable("dbo.Incomes");
            DropTable("dbo.CategoryIncomes");
        }
    }
}