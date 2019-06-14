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
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{User.Identity.GetUserId()}'.");
            }
            var category = _context.CategoryIncomes.Single(c => c.Id == viewModel.Category);
            var income = new Income
            {
                User = user,
                Price = viewModel.Price,
                CategoryIncome = category,
                Date = viewModel.GetDataTime()
            };
            if (user.IfSavingsPercent)
            {
                _context.Incomes.Add(income);
                _context.SaveChanges();
                var incomesHistory = _context.Incomes;
                var IncomesSum = incomesHistory.AsEnumerable().Where(g => g.User == user).Sum(s => s.Price);
                var SavingsAmount = user.SavingsAmount;
                for (int i = 1; i <= _context.Categories.Count(); i++)
                    _context.Categories.Find(i).AvailableMoney = (IncomesSum - SavingsAmount) * _context.Categories.Find(i).PercentMoney - _context.Categories.Find(i).SpendMoney;
            }
            else
            {
                for (int i = 1; i <= _context.Categories.Count(); i++)
                    _context.Categories.Find(i).AvailableMoney = _context.Categories.Find(i).AmountMoney - _context.Categories.Find(i).SpendMoney;
                _context.Incomes.Add(income);
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}