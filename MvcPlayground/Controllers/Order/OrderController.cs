using MvcPlayground.Models.Framework;
using MvcPlayground.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPlayground.Controllers.Product
{
    public class OrderController : CitkaController
    {
        public ViewResult Index()
        {
            SetModuleModel("OrderList", new DataManager().Orders);
            return View();
        }

        public ViewResult Detail(int id)
        {
            var order = new DataManager().Orders.First(x => x.Id == id);
            SetModuleModel("OrderDetail", order);
            return View();
        }
    }
}