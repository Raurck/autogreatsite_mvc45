﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using autogreatsite_mvc45.Engines;


namespace autogreatsite_mvc45
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RoleBasedRazorViewEngine(new[] { "Administrator", "Operator", "User" }));

            Application["CarPhotos"] = "~/Content/Photo";
        }
    }
}
