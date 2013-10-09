using Microsoft.Web.Mvc;
using MvcPlayground.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcPlayground
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Bootstrapper.Initialize();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // This is to support the View/Modules* and View/Pages* folder structure.
            var viewEngine = ViewEngines.Engines.Where(x => x is FixedRazorViewEngine).FirstOrDefault() as FixedRazorViewEngine;
            var format = new string[]{ "~/Views/Pages/{1}/{0}.cshtml" };
            viewEngine.ViewLocationFormats = viewEngine.ViewLocationFormats.Union(format).ToArray();
            format[0] = "~/Views/Modules/{1}/{0}.cshtml";
            viewEngine.PartialViewLocationFormats = viewEngine.PartialViewLocationFormats.Union(format).ToArray();
        }
    }
}