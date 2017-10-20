using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NPS_MVC.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            var url = Request.RawUrl;
            var lstPages = new List<String>() { "/Shared/Login", "/Shared/Execute" };
            var loginRequired = !lstPages.Any(page => url.StartsWith(page));
            if (loginRequired && Session["User"] == null)
                filterContext.Result = new RedirectResult("/Shared/Login");
            base.OnAuthorization(filterContext);
        }

        public static Dictionary<Int32, String> getMonths()
        {
            var dict = new Dictionary<Int32, String>();
            dict.Add(0, "Todos");
            dict.Add(1, "Janeiro");
            dict.Add(2, "Fevereiro");
            dict.Add(3, "Março");
            dict.Add(4, "Abril");
            dict.Add(5, "Maio");
            dict.Add(6, "Junho");
            dict.Add(7, "Julho");
            dict.Add(8, "Agosto");
            dict.Add(9, "Setembro");
            dict.Add(10, "Outubro");
            dict.Add(11, "Novembro");
            dict.Add(12, "Dezembro");
            return dict;
        }
    }
}