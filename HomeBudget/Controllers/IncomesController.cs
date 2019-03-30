﻿using HomeBudget.Models;
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
                CategoryIncome = category
            };
            _context.Incomes.Add(income);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}