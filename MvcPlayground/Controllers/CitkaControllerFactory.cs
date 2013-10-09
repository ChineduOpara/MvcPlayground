using MvcPlayground;
using MvcPlayground.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcPlayground.Controllers
{
    public class CitkaControllerFactory : DefaultControllerFactory
    {
        public readonly static string DefaultAction = "Index";

        //public override IController CreateController(RequestContext requestContext, string controllerName)
        //{
        //    return base.CreateController(requestContext, controllerName);
        //}

        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            var controllerType = base.GetControllerType(requestContext, controllerName);
            // if a controller wasn't found with a matching name, return our dynamic controller
            return controllerType ?? typeof(CitkaController);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            var controller = base.GetControllerInstance(requestContext, controllerType) as CitkaController;

            object appCode;
            requestContext.RouteData.Values.TryGetValue("application", out appCode);
            
            object appVersion;
            requestContext.RouteData.Values.TryGetValue("version", out appVersion);

            var controllerName = Convert.ToString(requestContext.RouteData.Values["controller"]);
            
            object action;
            requestContext.RouteData.Values.TryGetValue("action", out action);

            // COPARA: To avoid this concatenation, I would add a separate property to the Page class: "Action", while renaming the Page.Name to "Page.Controller".
            // Then we could call a GetPage method which looks up a page by Controller AND Action. While it doesn't necessarily "buy" us anything,
            // that approach would be easier to understand (to many) and avoid this hack-ey approach to looking up the page object.

            if (action != null && action.ToString() != CitkaControllerFactory.DefaultAction)
            {
                controllerName += "" + action;
            }

            DataManager data = new DataManager();
            var application = appCode != null ? data.GetApplication(Convert.ToString(appCode), Convert.ToString(appVersion)) : data.GetApplication(requestContext.HttpContext.Request.Url.Host);

            var page = application[controllerName];
            if (page != null)
            {
                page.ModuleInstances = data.ModuleInstances[page.Name];
            }

            // Set all the high-level ViewBag properties
            controller.ViewBag.Application = application;
            controller.ViewBag.Page = page;
            controller.ViewBag.PageTitle = page.Name;
            
            return controller;
        }
    }
}
