using MvcPlayground.Models.Framework;
using MvcPlayground.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPlayground.Controllers.Product
{
    public class CustomerController : CitkaController
    {
        public ViewResult Index()
        {
            var customers = new DataManager().Customers;
            SetModuleModel("CustomerList", customers);
            return View();
        }

        public ViewResult Details(int id)
        {
            var customer = new DataManager().Customers.First(x => x.Id == id);
            SetModuleModel("CustomerDetail", customer);
            return View();
        }        
    }
}