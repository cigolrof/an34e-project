using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace an34e_project.Controllers
{
    public class AvaliationController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ContentResult QueryQuestionNps(int level, int requiredLevel, int isNps) {

            var x = Models.Question.SelectQuestion(level, requiredLevel, isNps);

            return null;
        }
    }
}