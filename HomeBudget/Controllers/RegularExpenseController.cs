using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeBudget.Models;
using HomeBudget.ViewModels;
using Microsoft.AspNet.Identity;

namespace HomeBudget.Controllers
{
    public class RegularExpenseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RegularExpense
        public ActionResult Index()
        {
            return View(db.FixedExpenses.ToList());
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(FixedExpenseViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Single(u => u.Id == userId);


            var fixedExpense = new FixedExpense
            {
                Date = viewModel.GetDataTime(),
                Price = viewModel.Price,
                Name = viewModel.Name,
                Email = user.Email
            };
            db.FixedExpenses.Add(fixedExpense);
            db.SaveChanges();

            return RedirectToAction("Index", "RegularExpense");
        }
    

    // GET: RegularExpense/Edit/5
    public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FixedExpense fixedExpense = db.FixedExpenses.Find(id);
            if (fixedExpense == null)
            {
                return HttpNotFound();
            }
            return View(fixedExpense);
        }

        // POST: RegularExpense/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Date,Email")] FixedExpense fixedExpense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fixedExpense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fixedExpense);
        }

        public ActionResult DeleteConfirmed(int id)
        {
            FixedExpense fixedExpense = db.FixedExpenses.Find(id);
            db.FixedExpenses.Remove(fixedExpense);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
