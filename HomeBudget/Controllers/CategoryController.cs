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
            };
            return View(cat);
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category cat)
        { //jesli zaznaczono kategorie wydatkow, a jesli nie to do categoryincomes
            try
            {
                byte byt = _context.Categories.ToList().Last().Id;
                byte plus = (byte)1;
                var userId = User.Identity.GetUserId();
                var user = _context.Users.Single(u => u.Id == userId);

                if (user == null)
                {
                    throw new ApplicationException($"Unable to load user with ID '{User.Identity.GetUserId()}'.");
                }

                var category = new Category
                {
                    Id = (byte)(byt+plus),
                    Name = cat.Name,
                    User = user,
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
        public ActionResult Edit()
        {
            var cat = new Category
            {
                Categories = _context.Categories.ToList(),
            };
            return View(cat);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category cat)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var user = _context.Users.Single(u => u.Id == userId);
                _context.Categories.Single(c => c.Id == cat.category).Name = cat.Name;
                _context.SaveChanges();

                return RedirectToAction("Edit");
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
