
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace HomeBudget.Hubs
{
    public class SenderHub : Hub
    {
        public static void Show()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<SenderHub>();
            context.Clients.All.displayStatus();
        }
    }
}