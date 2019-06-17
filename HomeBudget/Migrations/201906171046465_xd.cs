namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Color_Id", "dbo.CatColors");
            DropForeignKey("dbo.Categories", "Icon_Id", "dbo.MyImages");
            DropIndex("dbo.Categories", new[] { "Color_Id" });
            DropIndex("dbo.Categories", new[] { "Icon_Id" });
            DropColumn("dbo.Categories", "Color_Id");
            DropColumn("dbo.Categories", "Icon_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Icon_Id", c => c.Int());
            AddColumn("dbo.Categories", "Color_Id", c => c.Int());
            CreateIndex("dbo.Categories", "Icon_Id");
            CreateIndex("dbo.Categories", "Color_Id");
            AddForeignKey("dbo.Categories", "Icon_Id", "dbo.MyImages", "Id");
            AddForeignKey("dbo.Categories", "Color_Id", "dbo.CatColors", "Id");
        }
    }
}
