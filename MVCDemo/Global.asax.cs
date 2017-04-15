using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using MVCDemo.Models;

namespace MVCDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


            /// Same as next line.... 
            Database.SetInitializer(new SampleDbInitializer());
            //Database.SetInitializer<SampleDbContext>(new DropCreateDatabaseIfModelChanges<SampleDbContext>());
            //Database.SetInitializer<SampleDbContext>(new DropCreateDatabaseAlways<SampleDbContext>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
