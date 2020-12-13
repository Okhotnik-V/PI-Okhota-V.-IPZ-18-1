﻿using CarShop.Filters;
using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        CarContext db = new CarContext();
        public ActionResult Index()
        {
            return View(db.Cars);
        }
        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            // Список культур
            List<string> cultures = new List<string>() { "uk", "en", "ru" };
            if (!cultures.Contains(lang))
            {
                lang = "uk";
            }
            // Зберігаємо обрану культуру в куки
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;
            // якщо куки вже встановлено, то оновлюємо значення
            else
            {
                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }
    }
}