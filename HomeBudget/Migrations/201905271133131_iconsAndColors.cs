namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iconsAndColors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CatColors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Categories", "Color_Id", c => c.Int());
            AddColumn("dbo.Categories", "Icon_Id", c => c.Int());
            AddColumn("dbo.CategoryIncomes", "Color_Id", c => c.Int());
            AddColumn("dbo.CategoryIncomes", "Icon_Id", c => c.Int());
            CreateIndex("dbo.Categories", "Color_Id");
            CreateIndex("dbo.Categories", "Icon_Id");
            CreateIndex("dbo.CategoryIncomes", "Color_Id");
            CreateIndex("dbo.CategoryIncomes", "Icon_Id");
            AddForeignKey("dbo.Categories", "Color_Id", "dbo.CatColors", "Id");
            AddForeignKey("dbo.Categories", "Icon_Id", "dbo.MyImages", "Id");
            AddForeignKey("dbo.CategoryIncomes", "Color_Id", "dbo.CatColors", "Id");
            AddForeignKey("dbo.CategoryIncomes", "Icon_Id", "dbo.MyImages", "Id");
            DropColumn("dbo.Categories", "Color");
            DropColumn("dbo.CategoryIncomes", "Color");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CategoryIncomes", "Color", c => c.String(nullable: false));
            AddColumn("dbo.Categories", "Color", c => c.String(nullable: false));
            DropForeignKey("dbo.CategoryIncomes", "Icon_Id", "dbo.MyImages");
            DropForeignKey("dbo.CategoryIncomes", "Color_Id", "dbo.CatColors");
            DropForeignKey("dbo.Categories", "Icon_Id", "dbo.MyImages");
            DropForeignKey("dbo.Categories", "Color_Id", "dbo.CatColors");
            DropIndex("dbo.CategoryIncomes", new[] { "Icon_Id" });
            DropIndex("dbo.CategoryIncomes", new[] { "Color_Id" });
            DropIndex("dbo.Categories", new[] { "Icon_Id" });
            DropIndex("dbo.Categories", new[] { "Color_Id" });
            DropColumn("dbo.CategoryIncomes", "Icon_Id");
            DropColumn("dbo.CategoryIncomes", "Color_Id");
            DropColumn("dbo.Categories", "Icon_Id");
            DropColumn("dbo.Categories", "Color_Id");
            DropTable("dbo.MyImages");
            DropTable("dbo.CatColors");
        }
    }
}
