using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class Balance
    {
        public decimal IncomesSum { get; set; }
        public decimal ExpensesSum { get; set; }
        public decimal UserBalance { get; set; }
    }
}