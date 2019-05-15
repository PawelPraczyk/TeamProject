using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace HomeBudget.ViewModels
{
    public class ExpenseFormViewModel : JqDate
    {
        public decimal Price { get; set; }
        public int Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string Date { get; set; }
        public DateTime GetDataTime()
        {
            return DateTime.ParseExact(Date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        }
    }
}