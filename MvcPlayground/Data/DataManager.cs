using System.Net;
using Newtonsoft.Json;
using MvcPlayground.Models.Framework;
using MvcPlayground.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using MvcPlayground.Models.User;
using MvcPlayground.Models.Order;

namespace MvcPlayground
{
    /// <summary>
    /// Contains dummy data.
    /// </summary>
    public class DataManager
    {
        public IEnumerable<Product> Products { get; private set; }
        public IEnumerable<Customer> Customers { get; private set; }
        public IEnumerable<Order> Orders { get; private set; }

        private Dictionary<string, Page> _pages;
        public Dictionary<string, PageLayout> PageLayouts { get; private set; }
        private Dictionary<string, Module> _modules;
        public Dictionary<string, List<ModuleInstance>> ModuleInstances { get; private set; }

        private struct Consts
        {
            public const string Home = "Home";
            public const string Product = "Product";
            //public const string User = "User";
            public const string Customer = "Customer";
            public const string CustomerDetails = "CustomerDetails";
            public const string Orders = "Order";
            public const string OrderDetails = "OrderDetail";
        }

        public DataManager()
        {
            MockData();
            MockPageLayouts();
            MockPages();

            MockModules();
            MockModuleInstances();
        }

        #region Methods that build fake data
        private void MockData()
        {
            //Products = GetJsonData<List<Product>>("~/Data/products.json");
            Customers = GetJsonData<List<Customer>>("~/Data/customers.json");
            Orders = GetJsonData <List<Order>>("~/Data/orders.json");

            Customer customer = Customers.First();
            customer.Orders = Orders;
        }

        private T GetJsonData<T>(string virtualPath) where T : new()
        {
            var path = System.Web.HttpContext.Current.Server.MapPath(virtualPath);
            string text = System.IO.File.ReadAllText(path);
            
            // If string with JSON data is not empty, deserialize it to class and return its instance 
            T data = !string.IsNullOrEmpty(text) ? JsonConvert.DeserializeObject<T>(text) : new T();
            return data;
        } 

        private void MockPages()
        {
            _pages = new Dictionary<string, Page> { 
                {Consts.Home, new Page (Consts.Home) { Id = 1 , LayoutId = 101 }},
                {Consts.Product, new Page(Consts.Product) { Id = 2 , LayoutId = 102 }},
                //{Consts.User, new Page (Consts.User) { Id = 3 , LayoutId = 103 }},
                {Consts.Customer, new Page (Consts.Customer) { Id = 4 , LayoutId = 104 }},
                {Consts.CustomerDetails, new Page (Consts.CustomerDetails) { Id = 5 , LayoutId = 105 }},
                {Consts.Orders, new Page (Consts.Orders) { Id = 6 , LayoutId = 106 }},
                {Consts.OrderDetails, new Page (Consts.OrderDetails) { Id = 7 , LayoutId = 107 }}
            };
        }        

        private void MockPageLayouts()
        {
            PageLayouts = new Dictionary<string, PageLayout>()
            {
                {Consts.Home, new PageLayout(Consts.Home) { Id = 101 }},
                {Consts.Product, new PageLayout(Consts.Product) { Id = 102 }},
                //{Consts.User, new PageLayout(Consts.User) { Id = 103 }},
                {Consts.Customer, new PageLayout(Consts.Customer) { Id = 104 }},
                {Consts.CustomerDetails, new PageLayout("Customer") { Id = 105 }},
                {Consts.Orders, new PageLayout("Customer") { Id = 106 }},
                {Consts.OrderDetails, new PageLayout("Customer") { Id = 107 }}
            };

            // For now, use same zones for all the layouts
            var defaultZones = new List<Zone> 
            { 
                new Zone { LayoutId = 101, Name = "Header" },
                new Zone { LayoutId = 102, Name = "Main" },
                new Zone { LayoutId = 103, Name = "Footer" },
            };

            foreach (var layout in PageLayouts)
            {
                layout.Value.Zones = defaultZones;
            }
        }

        private void MockModules()
        {
            _modules = new Dictionary<string, Module>()
            {
                {"Header", new Module { Id = 101, Name = "Header" }},                
                {"EventViewer", new Module { Id = 113, Name = "EventViewer" } },
                {"News", new Module { Id = 115, Name = "News" }},
                {"Footer", new Module { Id = 107, Name = "Footer" }},
                {"ProductDetail", new Module { Id = 105, Name = "ProductDetail" }},
                {"ProductList", new Module { Id = 117, Name = "ProductList" }},
                {"ProductOfTheDay", new Module { Id = 103, Name = "ProductOfTheDay" }},                
                {"ProductTopSellers", new Module { Id = 111, Name = "ProductTopSellers" }},
                {"SupplierDetail", new Module { Id = 109, Name = "SupplierDetail" }},
                //{"ProductSearch", new Module { Id = 118, Name = "Product" }},
                
                {"CustomerDetail", new Module { Id = 115, Name = "CustomerDetail" }},

                {"CustomerList", new Module { Id = 115, Name = "CustomerList" }},

                {"OrderList", new Module { Id = 115, Name = "OrderList" }},
                {"OrderDetail", new Module { Id = 116, Name = "OrderDetail" }}
            };
        }

        private void MockModuleInstances()
        {
            ModuleInstances = new Dictionary<string, List<ModuleInstance>>();
            var list = new List<ModuleInstance>
            { 
                new ModuleInstance { Index = 0, Id = 110, Zone = "Header", Module = _modules["Header"] },
                new ModuleInstance { Index = 1, Id = 120, Zone = "Main", Module = _modules["EventViewer"] },
                new ModuleInstance { Index = 1, Id = 150, Zone = "Main", Module = _modules["News"] },
                new ModuleInstance { Index = 0, Id = 130, Zone = "Footer", Module = _modules["Footer"] }
            };
            ModuleInstances.Add(Consts.Home, list);

            list = new List<ModuleInstance>
            { 
                new ModuleInstance { Index = 0, Id = 410, Zone = "Header", Module = _modules["Header"] },                
                new ModuleInstance { Index = 1, Id = 140, Zone = "Main", Module = _modules["ProductTopSellers"] },
                new ModuleInstance { Index = 2, Id = 440, Zone = "Main", Module = _modules["ProductOfTheDay"] },
                new ModuleInstance { Index = 3, Id = 420, Zone = "Main", Module = _modules["ProductList"] },
                new ModuleInstance { Index = 4, Id = 430, Zone = "Footer", Module = _modules["Footer"] }
            };
            ModuleInstances.Add(Consts.Product, list);

            //list = new List<ModuleInstance>
            //{ 
            //    new ModuleInstance { Index = 0, Id = 410, Zone = "Header", Module = _modules["Header"] },
            //    new ModuleInstance { Index = 2, Id = 420, Zone = "Main", Module = _modules["CustomerList"] },
            //    new ModuleInstance { Index = 3, Id = 420, Zone = "Main", Module = _modules["CustomerDetail"] },
            //    new ModuleInstance { Index = 4, Id = 430, Zone = "Footer", Module = _modules["Footer"] }
            //};
            //ModuleInstances.Add(Consts.User, list);

            list = new List<ModuleInstance>
            { 
                new ModuleInstance { Index = 0, Id = 410, Zone = "Header", Module = _modules["Header"] },                
                new ModuleInstance { Index = 3, Id = 420, Zone = "Main", Module = _modules["CustomerList"] },
                new ModuleInstance { Index = 4, Id = 430, Zone = "Footer", Module = _modules["Footer"] }
            };
            ModuleInstances.Add(Consts.Customer, list);

            list = new List<ModuleInstance>
            { 
                new ModuleInstance { Index = 0, Id = 410, Zone = "Header", Module = _modules["Header"] },                
                new ModuleInstance { Index = 3, Id = 420, Zone = "Main", Module = _modules["CustomerDetail"] },
                new ModuleInstance { Index = 4, Id = 430, Zone = "Footer", Module = _modules["Footer"] }
            };
            ModuleInstances.Add(Consts.CustomerDetails, list);

            list = new List<ModuleInstance>
            { 
                new ModuleInstance { Index = 0, Id = 410, Zone = "Header", Module = _modules["Header"] },
                new ModuleInstance { Index = 1, Id = 140, Zone = "Main", Module = _modules["ProductTopSellers"] },
                new ModuleInstance { Index = 3, Id = 420, Zone = "Main", Module = _modules["OrderList"] },
                new ModuleInstance { Index = 4, Id = 430, Zone = "Footer", Module = _modules["Footer"] }
            };
            ModuleInstances.Add(Consts.Orders, list);

            list = new List<ModuleInstance>
            { 
                new ModuleInstance { Index = 0, Id = 410, Zone = "Header", Module = _modules["Header"] },
                new ModuleInstance { Index = 1, Id = 140, Zone = "Main", Module = _modules["OrderDetail"] },
                new ModuleInstance { Index = 4, Id = 430, Zone = "Footer", Module = _modules["Footer"] }
            };
            ModuleInstances.Add(Consts.OrderDetails, list);
        }
        #endregion

        private string GetLatestVersion(string appCode)
        {
            return "3.5";
        }

        private string GetApplicationCodeByDomain(string domain)
        {
            return "APPL";
        }

        public Application GetApplication(string domain)
        {
            var appCode = GetApplicationCodeByDomain(domain);
            return GetApplication(appCode, GetLatestVersion(appCode));
        }

        public Application GetApplication(string code, string version)
        {
            var app = new Application { Id = 1, Code = code, Version = version ?? GetLatestVersion(code), Domain = "localhost" };
            var pages = _pages.Select(x => x.Value);
            ((List<Page>)app.Pages).AddRange(pages);
            return app;
        }

        //public Product GetProduct(int id)
        //{
        //    return Products.Where(x => x.ProductId == id).FirstOrDefault();
        //}
    }
}