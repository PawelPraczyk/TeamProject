namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CATEGORIES (Id, Name, Color, AmountMoney,PercentMoney) VALUES (1, 'Food','red',400,0.4m)");
            Sql("INSERT INTO CATEGORIES (Id, Name, Color, AmountMoney,PercentMoney) VALUES (2, 'Bills','black',200,0.2m)");
            Sql("INSERT INTO CATEGORIES (Id, Name, Color, AmountMoney,PercentMoney) VALUES (3, 'House','green', 20,0.06m)");
            Sql("INSERT INTO CATEGORIES (Id, Name, Color, AmountMoney,PercentMoney) VALUES (4, 'Cosmetics','pink', 40,0.03m)");
            Sql("INSERT INTO CATEGORIES (Id, Name, Color, AmountMoney,PercentMoney) VALUES (5, 'Clothes','blue',50,0.05m)");
        }

        public override void Down()
        {
            Sql("DELETE FROM CATEGORIES WHERE Id IN (1,2,3,4,5)");
        }
    }
}
