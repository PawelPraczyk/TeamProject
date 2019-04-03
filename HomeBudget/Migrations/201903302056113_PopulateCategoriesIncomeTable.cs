namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateCategoriesIncomeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CATEGORYINCOMES (Id, Name, Color) VALUES (1, 'Salary','red')");
            Sql("INSERT INTO CATEGORYINCOMES (Id, Name, Color) VALUES (2, 'Allowance','black')");
        }

        public override void Down()
        {
            Sql("DELETE FROM CATEGORYINCOMES WHERE Id IN (1,2)");
        }
    }
}
