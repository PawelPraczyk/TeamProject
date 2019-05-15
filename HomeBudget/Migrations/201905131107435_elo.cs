namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class elo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FixedExpenses", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FixedExpenses", "Email");
        }
    }
}
