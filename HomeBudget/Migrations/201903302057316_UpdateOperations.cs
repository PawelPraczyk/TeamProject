namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdateOperations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Incomes", "CategoryId", "dbo.CategoryIncomes");
            DropIndex("dbo.Incomes", new[] { "CategoryId" });
            AddColumn("dbo.Incomes", "CategoryIncome_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Incomes", "CategoryIncome_Id");
            AddForeignKey("dbo.Incomes", "CategoryIncome_Id", "dbo.CategoryIncomes", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Incomes", "CategoryIncome_Id", "dbo.CategoryIncomes");
            DropIndex("dbo.Incomes", new[] { "CategoryIncome_Id" });
            DropColumn("dbo.Incomes", "CategoryIncome_Id");
            CreateIndex("dbo.Incomes", "CategoryId");
            AddForeignKey("dbo.Incomes", "CategoryId", "dbo.CategoryIncomes", "Id", cascadeDelete: true);
        }
    }
}