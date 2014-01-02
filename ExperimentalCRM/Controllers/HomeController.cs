using System.Linq;
using System.Web.Mvc;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Repositories.DataAccess;
using ExperimentalCMS.ViewModels;
using ExperimentalCMS.Web.BackEnd.Domain;

namespace ExperimentalCMS.Web.BackEnd.Controllers
{
    public class HomeController : Controller
    {
       
        public HomeController()
        {
            
        }

        public ActionResult Index()
        {
            //var obj = _photoManager.GetOnePhotoInfoFromFlickr("9419291586");
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

        public ActionResult PaginationItems(PaginationModel model)
        {
            var list = Pagination.CreatePaginationList(model, Url);
            return PartialView("_Pagination", list);
        }   
    }
}
