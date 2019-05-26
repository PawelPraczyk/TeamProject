namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ojojo : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Categories", "Color_Id");
            AddForeignKey("dbo.Categories", "Color_Id", "dbo.CatColors", "Id");
            DropColumn("dbo.Categories", "Color");

            CreateIndex("dbo.CategoryIncomes", "Color_Id");
            AddForeignKey("dbo.CategoryIncomes", "Color_Id", "dbo.CatColors", "Id");
            DropColumn("dbo.CategoryIncomes", "Color");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Color_Id", "dbo.CatColors");
            DropIndex("dbo.Categories", new[] { "Color_Id" });
            //CreateIndex("dbo.Categories", "Color_Id");

            DropForeignKey("dbo.CategoryIncomes", "Color_Id", "dbo.CatColors");
            DropIndex("dbo.CategoryIncomes", new[] { "Color_Id" });
            //CreateIndex("dbo.CategoryIncomes", "Color_Id");         
        }
    }
}
