using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBudget.ViewModels
{
    public class IncomeFormViewModel : JqDate
    {
        public decimal Price { get; set; }
        public int Category { get; set; }
        public IEnumerable<CategoryIncome> CategoryIncomes { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public DateTime GetDataTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}