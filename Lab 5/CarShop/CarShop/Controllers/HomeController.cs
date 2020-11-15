using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CarShop.Models;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        CarContext db = new CarContext();
        // Виводимо всі автомобілі
        public ActionResult Index()
        {
            var cars = db.Cars.Include(p => p.Salon);
            return View(cars.ToList());
        }

        public ActionResult SalonDetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Salon salon = db.Salons.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            salon.Cars = db.Cars.Where(m => m.SalonId == salon.Id);
            return View(salon);
        }

        public ActionResult SpisSal()
        {
            return View(db.Salons);
        }


      
        

    }
}