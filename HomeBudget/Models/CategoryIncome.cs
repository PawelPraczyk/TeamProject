using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class CategoryIncome
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }

        //[Required]
        public CatColor Color { get; set; }
        //public Image Icon { get; set; }
    }
}