using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeBudget.Models;
using PagedList;
using PagedList.Mvc;
using Microsoft.AspNet.Identity;

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
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(u => u.Id == userId);
            var incomesHistory = _context.Incomes;
            var expensesHistory = _context.Expenses;
            var historyBalance = incomesHistory.AsEnumerable().Where(g => g.User == user).Sum(s => s.Price);
            var expensesBalance = expensesHistory.AsEnumerable().Where(g => g.User == user).Sum(s => s.Price);

            Balance balance = new Balance
            {
                IncomesSum = historyBalance,
                ExpensesSum = expensesBalance,
                UserBalance = (historyBalance - expensesBalance)
            };


            ViewBag.Message = balance;

            return View();
        }

        [Authorize]
        public ActionResult Incomes(string sortOrder, string search, int? i, int? filter)
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

            switch (filter)
            {
               
                case 1:
                    var date = DateTime.Now.AddDays(-7);
                    incomesHistory = incomesHistory.Select(n => n).Where(g => g.Date >= date).ToList().ToPagedList(i ?? 1, 100);
                    break;
                case 2:
                    var date1 = DateTime.Now.AddDays(-30);
                    incomesHistory = incomesHistory.Select(n => n).Where(g => g.Date >= date1).ToList().ToPagedList(i ?? 1, 100);
                    break;
                case 3:
                    var date2 = DateTime.Now.AddDays(-91);
                    incomesHistory = incomesHistory.Select(n => n).Where(g => g.Date >= date2).ToList().ToPagedList(i ?? 1, 100);
                    break;
            }

            
            return View(incomesHistory);
        }

        [Authorize]
        public ActionResult Outgoings(string sortOrder, string search, int? i, int? filter)
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

            switch (filter)
            {

                case 1:
                    var date = DateTime.Now.AddDays(-7);
                    expensesHistory = expensesHistory.Select(n => n).Where(g => g.Date >= date).ToList().ToPagedList(i ?? 1, 100);
                    break;
                case 2:
                    var date1 = DateTime.Now.AddDays(-30);
                    expensesHistory = expensesHistory.Select(n => n).Where(g => g.Date >= date1).ToList().ToPagedList(i ?? 1, 100);
                    break;
                case 3:
                    var date2 = DateTime.Now.AddDays(-91);
                    expensesHistory = expensesHistory.Select(n => n).Where(g => g.Date >= date2).ToList().ToPagedList(i ?? 1, 100);
                    break;
            }

            return View(expensesHistory);
        }
    }
}