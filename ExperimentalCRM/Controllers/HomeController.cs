using System.Linq;
using System.Web.Mvc;
using ExperimentalCMS.Model.DataAccess;

namespace ExperimentalCMS.Web.BackEnd.Controllers
{
    public class HomeController : Controller
    {
        private ExCMSContext db = new ExCMSContext();
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
