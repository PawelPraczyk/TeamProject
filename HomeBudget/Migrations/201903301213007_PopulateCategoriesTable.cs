namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            
        }

        public override void Down()
        {
            Sql("DELETE FROM CATEGORIES WHERE Id IN (1,2,3,4,5)");
        }
    }
}
