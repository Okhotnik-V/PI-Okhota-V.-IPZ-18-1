using Car_dealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Car_dealership.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        Models.CasrContext db = new Models.CasrContext();
        public ActionResult Index()
        {
            //Отримка даних з БД
            IEnumerable<Models.Сars> cars = db.Cars;
            //Передача всіх об'єктів в динамічну властивість Cars в ViewBag
            ViewBag.Cars = cars;
            //Повертаємо приставлення
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id) {
            ViewBag.CarsID = id;
            return View();
                }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            // Додаємо інформацію про покупку в базу даних
            db.Purchases.Add(purchase);
            // Зберігаємо в БД всі зміни
            db.SaveChanges();
            return "Дякую," + purchase.Person + ", за покупку!";
        }
    }
}