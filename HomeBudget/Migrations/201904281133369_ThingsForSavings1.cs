namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThingsForSavings1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "category", c => c.Int(nullable: false));
            Sql("INSERT INTO CATEGORIES (Id, Name, Color, AmountMoney,PercentMoney) VALUES (1, 'Food','red',400,0.4)");
            Sql("INSERT INTO CATEGORIES (Id, Name, Color, AmountMoney,PercentMoney) VALUES (2, 'Bills','black',200,0.2)");
            Sql("INSERT INTO CATEGORIES (Id, Name, Color, AmountMoney,PercentMoney) VALUES (3, 'House','green', 20,0.06)");
            Sql("INSERT INTO CATEGORIES (Id, Name, Color, AmountMoney,PercentMoney) VALUES (4, 'Cosmetics','pink', 40,0.03)");
            Sql("INSERT INTO CATEGORIES (Id, Name, Color, AmountMoney,PercentMoney) VALUES (5, 'Clothes','blue',50,0.05)");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "category");
        }
    }
}
