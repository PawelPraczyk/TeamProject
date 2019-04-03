namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InheritanceAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "JoinDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Incomes", "JoinDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Incomes", "JoinDate");
            DropColumn("dbo.Expenses", "JoinDate");
        }
    }
}
