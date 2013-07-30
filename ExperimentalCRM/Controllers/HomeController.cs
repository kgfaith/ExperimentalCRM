using System.Linq;
using System.Web.Mvc;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Repositories.DataAccess;

namespace ExperimentalCMS.Web.BackEnd.Controllers
{
    public class HomeController : Controller
    {
        private IPhotoManager _photoManager;

        public HomeController(IPhotoManager photoManager)
        {
            _photoManager = photoManager;
        }

        public ActionResult Index()
        {
            _photoManager.GetOnePhotoInfoFromFlickr();
            return View();
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
