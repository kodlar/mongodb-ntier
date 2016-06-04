using System;
using System.Net;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LightInject;
using MongoSampleDotNet;

namespace BookDesktop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ServicePointManager.DefaultConnectionLimit = Int32.MaxValue;
            ServicePointManager.MaxServicePoints = Int32.MaxValue;
            ServicePointManager.SetTcpKeepAlive(true, 5000, 1000);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new ServiceContainer();
            container.RegisterControllers();
            
            container.RegisterAssembly(typeof(Book.Repository.modules.ModuleCompositionRoot).Assembly);
            container.RegisterAssembly(typeof(Book.Services.modules.ModuleCompositionRoot).Assembly);

            container.EnableMvc();

        }
    }
}
