﻿using an34e_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace an34e_project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Customers()
        {
            List<Customer> c = new List<Customer>();
            c.Add(new Customer()
            {
                CustomerSince = new DateTime(),
                Name = "sadadsd",
                Responsible = "xxxxxxxxx"
            });
            

            return View(c);
        }

        public ActionResult Question()
        {
            var obj = new Question().ListQuestions();
            return View(obj);
        }
    }
}