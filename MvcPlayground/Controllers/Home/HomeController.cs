using MvcPlayground.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPlayground.Controllers.Product
{
    public class HomeController : CitkaController
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}