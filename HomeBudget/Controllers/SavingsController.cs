using HomeBudget.Models;
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
            //ApplicationUser userTemp = UserManager.FindById(userId);
            var store = new UserStore<ApplicationUser>(_context);
            var manager = new UserManager<ApplicationUser>(store);
            ApplicationUser userr = manager.FindById(userId);
            userr.SavingsAmount = user.SavingsAmount;
            manager.Update(userr);
            var incomesHistory = _context.Incomes;
            var IncomesSum = incomesHistory.AsEnumerable().Where(g => g.User == userr).Sum(s => s.Price);
            var SavingsAmount = userr.SavingsAmount;
            _context.Categories.Find(1).AvailableMoney = (IncomesSum - SavingsAmount) * 0.4m - _context.Categories.Find(1).SpendMoney;
            _context.Categories.Find(2).AvailableMoney = (IncomesSum - SavingsAmount) * 0.2m - _context.Categories.Find(2).SpendMoney;
            _context.Categories.Find(3).AvailableMoney = (IncomesSum - SavingsAmount) * 0.06m - _context.Categories.Find(3).SpendMoney;
            _context.Categories.Find(4).AvailableMoney = (IncomesSum - SavingsAmount) * 0.03m - _context.Categories.Find(4).SpendMoney;
            _context.Categories.Find(5).AvailableMoney = (IncomesSum - SavingsAmount) * 0.05m - _context.Categories.Find(5).SpendMoney;
            _context.SaveChanges();
            return View();
        }


    }
}