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

        public ActionResult Balance()
        {
            ViewBag.Message = "This is your balance.";

            return View();
        }
        public ActionResult Incomes(string search, int? i)
        {
            var incomesHistory = _context.Incomes
                .Include(g => g.CategoryIncome)
                .Include(g => g.User).Where(x => x.CategoryIncome.Name.StartsWith(search) || search == null).ToList().ToPagedList(i ?? 1,10);

            return View(incomesHistory);
        }
        public ActionResult Outgoings(string search, int? i)
        {
            var expensesHistory = _context.Expenses
                .Include(g => g.Category)
                .Include(g => g.User).Where(x => x.Category.Name.StartsWith(search) || search == null).ToList().ToPagedList(i ?? 1,10);


            return View(expensesHistory);
        }
    }
}