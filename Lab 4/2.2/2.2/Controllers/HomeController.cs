using _2._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace _2._2.Controllers
{
    public class HomeController : Controller
    {
        private StudentsContext db = new StudentsContext();
        public ActionResult Index()
        {
            var cars = db.Students.Include(p => p.Courses);
            return View(cars.ToList());
        }
        public ActionResult Details(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Edit(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Courses = db.Courses.ToList();
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student student, int[] selectedCourses)
        {
            Student newStudent = db.Students.Find(student.Id);
            newStudent.Name = student.Name;
            newStudent.Surname = student.Surname;

            newStudent.Courses.Clear();
            if (selectedCourses != null)
            {
                //получаем выбранные курсы
                foreach (var c in db.Courses.Where(co =>
               selectedCourses.Contains(co.Id)))
                {
                    newStudent.Courses.Add(c);
                }
            }
            db.Entry(newStudent).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            //Формуємо список cалонів для передачі в представлення
            SelectList courses = new SelectList(db.Courses, "Id", "Name");
            ViewBag.Courses = courses;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            // Додаємо гравця в таблицю
            db.Students.Add(student);
            db.SaveChanges();
            // перенаправляємо на головну сторінку
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Student purch = db.Students.Find(id);
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
            Student purch = db.Students.Find(id);
            if (purch == null)
            {
                return HttpNotFound();
            }
            db.Students.Remove(purch);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}