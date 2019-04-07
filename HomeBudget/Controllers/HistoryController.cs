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
            ViewBag.UsersortParm = String.IsNullOrEmpty(sortOrder) ? "user_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            var incomesHistory = _context.Incomes
                .Include(g => g.CategoryIncome)
                .Include(g => g.User).Where(x => x.CategoryIncome.Name.StartsWith(search) || search == null).ToList().ToPagedList(i ?? 1,100);

            switch (sortOrder)
            {
                case "name_desc":
                    incomesHistory = incomesHistory.OrderBy(g => g.CategoryIncome.Name).ToList().ToPagedList(i ?? 1,100);
                    break;
                case "user_desc":
                    incomesHistory = incomesHistory.OrderBy(g => g.User.UserName).ToList().ToPagedList(i ?? 1, 100);
                    break;
                case "price_desc":
                    incomesHistory = incomesHistory.OrderByDescending(g => g.Price).ToList().ToPagedList(i ?? 1,100);
                    break;
                case "Price":
                    incomesHistory = incomesHistory.OrderBy(g => g.Price).ToList().ToPagedList(i ?? 1, 100);
                    break;
                case "date_desc":
                    incomesHistory = incomesHistory.OrderByDescending(g => g.Date).ToList().ToPagedList(i ?? 1,100);
                    break;
                case "Date":
                    incomesHistory = incomesHistory.OrderBy(g => g.Date).ToList().ToPagedList(i ?? 1, 100);
                    break;
            }

            return View(incomesHistory);
        }

        [Authorize]
        public ActionResult Outgoings(string sortOrder, string search, int? i)
        {
            ViewBag.NamesortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.UsersortParm = String.IsNullOrEmpty(sortOrder) ? "user_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            var expensesHistory = _context.Expenses
                .Include(g => g.Category)
                .Include(g => g.User).Where(x => x.Category.Name.StartsWith(search) || search == null).ToList().ToPagedList(i ?? 1,10);

            switch (sortOrder)
            {
                case "name_desc":
                    expensesHistory = expensesHistory.OrderBy(g => g.Category.Name).ToList().ToPagedList(i ?? 1, 100);
                    break;
                case "user_desc":
                    expensesHistory = expensesHistory.OrderBy(g => g.User.UserName).ToList().ToPagedList(i ?? 1, 100);
                    break;
                case "price_desc":
                    expensesHistory = expensesHistory.OrderByDescending(g => g.Price).ToList().ToPagedList(i ?? 1, 100);
                    break;
                case "Price":
                    expensesHistory = expensesHistory.OrderBy(g => g.Price).ToList().ToPagedList(i ?? 1, 100);
                    break;
                case "date_desc":
                    expensesHistory = expensesHistory.OrderByDescending(g => g.Date).ToList().ToPagedList(i ?? 1, 100);
                    break;
                case "Date":
                    expensesHistory = expensesHistory.OrderBy(g => g.Date).ToList().ToPagedList(i ?? 1, 100);
                    break;
            }

            return View(expensesHistory);
        }
    }
}