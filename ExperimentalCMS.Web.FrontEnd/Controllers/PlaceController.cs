using System.Web.Mvc;
using ExperimentalCMS.Domain.Contracts;
using ExperimentalCMS.Model;
using ExperimentalCMS.ViewModels;

namespace ExperimentalCMS.Web.FrontEnd.Controllers
{
    public class PlaceController : Controller
    {

        private IPlaceManager _placeManager;

        public PlaceController(IPlaceManager placeManager)
        {
            _placeManager = placeManager;
        }

        public ActionResult Index(int id = 0)
        {
            var domainResponse = _placeManager.GetPlaceWithChildPlacesById(id);

            if (domainResponse.Result == null)
            {
                return HttpNotFound();
            }

            PlaceViewModel model = new PlaceViewModel 
                                    {
                                        PlaceName = domainResponse.Result.PlaceName
                                    };

            return View(model);
        }

    }
}
