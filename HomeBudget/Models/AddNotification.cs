using HomeBudget.Models;
using HomeBudget.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HomeBudget.Models
{
    public static class IdentityExtensions
    {
        
        public static string GetEmailAdress(this IIdentity identity)
        {

            var userId = identity.GetUserId();
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                {
                    throw new ApplicationException($"Unable to load user with this ID.");
                }
                return user.Email;
            }
        }
    }
    public class AddNotification
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();
        private readonly ApplicationDbContext _context;
        

        public AddNotification()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<bool> SendEmailNotificationAsync(string email, string content)
        {
            bool isSend = false;

            var message = new MailMessage();
            var msg = string.Format("Tommorow is the day, when you have to pay for {0}.",content);
            message.To.Add(new MailAddress(email));
            message.Subject = "Remainder";
            message.Body = msg;
            message.From = new MailAddress("myhomebudgetapi@gmail.com");
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credentials = new NetworkCredential
                {
                    UserName = "myhomebudgetapi@gmail.com",
                    Password = "Testapi!"
                };
                smtp.Credentials = credentials;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);

                isSend = true;
            }
            log.Info($"Email with remainer has been send to {email}");
            return isSend;
        }

        public void Create(string name)
        {

            var notifications = new Notification
            {
                Message = string.Format(@"You have 24 hours to pay for {0}", name),
                Date = DateTime.Now
            };
            log.Info("Notification have been set.");
            _context.Notifications.Add(notifications);
            _context.SaveChanges();
        }

        public void UpdateRemainder(FixedExpense fixedExpense)
        {
            int id = fixedExpense.Id;
            FixedExpense helper = _context.FixedExpenses.Find(id);
            _context.FixedExpenses.Remove(helper);
            _context.SaveChanges();
            DateTime Uppdate = fixedExpense.Date.AddMonths(1);
            fixedExpense.Date = Uppdate;
            _context.FixedExpenses.Add(fixedExpense);
            _context.SaveChanges();
        }
        public async Task CheckForRemainder()
        {
            while (true)
            {
                var date = DateTime.Now.AddHours(24);
                var date1 = date.AddMinutes(1);
                var date2 = date.AddMinutes(-1);
                if (_context.FixedExpenses.Any(g => g.Date <= date1 && g.Date >= date2))
                {
                    var remaind = _context.FixedExpenses.Single(g => g.Date <= date1 && g.Date >= date2);
                    Create(remaind.Name);
                    await SendEmailNotificationAsync(remaind.Email, remaind.Name);
                    UpdateRemainder(remaind);
                }
                await Task.Delay(60000);
            }
        }
    }
}