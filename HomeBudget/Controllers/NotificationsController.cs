using HomeBudget.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HomeBudget.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult ListOfNotifications()
        {
            var listOfNotifications = _context.Notifications;
            return View(listOfNotifications);
        }

        public JsonResult GetNotification()
        {
            return Json(NotificationService.GetNotification(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteMessage(int NotificationId)
        {

            bool result = false;
            var message = _context.Notifications.SingleOrDefault(x => x.Id == NotificationId);
            if (message != null)
            {
                _context.Notifications.Remove(message);
                _context.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}