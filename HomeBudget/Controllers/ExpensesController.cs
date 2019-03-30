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
    public class ExpensesController : Controller
    {
        private readonly ApplicationDbContext _context;
        // GET: Expenses

        public ExpensesController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new ExpenseFormViewModel
            {
                Categories = _context.Categories.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(ExpenseFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(u => u.Id == userId);
            var category = _context.Categories.Single(c => c.Id == viewModel.Category);
            var expense = new Expense
            {
                User = user,
                Price = viewModel.Price,
                Category = category
            };
            _context.Expenses.Add(expense);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}