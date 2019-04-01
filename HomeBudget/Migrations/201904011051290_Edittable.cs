namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edittable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Incomes", "CategoryIncome_Id", "dbo.CategoryIncomes");
            DropIndex("dbo.Incomes", new[] { "CategoryIncome_Id" });
            AlterColumn("dbo.Incomes", "CategoryIncome_Id", c => c.Byte());
            CreateIndex("dbo.Incomes", "CategoryIncome_Id");
            AddForeignKey("dbo.Incomes", "CategoryIncome_Id", "dbo.CategoryIncomes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incomes", "CategoryIncome_Id", "dbo.CategoryIncomes");
            DropIndex("dbo.Incomes", new[] { "CategoryIncome_Id" });
            AlterColumn("dbo.Incomes", "CategoryIncome_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Incomes", "CategoryIncome_Id");
            AddForeignKey("dbo.Incomes", "CategoryIncome_Id", "dbo.CategoryIncomes", "Id", cascadeDelete: true);
        }
    }
}
