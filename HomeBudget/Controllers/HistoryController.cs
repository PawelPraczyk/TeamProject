using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeBudget.Models;

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
        public ActionResult Incomes()
        {
            var incomesHistory = _context.Incomes
                .Include(g => g.CategoryIncome)
                .Include(g => g.User);

            return View(incomesHistory);
        }
        public ActionResult Outgoings()
        {
            var expensesHistory = _context.Expenses
                .Include(g => g.Category)
                .Include(g => g.User);


            return View(expensesHistory);
        }
    }
}