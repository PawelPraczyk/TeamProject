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

        [Required]
        public string Color { get; set; }
        //public Image Icon { get; set; }
        public decimal AvailableMoney { get; set; }
        public decimal SpendMoney { get; set; }
    }
}