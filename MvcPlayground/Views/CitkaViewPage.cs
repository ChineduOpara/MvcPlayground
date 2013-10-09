using MvcPlayground.Models.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;

namespace MvcPlayground.Views
{
    public abstract class CitkaViewPage : WebViewPage<PageLayout>
    {
        public HelperResult RenderZone(string name)
        {
            Action<TextWriter> action = writer =>
            {
                var zone = Model[name];
                if (zone != null)
                {
                    foreach (var container in zone.ModuleContainers)
                    {
                        try
                        {
                            writer.Write(Html.Partial(container.ModuleInstance.Module.PartialViewUrl, container.GetModel()).ToHtmlString());
                        }
                        catch (Exception ex)
                        {
                            string physicalPath = Server.MapPath(container.ModuleInstance.Module.ErrorViewUrl);
                            if (File.Exists(physicalPath))
                            {
                                writer.Write(Html.Partial(container.ModuleInstance.Module.ErrorViewUrl, new ErrorViewModel { Exception = ex, Model = container.GetModel() }).ToHtmlString());
                            }
                        }
                    }
                }
            };
            return new HelperResult(action);
        }
    }

    public abstract class CitkaViewPage<T> : CitkaViewPage where T : PageLayout
    {
    }
}