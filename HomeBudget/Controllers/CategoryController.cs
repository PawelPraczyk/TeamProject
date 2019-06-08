using HomeBudget.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeBudget.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Expenses

        public ActionResult Index()
        {
            return View();
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            var cat = new Category
            {
                Colors = _context.Colors.ToList(),
                Icons = _context.Icons.ToList(),
            };
            return View(cat);
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category cat)
        { //jesli zaznaczono kategorie wydatkow, a jesli nie to do categoryincomes
            try
            {
                var userId = User.Identity.GetUserId();
                var user = _context.Users.Single(u => u.Id == userId);
                var icon = _context.Icons.Single(c => c.Id == cat.Icon.Id);
                var color = _context.Colors.Single(c => c.Id == cat.Color.Id);
                var category = new Category
                {
                    Name = cat.Name,
                    Color = color,
                    User = user,
                    Icon = icon,
                    AvailableMoney = 0,
                    SpendMoney = 0,
                    AmountMoney = 0,
                    PercentMoney = 0
                };
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }
    }
}
