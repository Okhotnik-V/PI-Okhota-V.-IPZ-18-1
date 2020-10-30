using car.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DTPReg.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        CarContext db = new CarContext();
        public ActionResult Index()
        {
            return View(db.Purchases);
        }
        public ActionResult MobileView(int id)
        {
            var purch = db.Purchases.Find(id);
            if (purch != null)
            {
                return View(purch);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Purchase purch = db.Purchases.Find(id);
            if (purch == null)
            {
                return HttpNotFound();
            }
            return View(purch);
        }
        [HttpPost]
        public ActionResult Edit(Purchase purch)
        {
            db.Entry(purch).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Purchase purch)
        {
            db.Purchases.Add(purch);
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
            Purchase purch = db.Purchases.Find(id);
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
            Purchase purch = db.Purchases.Find(id);
            if (purch == null)
            {
                return HttpNotFound();
            }
            db.Purchases.Remove(purch);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}