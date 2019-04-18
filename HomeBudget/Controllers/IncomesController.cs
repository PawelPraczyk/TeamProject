using HomeBudget.Models;
using HomeBudget.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeBudget.Controllers
{
    public class IncomesController : Controller
    {
        private readonly ApplicationDbContext _context;
        // GET: Expenses

        public IncomesController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult CreateIncome()
        {
            var viewModel = new IncomeFormViewModel
            {
                CategoryIncomes = _context.CategoryIncomes.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateIncome(IncomeFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(u => u.Id == userId);
            var category = _context.CategoryIncomes.Single(c => c.Id == viewModel.Category);
            var income = new Income
            {
                User = user,
                Price = viewModel.Price,
                CategoryIncome = category,
                Date = viewModel.GetDataTime()
            };
            _context.Incomes.Add(income);
            _context.SaveChanges();
            var incomesHistory = _context.Incomes;
            var IncomesSum = incomesHistory.AsEnumerable().Where(g => g.User == user).Sum(s => s.Price);
            var SavingsAmount = user.SavingsAmount;
            _context.Categories.Find(1).AvailableMoney = (IncomesSum - SavingsAmount) * 0.4m - _context.Categories.Find(1).SpendMoney;
            _context.Categories.Find(2).AvailableMoney = (IncomesSum - SavingsAmount) * 0.2m - _context.Categories.Find(2).SpendMoney;
            _context.Categories.Find(3).AvailableMoney = (IncomesSum - SavingsAmount) * 0.06m - _context.Categories.Find(3).SpendMoney;
            _context.Categories.Find(4).AvailableMoney = (IncomesSum - SavingsAmount) * 0.03m - _context.Categories.Find(4).SpendMoney;
            _context.Categories.Find(5).AvailableMoney = (IncomesSum - SavingsAmount) * 0.05m - _context.Categories.Find(5).SpendMoney;
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}