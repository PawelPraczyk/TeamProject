using HomeBudget.Controllers;
using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HomeBudget
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private async void Start()
        {
            var notification = new AddNotification();
            await notification.CheckForRemainder();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SqlDependency.Start(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\janek\Desktop\TeamProject\HomeBudget\App_Data\aspnet-HomeBudget-20190326032835.mdf;Initial Catalog=aspnet-HomeBudget-20190326032835;Integrated Security=True");
            Start();


            log4net.Config.XmlConfigurator.Configure();
        }
    }
}