namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InheritanceDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Incomes", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Expenses", "JoinDate");
            DropColumn("dbo.Incomes", "JoinDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Incomes", "JoinDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Expenses", "JoinDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Incomes", "Date");
            DropColumn("dbo.Expenses", "Date");
        }
    }
}
