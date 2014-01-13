using System.Web.Mvc;
using ExperimentalCMS.Domain.Contracts;

namespace ExperimentalCMS.Web.FrontEnd.Controllers
{
    public class PlaceController : Controller
    {

        private IPlaceManager _placeManager;

        public PlaceController(IPlaceManager placeManager)
        {
            _placeManager = placeManager;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
