using HomeBudget.Models;
using HomeBudget.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeBudget.Controllers
{
    public class SavingsController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [Authorize]
        public ActionResult ChangeSavings()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangeSavings(ApplicationUser user)
        {
            var userId = User.Identity.GetUserId();
            var usero = _context.Users.Single(u => u.Id == userId);
            if (usero.IfSavingsPercent)
            {
                var store = new UserStore<ApplicationUser>(_context);
                var manager = new UserManager<ApplicationUser>(store);
                ApplicationUser userr = manager.FindById(userId);
                userr.SavingsAmount = user.SavingsAmount;
                manager.Update(userr);
                var incomesHistory = _context.Incomes;
                var IncomesSum = incomesHistory.AsEnumerable().Where(g => g.User == userr).Sum(s => s.Price);
                var SavingsAmount = userr.SavingsAmount;
                for (int i = 1; i <= _context.Categories.Count(); i++)
                    _context.Categories.Find(i).AvailableMoney = (IncomesSum - SavingsAmount) * _context.Categories.Find(i).PercentMoney - _context.Categories.Find(i).SpendMoney;
            }
            else
            {
                for (int i = 1; i <= _context.Categories.Count(); i++)
                    _context.Categories.Find(i).AvailableMoney = _context.Categories.Find(i).AmountMoney - _context.Categories.Find(i).SpendMoney;
            }
            _context.SaveChanges();
            return View();
        }

        [Authorize]
        public ActionResult ChangePercent()
        {
            var categoryModel = new Category
            {
                Categories = _context.Categories.ToList(),
            };
            return View(categoryModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePercent(Category categoryModel )
        {
            var userId = User.Identity.GetUserId();
            var userr = _context.Users.Single(u => u.Id == userId);
            var incomesHistory = _context.Incomes;
            var IncomesSum = incomesHistory.AsEnumerable().Where(g => g.User == userr).Sum(s => s.Price);
            var SavingsAmount = userr.SavingsAmount;     
            _context.Categories.Find(categoryModel.category).PercentMoney = categoryModel.PercentMoney;
            _context.Categories.Find(categoryModel.category).AvailableMoney = (IncomesSum - SavingsAmount) * _context.Categories.Find(categoryModel.category).PercentMoney - _context.Categories.Find(categoryModel.category).SpendMoney;
            _context.SaveChanges();
            return RedirectToAction("ChangePercent", "Savings");
        }
        [Authorize]
        public ActionResult ChangeAmount()
        {
            var categoryModel = new Category
            {
                Categories = _context.Categories.ToList(),
            };
            return View(categoryModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangeAmount(Category categoryModel)
        {
            var userId = User.Identity.GetUserId();
            var userr = _context.Users.Single(u => u.Id == userId);
            _context.Categories.Find(categoryModel.category).AmountMoney = categoryModel.AmountMoney;
            _context.Categories.Find(categoryModel.category).AvailableMoney = _context.Categories.Find(categoryModel.category).AmountMoney - _context.Categories.Find(categoryModel.category).SpendMoney;
            _context.SaveChanges();
            return RedirectToAction("ChangeAmount", "Savings");
        }
    }
}