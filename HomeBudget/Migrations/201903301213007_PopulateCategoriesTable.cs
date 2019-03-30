namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CATEGORIES (Id, Name, Color) VALUES (1, 'Food','red')");
            Sql("INSERT INTO CATEGORIES (Id, Name, Color) VALUES (2, 'Bills','black')");
            Sql("INSERT INTO CATEGORIES (Id, Name, Color) VALUES (3, 'House','green')");
            Sql("INSERT INTO CATEGORIES (Id, Name, Color) VALUES (4, 'Cosmetics','pink')");
            Sql("INSERT INTO CATEGORIES (Id, Name, Color) VALUES (5, 'Clothes','blue')");
        }

        public override void Down()
        {
            Sql("DELETE FROM CATEGORIES WHERE Id IN (1,2,3,4,5)");
        }
    }
}
