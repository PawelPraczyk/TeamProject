using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class FixedExpense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime Date { get; set; }
        public byte CategoryId { get; set; }
        public string Email { get; set; }
    }
}