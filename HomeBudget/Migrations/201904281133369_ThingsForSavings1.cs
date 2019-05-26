namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThingsForSavings1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "category", c => c.Int(nullable: false));
          
        }

        public override void Down()
        {
            DropColumn("dbo.Categories", "category");
            
        }
    }
}
