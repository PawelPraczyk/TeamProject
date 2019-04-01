using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser  User { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Category Category { get; set; }

        //[Required]
        //public DateTime Date { get; set; }

        [Required]
        public byte CategoryId { get; set; }
    }
}