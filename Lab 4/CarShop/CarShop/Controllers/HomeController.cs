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


        [HttpGet]
        public ActionResult Create()
        {
            //Формуємо список cалонів для передачі в представлення
            SelectList salons = new SelectList(db.Salons, "Id", "Name");
            ViewBag.Salons = salons;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Car car)
        {
            // Додаємо гравця в таблицю
            db.Cars.Add(car);
            db.SaveChanges();
            // перенаправляємо на головну сторінку
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            // Знаходимо в БД автомобіля
            Car car = db.Cars.Find(id);
            if (car != null)
            {
                // Створюємо список салонів для передачі в представлення
                SelectList salons = new SelectList(db.Salons, "Id", "Name", car.SalonId);
                ViewBag.Salons = salons;
                return View(car);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Car car)
        {
            db.Entry(car).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Car purch = db.Cars.Find(id);
            if (purch == null)
            {
                return HttpNotFound();
            }
            return View(purch);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Car purch = db.Cars.Find(id);
            if (purch == null)
            {
                return HttpNotFound();
            }
            db.Cars.Remove(purch);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}