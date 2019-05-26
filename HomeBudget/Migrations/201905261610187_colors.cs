namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colors : DbMigration
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
            
            AddColumn("dbo.Categories", "Color_Id", c => c.Int());
            AddColumn("dbo.Categories", "Color", c => c.String(nullable: false));

            AddColumn("dbo.CategoryIncomes", "Color_Id", c => c.Int());
            AddColumn("dbo.CategoryIncomes", "Color", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Color");
            DropColumn("dbo.Categories", "Color_Id");
           

            DropColumn("dbo.CategoryIncomes", "Color");
            DropColumn("dbo.CategoryIncomes", "Color_Id");
            //DropTable("dbo.CatColors");
        }
    }
}
