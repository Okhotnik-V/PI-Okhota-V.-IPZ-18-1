using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab_2_1.Models;

namespace Lab_2_1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        Product myProduct = new Product
        {
            ProductID = 1,
            Name = "Автомобільна аптечка",
            Description = "Бінт 5м, Перекись водню 250мг , йод 100мг , пластирі 50шт , жгут 1шт , ношпа 2 пласт. , ношатирний спирт 50мл.",
            Category = "Скомплектоані ліки",
            Price = 275M
        };
        public ActionResult Index()
        {
            return View(myProduct);
        }
        public ActionResult NameAndPrice()
        {
            return View(myProduct);
        }
        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Supplier = null;
            return View(myProduct);
        }
        public ActionResult DemoArray()
        {
            Product[] array = {
        new Product {Name = "Ношпа", Price = 118.00M, Category = "Знеболююча", ProductID = 2},
        new Product {Name = "Аспірин", Price = 50.50M, Category = "Проти температури", ProductID =3},
        new Product {Name = "Стрепсилс", Price = 220.20M, Category = "Від болю у горлі", ProductID = 4},
        new Product {Name = "Грипаут", Price = 34.95M, Category = "Від грипу",ProductID = 5}
 };
            return View(array);
        }

    }
}
