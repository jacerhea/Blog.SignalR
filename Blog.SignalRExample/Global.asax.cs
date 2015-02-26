using System;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Blog.SignalRExample.Hubs;
using Blog.SignalRExample.Models;
using Microsoft.AspNet.SignalR;

namespace Blog.SignalRExample
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var random = new Random();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                var hubContext = GlobalHost.ConnectionManager.GetHubContext<DemoHub>();

                while (true)
                {
                    hubContext.Clients.All.UpdatePrice(new Stock { Symbol = "AAPL", Price = (random.Next(100, 140) + random.NextDouble()) });
                    Thread.Sleep(500);
                }
            });

            ThreadPool.QueueUserWorkItem(_ =>
            {
                var hubContext = GlobalHost.ConnectionManager.GetHubContext<DemoHub>();

                while (true)
                {
                    hubContext.Clients.All.UpdatePrice(new Stock { Symbol = "FB", Price = (random.Next(60, 80) + random.NextDouble()) });
                    Thread.Sleep(1000);
                }
            });

            ThreadPool.QueueUserWorkItem(_ =>
            {
                var hubContext = GlobalHost.ConnectionManager.GetHubContext<DemoHub>();

                while (true)
                {
                    hubContext.Clients.All.UpdatePrice(new Stock { Symbol = "YHOO", Price = (random.Next(30, 50) + random.NextDouble()) });
                    Thread.Sleep(1500);
                }
            });

            ThreadPool.QueueUserWorkItem(_ =>
            {
                var hubContext = GlobalHost.ConnectionManager.GetHubContext<DemoHub>();

                while (true)
                {
                    hubContext.Clients.All.UpdatePrice(new Stock { Symbol = "MSFT", Price = (random.Next(40, 50) + random.NextDouble()) });
                    Thread.Sleep(2000);
                }
            });
        }
    }
}