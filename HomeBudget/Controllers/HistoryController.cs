using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeBudget.Models;
using PagedList;
using PagedList.Mvc;

namespace HomeBudget.Controllers
{
    public class HistoryController : Controller
    {
        private ApplicationDbContext _context;

        public HistoryController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Balance()

        {
            ViewBag.Message = "This is your balance.";

            return View();
        }

        [Authorize]
        public ActionResult Incomes(string sortOrder, string search, int? i)
        {
            ViewBag.NamesortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            var incomesHistory = _context.Incomes
                .Include(g => g.CategoryIncome)
                .Include(g => g.User).Where(x => x.CategoryIncome.Name.StartsWith(search) || search == null).ToList().ToPagedList(i ?? 1,10);

            switch (sortOrder)
            {
                case "name_desc":
                    incomesHistory = incomesHistory.OrderBy(g => g.CategoryIncome.Name).ToList().ToPagedList(i ?? 1,10);
                    break;
                case "price_desc":
                    incomesHistory = incomesHistory.OrderBy(g => g.Price).ToList().ToPagedList(i ?? 1, 10);
                    break;
            }

            return View(incomesHistory);
        }

        [Authorize]
        public ActionResult Outgoings(string search, int? i)
        {
            var expensesHistory = _context.Expenses
                .Include(g => g.Category)
                .Include(g => g.User).Where(x => x.Category.Name.StartsWith(search) || search == null).ToList().ToPagedList(i ?? 1,10);


            return View(expensesHistory);
        }
    }
}