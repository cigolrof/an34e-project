using an34e_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace an34e_project.Controllers
{
    public class CustomerController : Controller
    {
        Customer customer = new Customer();
        public ActionResult Index()
        {
            return View();
        }

        public ContentResult SaveCustomer(FormCollection formData)
        {
            var model = new Customer();
            TryUpdateModel(model, formData);
            model.CustomerSince = DateTime.Today;

            var response = model.Save();

            return (response) ? Content("{\"success\":true}", "application/json") : Content("{\"success\":false}", "application/json");
        }
    }
}