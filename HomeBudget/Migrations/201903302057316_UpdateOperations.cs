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
            AddColumn("dbo.Incomes", "CategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Incomes", "CategoryId");
            AddForeignKey("dbo.Incomes", "CategoryId", "dbo.CategoryIncomes", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Incomes", "CategoryId", "dbo.CategoryIncomes");
            DropIndex("dbo.Incomes", new[] { "CategoryId" });
            DropColumn("dbo.Incomes", "CategoryId");
            CreateIndex("dbo.Incomes", "CategoryId");
            AddForeignKey("dbo.Incomes", "CategoryId", "dbo.CategoryIncomes", "Id", cascadeDelete: true);
        }
    }
}