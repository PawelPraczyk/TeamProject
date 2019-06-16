namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.IO;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeBudget.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HomeBudget.Models.ApplicationDbContext";
        }

        protected override void Seed(HomeBudget.Models.ApplicationDbContext context)
        {
            //Models.CatColor c1 = new Models.CatColor { Id = 1, Color = "#FA8072" };
            //Models.CatColor c2 = new Models.CatColor { Id = 2, Color = "#FFDAB9" };
            //Models.CatColor c3 = new Models.CatColor { Id = 3, Color = "#FFA07A" };
            //Models.CatColor c4 = new Models.CatColor { Id = 4, Color = "#9370DB" };
            //Models.CatColor c5 = new Models.CatColor { Id = 5, Color = "#8B008B" };
            //Models.CatColor c6 = new Models.CatColor { Id = 6, Color = "#6A5ACD" };
            //Models.CatColor c7 = new Models.CatColor { Id = 7, Color = "#90EE90" };
            //Models.CatColor c8 = new Models.CatColor { Id = 8, Color = "#20B2AA" };
            //Models.CatColor c9 = new Models.CatColor { Id = 9, Color = "#00FA9A" };
            //Models.CatColor c10 = new Models.CatColor { Id = 10, Color = "#87CEEB" };
            //context.Colors.AddOrUpdate(i => i.Id, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10);

            //Models.MyImage i1 = new Models.MyImage { Id = 1, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/add-alarm-icon.png" };
            //Models.MyImage i2 = new Models.MyImage { Id = 2, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/alphabet-blocks-icon.png" };
            //Models.MyImage i3 = new Models.MyImage { Id = 3, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/apartment-building-icon.png" };
            //Models.MyImage i4 = new Models.MyImage { Id = 4, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/bookcase-icon.png" };
            //Models.MyImage i5 = new Models.MyImage { Id = 5, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/calendar-icon.png" };
            //Models.MyImage i6 = new Models.MyImage { Id = 6, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/charging-battery-icon.png" };
            //Models.MyImage i7 = new Models.MyImage { Id = 7, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/child-icon.png" };
            //Models.MyImage i8 = new Models.MyImage { Id = 8, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/cocktail-icon.png" };
            //Models.MyImage i9 = new Models.MyImage { Id = 9, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/crib-decor-icon.png" };
            //Models.MyImage i10 = new Models.MyImage { Id = 10, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/crib-icon.png" };
            //Models.MyImage i11 = new Models.MyImage { Id = 11, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/desk-chair-icon.png" };
            //Models.MyImage i12 = new Models.MyImage { Id = 12, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/dollar-scale-icon.png" };
            //Models.MyImage i13 = new Models.MyImage { Id = 13, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/home-icon.png" };
            //Models.MyImage i14 = new Models.MyImage { Id = 14, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/burger-icon.png" };
            //Models.MyImage i15 = new Models.MyImage { Id = 15, ImagePath = "http://icons.iconarchive.com/icons/dapino/beauty/48/face-icon.png" };
            //Models.MyImage i16 = new Models.MyImage { Id = 16, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/mixer-icon.png" };
            //Models.MyImage i17 = new Models.MyImage { Id = 17, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/plant-flower-icon.png" };
            //Models.MyImage i18 = new Models.MyImage { Id = 18, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/price-tag-icon.png" };
            //Models.MyImage i19 = new Models.MyImage { Id = 19, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/ceiling-lamp-icon.png" };
            //Models.MyImage i20 = new Models.MyImage { Id = 20, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/sandwich-icon.png" };
            //Models.MyImage i21 = new Models.MyImage { Id = 21, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/screwdriver-icon.png" };
            //Models.MyImage i22 = new Models.MyImage { Id = 22, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/solar-panels-icon.png" };
            //Models.MyImage i23 = new Models.MyImage { Id = 23, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/suitcase-icon.png" };
            //Models.MyImage i24 = new Models.MyImage { Id = 24, ImagePath = "http://icons.iconarchive.com/icons/iconsmind/outline/48/Shirt-icon.png" };
            //Models.MyImage i25 = new Models.MyImage { Id = 25, ImagePath = "http://icons.iconarchive.com/icons/roundicons/100-free-solid/48/image-icon.png" };
            //Models.MyImage i26 = new Models.MyImage { Id = 26, ImagePath = "http://icons.iconarchive.com/icons/icons8/ios7/48/Finance-Money-Box-icon.png" };
            //Models.MyImage i27 = new Models.MyImage { Id = 27, ImagePath = "https://cdn0.iconfinder.com/data/icons/black-48x48-icons/48/Bank-service.png" };
            //context.Icons.AddOrUpdate(i => i.Id, i1,i2,i3,i4,i5,i6,i7,i8,i9,i10,i11,i12,i13,i14,i15,i16,i17,i18,i19,i20,i21,i22,i23,i24,i25,i26,i27);

            //context.Categories.AddOrUpdate(i => i.Id,
            //    new Models.Category { Id = 1, Name = "Food", Color = c1,Icon = i14, AmountMoney = 400, PercentMoney = 0.4m },
            //    new Models.Category { Id = 2, Name = "Bills", Color = c2,Icon = i19, AmountMoney = 200, PercentMoney = 0.2m },
            //    new Models.Category { Id = 3, Name = "House", Color = c3,Icon = i13, AmountMoney = 20, PercentMoney = 0.06m },
            //    new Models.Category { Id = 4, Name = "Cosmetics", Color = c4,Icon = i15, AmountMoney = 40, PercentMoney = 0.03m },
            //    new Models.Category { Id = 5, Name = "Clothes", Color = c5,Icon = i24, AmountMoney = 50, PercentMoney = 0.05m }
            //    );

            //context.CategoryIncomes.AddOrUpdate(j => j.Id,
            //    new Models.CategoryIncome { Id = 1, Name = "Salary", Color = c1,Icon = i27},
            //    new Models.CategoryIncome { Id = 2, Name = "Allowance", Color = c2, Icon = i26 }
            //    );

            context.Categories.AddOrUpdate(i => i.Id,
                new Models.Category { Id = 1, Name = "Food", AmountMoney = 400, PercentMoney = 0.4m },
                new Models.Category { Id = 2, Name = "Bills", AmountMoney = 200, PercentMoney = 0.2m },
                new Models.Category { Id = 3, Name = "House", AmountMoney = 20, PercentMoney = 0.06m },
                new Models.Category { Id = 4, Name = "Cosmetics", AmountMoney = 40, PercentMoney = 0.03m },
                new Models.Category { Id = 5, Name = "Clothes", AmountMoney = 50, PercentMoney = 0.05m }
            );

            context.CategoryIncomes.AddOrUpdate(j => j.Id,
                new Models.CategoryIncome { Id = 1, Name = "Salary"},
                new Models.CategoryIncome { Id = 2, Name = "Allowance"}
                );
        }
    }
}
