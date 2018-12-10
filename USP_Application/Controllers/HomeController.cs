﻿using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USP_Application.ViewModels;

namespace USP_Application.Controllers
{
    public class HomeController : Controller
    {
        public DB_Context _context = new DB_Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            var cities = _context.Cities.ToList().OrderBy(c => c.Name);
            //var areas = _context.Areas.ToList();
            var viewModel = new ClientFormViewModel
            {
                Cities = cities/*, Areas = areas*/
            };
            return View(viewModel);
        }
    }
}