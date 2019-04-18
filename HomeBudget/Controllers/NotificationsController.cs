using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeBudget.Controllers
{
    public class NotificationsController : Controller
    {
        // GET: Notifications
        public ActionResult ListOfNotifications()
        {
            return View();
        }
    }
}