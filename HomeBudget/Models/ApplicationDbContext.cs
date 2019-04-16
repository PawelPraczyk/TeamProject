using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace HomeBudget.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<CategoryIncome> CategoryIncomes { get; set; }
        public DbSet<FixedExpense> FixedExpenses { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}