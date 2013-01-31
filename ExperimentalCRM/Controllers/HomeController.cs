using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DataAccess;

namespace ExperimentalCRM.Controllers
{
    public class HomeController : Controller
    {
        private ExCrmContext db = new ExCrmContext();
        public ActionResult Index()
        {

            return View(db.Articles.FirstOrDefault());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your quintessential contact page.";

            return View();
        }
    }
}
