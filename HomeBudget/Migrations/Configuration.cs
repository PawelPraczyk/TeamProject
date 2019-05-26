namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeBudget.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HomeBudget.Models.ApplicationDbContext";
        }

        protected override void Seed(HomeBudget.Models.ApplicationDbContext context)
        {
            Models.CatColor c1 = new Models.CatColor { Id = 1, Color = "#FA8072" };
            Models.CatColor c2 = new Models.CatColor { Id = 2, Color = "#FFDAB9" };
            Models.CatColor c3 = new Models.CatColor { Id = 3, Color = "#FFA07A" };
            Models.CatColor c4 = new Models.CatColor { Id = 4, Color = "#9370DB" };
            Models.CatColor c5 = new Models.CatColor { Id = 5, Color = "#8B008B" };
            Models.CatColor c6 = new Models.CatColor { Id = 6, Color = "#6A5ACD" };
            Models.CatColor c7 = new Models.CatColor { Id = 7, Color = "#90EE90" };
            Models.CatColor c8 = new Models.CatColor { Id = 8, Color = "#20B2AA" };
            Models.CatColor c9 = new Models.CatColor { Id = 9, Color = "#00FA9A" };
            Models.CatColor c10 = new Models.CatColor { Id = 10, Color = "#87CEEB" };
            context.Colors.AddOrUpdate(i => i.Id, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10);

            context.Categories.AddOrUpdate(i => i.Id, 
                new Models.Category {Id = 1, Name = "Food", Color = c1, AmountMoney = 400, PercentMoney = 0.4m },
                new Models.Category { Id = 2, Name = "Bills", Color = c2, AmountMoney = 200, PercentMoney = 0.2m },
                new Models.Category { Id = 3, Name = "House", Color = c3, AmountMoney = 20, PercentMoney = 0.06m },
                new Models.Category { Id = 4, Name = "Cosmetics", Color = c4, AmountMoney = 40, PercentMoney = 0.03m },
                new Models.Category { Id = 5, Name = "Clothes", Color = c5, AmountMoney = 50, PercentMoney = 0.05m }
                );

            context.CategoryIncomes.AddOrUpdate(j => j.Id,
                new Models.CategoryIncome { Id = 1, Name = "Salary", Color = c1},
                new Models.CategoryIncome { Id = 2, Name = "Allowance", Color = c2}              
                );

        }
    }
}
