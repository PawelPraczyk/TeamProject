namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addspending : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "SpendMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "SpendMoney");
        }
    }
}
