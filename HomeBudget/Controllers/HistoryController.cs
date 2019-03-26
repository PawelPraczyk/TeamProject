using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeBudget.Controllers
{
    public class HistoryController : Controller
    {
        
        public ActionResult HistoryPage()
        {
            ViewBag.Message = "The list of purchases.";

            return View();
        }
    }
}