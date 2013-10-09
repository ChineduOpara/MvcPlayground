using MvcPlayground.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPlayground.Controllers.Product
{
    public class ProductController : CitkaController
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Details(int id)
        {
            DataManager data = new DataManager();
            var model = data.Products.Where(x => x.ProductId == id).FirstOrDefault();
            SetModuleModel("ProductDetail", model);
            SetModuleModel("ProductOfTheDay", model);
            return View();            
        }

        public ViewResult Search(string query)
        {
            return View();
        }
    }
}