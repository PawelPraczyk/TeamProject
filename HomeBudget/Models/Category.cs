using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class Category
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }

        //public CatColor Color { get; set; }

        public ApplicationUser User { get; set; }

        //public MyImage Icon { get; set; }
        public decimal AvailableMoney { get; set; }
        public decimal SpendMoney { get; set; }
        public decimal AmountMoney { get; set; }
        public decimal PercentMoney { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        //public IEnumerable<CatColor> Colors { get; set; }
        //public IEnumerable<MyImage> Icons { get; set; }
        public int category { get; set; }
    }
}