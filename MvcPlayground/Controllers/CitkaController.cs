using MvcPlayground.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcPlayground.Controllers
{
    public class CitkaController : Controller
    {
        public Application Application
        {
            get { return ViewBag.Application as Application; }
        }

        public Page Page
        {
            get { return ViewBag.Page as Page; }
        }

        public new ViewResult View()
        {
            if (Page.Layout != null)
            {
                return base.View(Page.Layout.PartialViewUrl, Page.Layout);
            }
            else
            {
                return base.View();
            }
        }

        public void SetModuleModel<T>(string moduleName, T model)
        {
            if (Page != null)
            {
                var container = Page[moduleName];
                if (container != null)
                {
                    var containerWithModel = new ModuleContainer<T>(container) { Entity = model };
                    Page.ReplaceContainer(containerWithModel);
                }
            }
        }
    }
}
